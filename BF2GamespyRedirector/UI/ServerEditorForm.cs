using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BF2GamespyRedirector.Properties;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace BF2GamespyRedirector
{
    public partial class ServerEditorForm : Form
    {
        /// <summary>
        /// Internally tracks input field errors (form validation)
        /// </summary>
        protected bool HasInputErrors = false;

        /// <summary>
        /// If we are editing a server, this is where we store it
        /// </summary>
        protected Server SelectedServer;

        public ServerEditorForm(Server selectedServer)
        {
            // Create form controls
            InitializeComponent();

            // Set window colors... Hard to design in editor with these, so we set at runtime!
            panel1.BackColor = Color.FromArgb(57, 179, 215);
            ServerNameLabel.ForeColor = Color.WhiteSmoke;
            AddressLabel.ForeColor = Color.WhiteSmoke;
            ServerLabel.ForeColor = Color.WhiteSmoke;
            ServiceLabel.ForeColor = Color.WhiteSmoke;

            // Add providers
            foreach (ServiceProvider provider in ClientSettings.ServiceProviders)
                ProviderComboBox.Items.Add(provider);

            // Set default provider index
            ProviderComboBox.SelectedIndex = 0;

            // Fill server info if we are editing
            if (selectedServer != null)
            {
                SelectedServer = selectedServer;
                ServerNameTextBox.Text = selectedServer.Name;
                AddressTextBox.Text = selectedServer.Address;
                PortTextBox.Text = selectedServer.Port.ToString();

                // get provider index
                if (!String.IsNullOrWhiteSpace(selectedServer.Provider))
                {
                    ProviderComboBox.SelectedIndex = (
                        from x in ClientSettings.ServiceProviders
                        where x.Name == selectedServer.Provider
                        select ClientSettings.ServiceProviders.IndexOf(x) + 1
                    ).FirstOrDefault();
                }
            }
            else
                PortTextBox.Text = "16567";
        }

        /// <summary>
        /// Event fired when the Save button is pressed
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Revalidate all data
            HasInputErrors = false;
            CancelEventArgs Args = new CancelEventArgs();
            PortTextBox_Validating(PortTextBox, Args);
            ServerNameTextBox_Validating(ServerNameTextBox, Args);
            AddressTextBox_Validating(AddressTextBox, Args);

            // If we have input errors, just quit
            if (HasInputErrors) return;

            // New server?
            if (SelectedServer == null)
            {
                ClientSettings.SavedServers.Add(new Server()
                {
                    Name = ServerNameTextBox.Text,
                    Address = AddressTextBox.Text,
                    Port = ushort.Parse(PortTextBox.Text),
                    Provider = (ProviderComboBox.SelectedIndex == 0)
                        ? ""
                        : ((ServiceProvider)ProviderComboBox.SelectedItem).Name
                });
            }
            else
            {
                SelectedServer.Name = ServerNameTextBox.Text;
                SelectedServer.Address = AddressTextBox.Text;
                SelectedServer.Port = ushort.Parse(PortTextBox.Text);
                SelectedServer.Provider = (ProviderComboBox.SelectedIndex == 0)
                    ? ""
                    : ((ServiceProvider)ProviderComboBox.SelectedItem).Name;
            }

            // Save the server changes
            ClientSettings.Save();

            // Close the form with an OK
            this.DialogResult = DialogResult.OK;
        }

        private void PortTextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

            MetroTextBox textBox = (MetroTextBox)sender;
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                HasInputErrors = true;
                textBox.WithError = true;
                metroToolTip1.SetToolTip(textBox, "Please enter a port number!");
                return;
            }

            ushort port;
            if (!ushort.TryParse(textBox.Text, out port) || !port.InRange(0, 65536))
            {
                HasInputErrors = true;
                textBox.WithError = true;
                metroToolTip1.SetToolTip(textBox, "   Please enter a valid port number between 0 and 65536!    ");
                return;
            }
        }

        private void ServerNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            MetroTextBox textBox = (MetroTextBox)sender;
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                HasInputErrors = true;
                textBox.WithError = true;
                metroToolTip1.SetToolTip(textBox, "Please enter a Name for your Server!");
                return;
            }
        }

        private void AddressTextBox_Validating(object sender, CancelEventArgs e)
        {
            MetroTextBox textBox = (MetroTextBox)sender;
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                HasInputErrors = true;
                textBox.WithError = true;
                metroToolTip1.SetToolTip(textBox, "     Please enter the Server's address! This can be a hostname or IpAddress      ");
                return;
            }
        }

        #region Window Animation

        public const int AW_ACTIVATE = 0x20000;
        public const int AW_HIDE = 0x10000;
        public const int AW_BLEND = 0x80000;
        public const int AW_CENTER = 0x00000010;
        public const int AW_SLIDE = 0X40000;
        public const int AW_HOR_POSITIVE = 0x1;
        public const int AW_HOR_NEGATIVE = 0X2;

        private bool _UseSlideAnimation = true;

        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AnimateWindow(this.Handle, 200, AW_ACTIVATE | (_UseSlideAnimation ? AW_HOR_NEGATIVE | AW_SLIDE : AW_BLEND));
            SaveButton.Focus();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closing"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (e.Cancel == false)
            {
                _UseSlideAnimation = false;
                AnimateWindow(this.Handle, 200, AW_HIDE | (_UseSlideAnimation ? AW_HOR_POSITIVE | AW_SLIDE : AW_BLEND));
            }
        }

        #endregion
    }
}
