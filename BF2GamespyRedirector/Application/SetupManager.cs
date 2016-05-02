using System;
using System.IO;
using System.Windows.Forms;
using BF2GamespyRedirector.Properties;
using MetroFramework;

namespace BF2GamespyRedirector
{
    public static class SetupManager
    {
        /// <summary>
        /// Entry point... this will check if we are at the initial setup
        /// phase, and show the installation forms
        /// </summary>
        /// <returns>Returns false if the user cancels the setup before the basic settings are setup, true otherwise</returns>
        public static bool Run()
        {
            // Load the program config
            Settings Config = Settings.Default;

            // If this is the first time running a new update, we need to update the config file
            if (!Config.SettingsUpdated)
            {
                Config.Upgrade();
                Config.SettingsUpdated = true;
                Config.Save();
            }

            // If this is the first run, Get client and server install paths
            if (String.IsNullOrWhiteSpace(Config.Bf2InstallDir) || !File.Exists(Path.Combine(Config.Bf2InstallDir, "bf2.exe")))
            {
                TraceLog.WriteLine("Empty or Invalid BF2 directory detected, running Install Form.");
                if (!ShowInstallForm())
                    return false;
            }

            // Create the "My Documents/BF2Statistics" folder
            try
            {
                // Make sure documents folder exists
                if (!Directory.Exists(Program.DocumentsFolder))
                    Directory.CreateDirectory(Program.DocumentsFolder);
            }
            catch (Exception E)
            {
                // Alert the user that there was an error
                MessageBox.Show("We encountered an error trying to create the required \"My Documents/BF2Statistics\" folder!"
                    + Environment.NewLine.Repeat(1) + E.Message,
                    "Setup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Load server go.. If we fail to load a valid server, we will come back to here
            LoadClient:
            {
                // Load the BF2 Server
                try
                {
                    BF2Client.SetInstallPath(Config.Bf2InstallDir);
                }
                catch (Exception E)
                {
                    MetroMessageBox.Show(Form.ActiveForm, E.Message, "Battlefield 2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Re-prompt
                    if (!ShowInstallForm())
                        return false;

                    goto LoadClient;
                }
            }

            return true;
        }

        /// <summary>
        /// Displays the Install / Program configuration form
        /// </summary>
        /// <returns>Returns whether the config was saved, false otherwise</returns>
        public static bool ShowInstallForm(Form parent = null)
        {
            // Try and get the active form
            if (parent == null) parent = Form.ActiveForm;

            using (SetupForm IS = new SetupForm(parent))
            {
                DialogResult Res = (parent == null) ? IS.ShowDialog() : IS.ShowDialog(parent);
                return (Res == DialogResult.OK);
            }
        }
    }
}
