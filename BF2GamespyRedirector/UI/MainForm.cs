using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BF2GamespyRedirector.Properties;
using MetroFramework;
using MetroFramework.Forms;

namespace BF2GamespyRedirector
{
    public partial class MainForm : MetroForm
    {
        protected TaskStep ErrorStep;

        public ParamsCollection Params;

        protected GameRunningForm RunningOverlay;

        internal static MainForm Instance { get; set; }

        public MainForm()
        {
            // Create form controls
            InitializeComponent();

            // Set instance
            Instance = this;

            // Make sure the basic configuration settings are setup by the user,
            // and load the BF2 server and installed mods
            if (!SetupManager.Run())
            {
                this.Load += (s, e) => this.Close();
                return;
            }

            // Load Bf2 mods
            LoadModList();

            // Load client settings
            ClientSettings.Load();
            ReloadProviders();
            ReloadServers();

            // Setup theme
            metroStyleManager1.Theme = MetroThemeStyle.Light;
            metroStyleManager1.Style = MetroColorStyle.Blue;

            // Set default texts
            InstallDirTextbox.Text = Program.Config.Bf2InstallDir;

            // Load Redirector
            bool AllSystemsGo = Redirector.Initialize();

            // Select provider if we have redirects detected
            if (Redirector.RedirectsEnabled)
            {
                ServiceProvider Provider;
                if (String.IsNullOrEmpty(Program.Config.LastUsedProvider))
                {
                    Provider = ClientSettings.ServiceProviders
                        .Where(x => x.StatsAddress == Redirector.StatsServerAddress.ToString() 
                            && x.GamespyAddress == Redirector.GamespyServerAddress.ToString())
                        .FirstOrDefault();
                }
                else
                {
                    Provider = ClientSettings.ServiceProviders
                        .Where(x => x.Name == Program.Config.LastUsedProvider)
                        .FirstOrDefault();
                }

                // Set the last used provider if we have one
                if (Provider != null)
                    ProviderComboBox.SelectedItem = Provider;
            }

            // Set redirect mode
            IcsRadioButton.Checked = false;
            switch (Program.Config.RedirectMode)
            {
                case RedirectMode.HostsIcsFile:
                    IcsRadioButton.Checked = true;
                    break;
                case RedirectMode.HostsFile:
                    HostsRadioButton.Checked = true;
                    break;
                case RedirectMode.DnsServer:
                    DnsRadioButton.Checked = true;
                    break;
            }

            // Set redirect removal
            switch (Program.Config.RedirectRemoveMethod)
            {
                case RedirectRemoveMethod.Never:
                    NeverRadioButton.Checked = true;
                    break;
                case RedirectRemoveMethod.OnAppClose:
                    AppExitsRadioButton.Checked = true;
                    break;
                case RedirectRemoveMethod.OnGameClose: break;
            }

            // Auto Login Settings
            CredentialsCheckBox.Checked = Program.Config.PromptCredentials;
            ProgramUpdateCheckBox.Checked = Program.Config.CheckForUpdates;

            // Load our params
            Params = new ParamsCollection(Program.Config.LaunchParams);
            LaunchParamsTextBox.Text = Params.BuildString(false);

            // Register for events
            BF2Client.PathChanged += LoadModList;
            BF2Client.Started += BF2Client_Started;
            BF2Client.Exited += BF2Client_Exited;

            // Focus the mod select first on the Launcher tab!
            MainTabControl.SelectedIndex = 0;

            // Start updater
            if (Program.Config.CheckForUpdates)
            {
                ProgramUpdater.CheckCompleted += ProgramUpdater_CheckCompleted;
                ProgramUpdater.CheckForUpdateAsync();
            }


            // Once the form is shown, asynchronously load the redirect service
            this.Shown += (s, e) =>
            {
                // Focus the mod select combobox
                ModComboBox.Focus();

                // Since we werent registered for Bf2Client events before, do this here
                if (BF2Client.IsRunning)
                    BF2Client_Started();
            };
        }

        private async void ProgramUpdater_CheckCompleted(object sender, EventArgs e)
        {
            if (ProgramUpdater.UpdateAvailable)
            {
                // Show overlay first, which provides the smokey (Modal) background
                using (ModalOverlay overlay = new ModalOverlay(this, 0.3))
                {
                    // Show overlay
                    overlay.Show(this);

                    // Make sure a mod is selected
                    DialogResult r = MetroMessageBox.Show(overlay,
                        "An Update for this program is avaiable for download (" + ProgramUpdater.NewVersion + ")."
                        + Environment.NewLine.Repeat(1)
                        + "Would you like to download and install this update now?",
                        "Update Available",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, 150
                    );

                    // Apply update
                    if (r == DialogResult.Yes)
                    {
                        bool success = false;
                        try
                        {
                            success = await ProgramUpdater.DownloadUpdateAsync(overlay);
                        }
                        catch (Exception ex)
                        {
                            // Create Exception Log
                            TraceLog.TraceWarning("Unable to Download new update archive :: Generating Exception Log");
                            ExceptionHandler.GenerateExceptionLog(ex);

                            // Alert User
                            MetroMessageBox.Show(overlay,
                                "Failed to download update archive! Reason: " + ex.Message
                                + Environment.NewLine.Repeat(1)
                                + "An exception log has been generated and created inside the My Documents/BF2Statistics folder.",
                                "Download Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }

                        // If the file downloaded successfully
                        if (success)
                        {
                            try
                            {
                                ProgramUpdater.RunUpdate();
                            }
                            catch (Exception ex)
                            {
                                MetroMessageBox.Show(overlay,
                                   "An Occured while trying to install the new update. You will need to manually apply the update."
                                   + Environment.NewLine.Repeat(1) + "Error Message: " + ex.Message,
                                   "Installation Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error
                               );
                            }
                        }
                    }

                    // Close overlay
                    overlay.Close();

                    // Focus the mod select
                    ModComboBox.Focus();
                }
            }
        }

        private void BF2Client_Exited()
        {
            // Remove redirects if that is the selected option
            if (Bf2ExitsRadioButton.Checked)
                Redirector.RemoveRedirects();

            // Re-enable button to prevent spam
            Invoke((MethodInvoker) delegate 
            {
                if (RunningOverlay != null && RunningOverlay.IsHandleCreated)
                {
                    try
                    {
                        RunningOverlay.Close();
                        RunningOverlay = null;
                    }
                    catch (ObjectDisposedException) { }
                }

                LaunchButton.Text = "Launch Battefield 2";
                LaunchButton.Enabled = true;
                this.BringToFront();
                LaunchButton.Focus();
            });
        }

        private void BF2Client_Started()
        {
            // Re-enable button to prevent spam
            Invoke((MethodInvoker)delegate
            {
                LaunchButton.Text = "Shutdown Battefield 2";
                LaunchButton.Enabled = true;
            });
        }

        /// <summary>
        /// Loads up all the supported mods, and adds them to the Mod select list
        /// </summary>
        private void LoadModList()
        {
            // Clear the list
            ModComboBox.Items.Clear();
            ModComboBox.Items.Add("- None -");

            // Add each valid mod to the mod selection list
            foreach (BF2Mod Mod in BF2Client.Mods)
            {
                Trace.TraceInformation("Found Mod \"" + Mod.Name + "\".");
                ModComboBox.Items.Add(Mod);
                //if (Mod.Name == "bf2")
                    //ModComboBox.SelectedIndex = ModComboBox.Items.Count - 1;
            }

            // Make sure we have a mod selected. This can fail to happen in the bf2 mod folder is changed
            if (ModComboBox.SelectedIndex == -1)
                ModComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Clears the Server Combo boxes and refills them with the list of servers
        /// </summary>
        /// <param name="launchSelectedServer">The selected server, if any, from the Launch tab</param>
        /// <param name="manageSelectedServer">The selected server, if any, from the Multiplayer tab</param>
        /// <param name="CallEvents">Indicates whether we call the "SelectedIndexChanged" events</param>
        private void ReloadServers(Server launchSelectedServer = null, Server manageSelectedServer = null, bool CallEvents = true)
        {
            // If we are NOT calling events for this, unregister
            if (!CallEvents)
                ServerComboBox.SelectedIndexChanged -= ServerComboBox_SelectedIndexChanged;

            try
            {
                // Clear out the old servers list
                ServerComboBox.Items.Clear();
                ServerComboBox.Items.Add("- None -");
                ServerManageComboBox.Items.Clear();
                ServerManageComboBox.Items.Add("- Select Server -");

                // Add Servers
                foreach (Server server in ClientSettings.SavedServers)
                {
                    ServerComboBox.Items.Add(server);
                    ServerManageComboBox.Items.Add(server);
                }

                // Set Launch Tab selected server
                if (launchSelectedServer == null)
                    ServerComboBox.SelectedIndex = 0;
                else
                    ServerComboBox.SelectedItem = launchSelectedServer;

                // Set Manage selected server
                if (manageSelectedServer == null)
                    ServerManageComboBox.SelectedIndex = 0;
                else
                    ServerManageComboBox.SelectedItem = manageSelectedServer;

            }
            catch
            {
                throw;
            }
            finally
            {
                // Make sure to alway Re-register for events
                if (!CallEvents)
                    ServerComboBox.SelectedIndexChanged += ServerComboBox_SelectedIndexChanged;
            }
        }

        /// <summary>
        /// Clears the Provider Combo boxes and refills them with the list of servers
        /// </summary>
        /// <param name="selectedProvider">The selected provider, if any, from the Launch tab</param>
        /// <param name="CallEvents">Indicates whether we call the "SelectedIndexChanged" events</param>
        private void ReloadProviders(ServiceProvider selectedProvider = null, bool CallEvents = true)
        {
            // If we are NOT calling events for this, unregister
            if (!CallEvents)
                ProviderComboBox.SelectedIndexChanged -= ProviderComboBox_SelectedIndexChanged;

            try
            {
                // Clear out the old servers list
                ProviderComboBox.Items.Clear();
                ProviderComboBox.Items.Add("- None -");
                ProviderManageComboBox.Items.Clear();
                ProviderManageComboBox.Items.Add("- Select Provider -");

                // Add
                foreach (ServiceProvider provider in ClientSettings.ServiceProviders)
                {
                    ProviderComboBox.Items.Add(provider);
                    ProviderManageComboBox.Items.Add(provider);
                }

                // Set selects
                if (selectedProvider == null)
                {
                    ProviderComboBox.SelectedIndex = 0;
                    ProviderManageComboBox.SelectedIndex = 0;
                }
                else
                {
                    ProviderComboBox.SelectedItem = selectedProvider;
                    ProviderManageComboBox.SelectedItem = selectedProvider;
                }
            }
            finally
            {
                // Make sure to alway Re-register for events
                if (!CallEvents)
                    ProviderComboBox.SelectedIndexChanged += ProviderComboBox_SelectedIndexChanged;
            }
        }

        /// <summary>
        /// Event fired when the Launch Battlefield 2 button is pushed on the Launcher Tab
        /// </summary>
        private async void LaunchButton_Click(object sender, EventArgs args)
        {
            // Lock button to prevent spam
            LaunchButton.Enabled = false;

            // Close the app
            if (BF2Client.IsRunning)
            {
                BF2Client.Stop();
                return;
            }

            // Show overlay first, which provides the smokey (Modal) background
            using (ModalOverlay overlay = new ModalOverlay(this, 0.3))
            {
                // Show overlay
                overlay.Show(this);

                // Make sure a mod is selected
                if (ModComboBox.SelectedIndex < 1)
                {
                    MetroMessageBox.Show(overlay,
                        "Please select a Bf2 Mod before attempting to start the game!",
                        "No Mod Selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 150
                    );
                    overlay.Close();

                    // Reset button
                    BF2Client_Exited();

                    // Focus the mod select
                    ModComboBox.Focus();
                    return;
                }

                // Grab our mod and provider
                BF2Mod Mod = ModComboBox.SelectedItem as BF2Mod;
                ServiceProvider Provider = ProviderComboBox.SelectedItem as ServiceProvider;
                Server Server = ServerComboBox.SelectedItem as Server;

                // Remove old redirects
                Redirector.RemoveRedirects();

                // If we arent using a provider, skip to just launching the game
                if (Provider == null)
                    goto StartClient;

                // Apply redirects in a new thread
                SyncProgress<TaskStep> MyProgress = new SyncProgress<TaskStep>(RedirectStatusUpdate);
                bool Success = await Redirector.ApplyRedirectsAsync(Provider, MyProgress);
                if (!Success)
                {
                    // Show error
                    MetroMessageBox.Show(overlay, ErrorStep.Description, "Redirect Error", MessageBoxButtons.OK, MessageBoxIcon.Error, 180);
                    overlay.Close();

                    // Reset button
                    BF2Client_Exited();
                    return;
                }

                // Show the Task Form
                TaskForm.Show(this, "Launching Battlefield 2", $"Starting Battlefield 2 with mod \"{Mod.Title}\"", false, ProgressBarStyle.Marquee, 0);

                // Our goto to start the game
                StartClient:
                {
                    try
                    {
                        // ===
                        // ALWAYS Remove all temporary keys before this next point
                        // ===
                        Params.Reload(LaunchParamsTextBox.Text);
                        Params.ClearTempParams();

                        // If we are auto joining a server, we must login!
                        if (Provider != null && (Server != null || CredentialsCheckBox.Checked))
                        {
                            // Prompt user to login!
                            using (LoginForm f = new LoginForm(Provider))
                            {
                                DialogResult Res = f.ShowDialog(overlay);
                                if (Res == DialogResult.Cancel)
                                {
                                    // Reset button
                                    TaskForm.CloseForm();
                                    BF2Client_Exited();
                                    return;
                                }

                                // Set server params
                                if (Server != null)
                                {
                                    Params.AddOrSet("joinServer", Server.Address);
                                    Params.AddOrSet("port", Server.Port.ToString());
                                }

                                // Set login params
                                Params.AddOrSet("playerName", f.UsernameTextBox.Text);
                                Params.AddOrSet("playerPassword", f.PasswordTextBox.Text);
                            }
                        }

                        // Start the client executable
                        BF2Client.Start(Mod, Params.BuildString(true));
                    }
                    catch (Exception e)
                    {
                        // Show error
                        MetroMessageBox.Show(overlay, e.Message, "Failure to Launch", MessageBoxButtons.OK, MessageBoxIcon.Error, 180);
                        BF2Client_Exited();
                    }
                }

                // Close the task form
                TaskForm.CloseForm();

                // Close Task form and overlay
                using (RunningOverlay = new GameRunningForm(this))
                {
                    RunningOverlay.ShowDialog(overlay);
                }
                   
                // Close Overlay
                overlay.Close();
                LaunchButton.Focus();
            }
        }

        private void RedirectStatusUpdate(TaskStep obj)
        {
            if (obj.IsFaulted)
            {
                ErrorStep = obj;
            }
        }

        /// <summary>
        /// Event fired when the Create button is pushed on the Service Providers Tab
        /// </summary>
        private void CreateProviderButton_Click(object sender, EventArgs e) => ShowProviderEditor();

        /// <summary>
        /// Event fired when the Edit button is pushed on the Service Providers Tab
        /// </summary>
        private void EditProviderButton_Click(object sender, EventArgs e)
        {
            if (ProviderManageComboBox.SelectedIndex == 0)
                return;

            ServiceProvider provider = (ServiceProvider)ProviderManageComboBox.SelectedItem;
            ShowProviderEditor(provider);
        }

        /// <summary>
        /// Event fired when the CRemove button is pushed on the Service Providers Tab
        /// </summary>
        private void RemoveProviderButton_Click(object sender, EventArgs e)
        {
            // Make sure we have am item selected
            if (ProviderManageComboBox.SelectedIndex == 0)
                return;

            // Remove
            ClientSettings.ServiceProviders.RemoveAt(ProviderManageComboBox.SelectedIndex - 1);
            ProviderComboBox.Items.Clear();
            ProviderManageComboBox.Items.Clear();
            ClientSettings.Save();

            // Reload comboboxes
            ReloadProviders();
        }

        /// <summary>
        /// Event fired when the Create button is pushed on the Multiplayer Tab
        /// </summary>
        private void CreateServerButton_Click(object sender, EventArgs e) => ShowServerEditor();

        /// <summary>
        /// Event fired when the Edit button is pushed on the Multiplayer Tab
        /// </summary>
        private void EditServerButton_Click(object sender, EventArgs e)
        {
            if (ServerManageComboBox.SelectedIndex == 0)
                return;

            Server server = (Server)ServerManageComboBox.SelectedItem;
            ShowServerEditor(server);
        }

        /// <summary>
        /// Event fired when the Remove button is pushed on the Multiplayer Tab
        /// </summary>
        private void RemoveServerButton_Click(object sender, EventArgs e)
        {
            // Make sure we have am item selected
            if (ServerManageComboBox.SelectedIndex == 0)
                return;

            // Remove
            ClientSettings.SavedServers.RemoveAt(ServerManageComboBox.SelectedIndex - 1);
            ServerComboBox.Items.Clear();
            ServerManageComboBox.Items.Clear();
            ClientSettings.Save();

            // Reload comboboxes
            ReloadServers();
        }

        /// <summary>
        /// Shows the Server Editor form
        /// </summary>
        /// <param name="selectedServer"></param>
        private void ShowServerEditor(Server selectedServer = null)
        {
            // Show overlay first, which provides the smokey (Modal) background
            using (ModalOverlay overlay = new ModalOverlay(this))
            using (ServerEditorForm f = new ServerEditorForm(selectedServer))
            {
                overlay.Show(this);
                DialogResult Res = f.ShowDialog(overlay);
                if (Res == DialogResult.OK)
                {
                    if (selectedServer == null)
                    {
                        Server server = ClientSettings.SavedServers.Last();
                        ServerComboBox.Items.Add(server);
                        ServerManageComboBox.Items.Add(server);
                        ServerManageComboBox.SelectedIndex = ServerManageComboBox.Items.Count - 1;
                    }
                    else
                    {
                        ServerAddressLabel.Text = selectedServer.Address;
                        ServerPortLabel.Text = selectedServer.Port.ToString();
                        ServerProviderLabel.Text = selectedServer.Provider;
                    }

                    // Reload comboboxes
                    ReloadServers(null, selectedServer);
                }

                overlay.Close();
            }

            // Bring back focus to this form
            this.Focus();
        }

        /// <summary>
        /// Shows the Provider editor form
        /// </summary>
        /// <param name="selectedProvider"></param>
        private void ShowProviderEditor(ServiceProvider selectedProvider = null)
        {
            // Show overlay first, which provides the smokey (Modal) background
            using (ModalOverlay overlay = new ModalOverlay(this))
            using (ProviderEditorForm f = new ProviderEditorForm(selectedProvider))
            {
                overlay.Show(this);
                DialogResult Res = f.ShowDialog(overlay);
                if (Res == DialogResult.OK)
                {
                    if (selectedProvider == null)
                    {
                        selectedProvider = ClientSettings.ServiceProviders.Last();
                        ProviderComboBox.Items.Add(selectedProvider);
                        ProviderManageComboBox.Items.Add(selectedProvider);
                        ProviderManageComboBox.SelectedIndex = ProviderManageComboBox.Items.Count - 1;
                    }

                    // Reload comboboxes
                    ReloadProviders(selectedProvider);
                }

                overlay.Close();
            }

            // Bring back focus to this form
            this.Focus();
        }

        /// <summary>
        /// Event fired when the select provider is changed on the Launcher Tab
        /// </summary>
        private async void ProviderComboBox_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (ProviderComboBox.SelectedIndex == 0)
            {
                // Prompt the user to select a provider again
                ProviderServicePic.Image = Resources.warning;
                ProviderLabel.Text = "Please select a provider...";

                // Reset our list of servers if our count is off!
                if (ServerComboBox.Items.Count != ClientSettings.SavedServers.Count)
                {
                    // Remove old items
                    ServerComboBox.Items.Clear();
                    ServerComboBox.Items.Add("- None -");

                    // Add each server
                    foreach (Server server in ClientSettings.SavedServers)
                        ServerComboBox.Items.Add(server);

                    // Reset index
                    ServerComboBox.SelectedIndex = 0;
                }

                return;
            }

            // Grab our users selections
            ServiceProvider Provider = ProviderComboBox.SelectedItem as ServiceProvider;
            Server selectedServer = (ServerComboBox.SelectedIndex == 0) ? null : ServerComboBox.SelectedItem as Server;

            // Update the GUI
            ProviderServicePic.Image = Resources.loading;
            ProviderLabel.Text = "Checking Service...";

            // Fetch the service ASP and verify its valid and online
            try
            {
                ProviderComboBox.Enabled = false;
                await Networking.ValidateASPServiceAsync("http://" + Provider.StatsAddress);

                // If we are here, the ASP service is OK
                ProviderServicePic.Image = Resources.check;
                ProviderLabel.Text = "Service is Online";
            }
            catch //(Exception e)
            {
                // Update the GUI
                ProviderServicePic.Image = Resources.error;
                ProviderLabel.Text = "Service Invalid or Offline";
            }

            // Clear out the old servers list
            ServerComboBox.SelectedIndexChanged -= ServerComboBox_SelectedIndexChanged;
            ServerComboBox.Items.Clear();
            ServerComboBox.Items.Add("- None -");
            ServerComboBox.SelectedIndex = 0;

            // Add provider servers
            IEnumerable<Server> servers = (from x in ClientSettings.SavedServers where x.Provider == Provider.Name select x);
            foreach (Server server in servers)
            {
                ServerComboBox.Items.Add(server);
                if (selectedServer == server)
                    ServerComboBox.SelectedIndex = ServerComboBox.Items.Count - 1;
            }

            // Sign back up for events
            ProviderComboBox.Enabled = true;
            ServerComboBox.SelectedIndexChanged += ServerComboBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Event fired when the Server is changed on the Launcher Tab
        /// </summary>
        private void ServerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure we have an item selected
            if (ServerComboBox.SelectedIndex == 0)
                return;

            // Grab our selected server
            Server selectedServer = ServerComboBox.SelectedItem as Server;

            // Try and fetch the provider service
            ServiceProvider Provider = (
                from x in ClientSettings.ServiceProviders
                where x.Name == selectedServer.Provider
                select x
            ).FirstOrDefault();

            // Can't find the provider? Uh-oh..
            if (Provider == null)
            {
                // Show overlay first, which provides the smokey (Modal) background
                using (ModalOverlay overlay = new ModalOverlay(this, 0.2))
                {
                    overlay.Show(this);
                    DialogResult Res = MetroMessageBox.Show(overlay,
                        "The selected Service Provider for this server does not exist in the list of Service Providers you have configured! "
                        + "Please update the server or add the Service Provider for this server to prevent future errors. Would you like me "
                        + "to remove the Service Provider entry for this server?",
                        "Provider Not Found", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning, 175
                    );

                    // If the user wants us to remove the provider entry
                    if (Res == DialogResult.Yes)
                    {
                        selectedServer.Provider = "";
                        ClientSettings.Save();
                    }
                }

                // Focus the mainform again
                this.Focus();
            }
            else
            {
                ProviderComboBox.SelectedIndexChanged -= ProviderComboBox_SelectedIndexChanged;
                ProviderComboBox.SelectedItem = Provider;
                ProviderComboBox.SelectedIndexChanged += ProviderComboBox_SelectedIndexChanged;
            }
        }

        /// <summary>
        /// Event fired when the selected Mod is changed on the Launcher Tab
        /// </summary>
        private void ModComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModComboBox.SelectedIndex == 0)
            {
                ModStatusPic.Image = Resources.warning;
                ModLabel.Text = (BF2Client.Mods.Count == 0) ? "No Mods Available!" : "Please select a mod...";
                return;
            }

            ModStatusPic.Image = Resources.check;
            ModLabel.Text = "Mod Selected";
        }

        /// <summary>
        /// Event fired when the Server is changed on the Multiplayer Tab
        /// </summary>
        private void ServerManageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset info fields
            if (ServerManageComboBox.SelectedIndex == 0)
            {
                ServerAddressLabel.Text = "";
                ServerPortLabel.Text = "";
                ServerProviderLabel.Text = "";
                RemoveServerButton.Enabled = false;
                EditServerButton.Enabled = false;
                return;
            }

            // Set default texts
            Server server = (Server)ServerManageComboBox.SelectedItem;
            ServerAddressLabel.Text = server.Address;
            ServerPortLabel.Text = server.Port.ToString();
            ServerProviderLabel.Text = server.Provider;

            // Enable buttons
            RemoveServerButton.Enabled = true;
            EditServerButton.Enabled = true;
        }

        /// <summary>
        /// Event fired when the select provider is changed on the Service Providers Tab
        /// </summary>
        private void ProviderManageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset info fields
            if (ProviderManageComboBox.SelectedIndex == 0)
            {
                RemoveProviderButton.Enabled = false;
                EditProviderButton.Enabled = false;
                return;
            }

            // Enable buttons
            RemoveProviderButton.Enabled = true;
            EditProviderButton.Enabled = true;
        }

        /// <summary>
        /// Event fired when the Change Button is pushed on the App Settings Tab
        /// </summary>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            using (ModalOverlay overlay = new ModalOverlay(this, 0.2))
            {
                overlay.Show(this);
                string OrigLocation = Program.Config.Bf2InstallDir;
                if (SetupManager.ShowInstallForm(overlay))
                {
                    // Load the BF2 Server
                    try
                    {
                        BF2Client.SetInstallPath(Program.Config.Bf2InstallDir);
                    }
                    catch (Exception E)
                    {
                        MetroMessageBox.Show(this, E.Message, "Battlefield 2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.Config.Bf2InstallDir = OrigLocation;
                        Program.Config.Save();
                    }
                }
                overlay.Close();
            }

            this.Focus();
        }

        private void IcsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // If we arent selected, return
            if (!IcsRadioButton.Checked) return;

            Program.Config.RedirectMode = RedirectMode.HostsIcsFile;
            RedirectDescLabel.Text = "Enabling this option will create and use the hosts.ics file. This is a better option "
                + "then using the system HOSTS file because Battlefield 2 will not check the hosts.ics file  for gamespy redirects";

            RedirectDescLabel.Focus();
        }

        private void HostsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // If we arent selected, return
            if (!HostsRadioButton.Checked) return;

            Program.Config.RedirectMode = RedirectMode.HostsFile;
            RedirectDescLabel.Text = "By enabling this option, this program will attempt to store the Gamespy redirects inside the system HOSTS file. "
                + "Battlefield 2 will check the hosts file for Gamespy redirects, so we must also remove READ permissions to prevent this. "
                + "This option should be used as a last resort, since removing READ permissions from the HOSTS file can cause Windows DNS server "
                + "to undo the gamespy redirects when it refreshes itself.";

            RedirectDescLabel.Focus();
        }

        private void DnsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // If we arent selected, return
            if (!DnsRadioButton.Checked) return;

            Program.Config.RedirectMode = RedirectMode.DnsServer;
            RedirectDescLabel.Text = "This option is for advanced users that have setup a DNS server on their machine to automatically redirect "
                + "Gamespy services to a configured Ip address.";

            RedirectDescLabel.Focus();
        }

        private void LaunchParamsButton_Click(object sender, EventArgs e)
        {
            // Reload any changes in the params box
            Params.Reload(LaunchParamsTextBox.Text);

            // Display params editor
            using (LaunchParamsForm f = new LaunchParamsForm(Params))
            using (ModalOverlay overlay = new ModalOverlay(this))
            {
                overlay.Show(this);
                DialogResult Res = f.ShowDialog(overlay);
                if (Res == DialogResult.OK)
                    LaunchParamsTextBox.Text = Params.BuildString(false);

                overlay.Close();
            }

            LaunchButton.Focus();
        }

        /// <summary>
        /// Event fires when the form is closing
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // === Apply Config Settings === //
            if (AppExitsRadioButton.Checked)
            {
                // Set redirect settings
                Program.Config.RedirectRemoveMethod = RedirectRemoveMethod.OnAppClose;
                if (Redirector.RedirectsEnabled)
                    Redirector.RemoveRedirects();
            }
            else
            {
                // Set redirect settings
                Program.Config.RedirectRemoveMethod = (Bf2ExitsRadioButton.Checked)
                    ? RedirectRemoveMethod.OnGameClose
                    : RedirectRemoveMethod.Never;
            }

            // Save Config
            Program.Config.LaunchParams = Params.BuildString(false);
            Program.Config.PromptCredentials = CredentialsCheckBox.Checked;
            Program.Config.CheckForUpdates = ProgramUpdateCheckBox.Checked;
            Program.Config.Save();
            e.Cancel = false;
        }

        private void ReportIssueButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/BF2Statistics/BF2GamespyRedirector/issues");
        }
    }
}
