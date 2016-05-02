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
using MetroFramework.Controls;

namespace BF2GamespyRedirector
{
    public partial class ProviderEditorForm : Form
    {
        /// <summary>
        /// Internally tracks input field errors (form validation)
        /// </summary>
        protected bool HasInputErrors = false;

        /// <summary>
        /// If we are editing a provider, this is where we store it
        /// </summary>
        protected ServiceProvider SelectedProvider;

        public ProviderEditorForm(ServiceProvider selectedProvider = null)
        {
            // Create form controls
            InitializeComponent();

            // Set window colors... Hard to design in editor with these, so we set at runtime!
            panel1.BackColor = Color.FromArgb(57, 179, 215);
            ServerNameLabel.ForeColor = Color.WhiteSmoke;
            AddressLabel.ForeColor = Color.WhiteSmoke;
            ServerLabel.ForeColor = Color.WhiteSmoke;

            // Fill provider info if we are editing
            if (selectedProvider != null)
            {
                SelectedProvider = selectedProvider;
                NameTextBox.Text = selectedProvider.Name;
                StatsTextBox.Text = selectedProvider.StatsAddress;
                GamespyTextBox.Text = selectedProvider.GamespyAddress;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Disable buttons
            HasInputErrors = false;
            SaveButton.Enabled = false;

            // Validate each field
            CancelEventArgs Args = new CancelEventArgs();
            NameTextBox_Validating(NameTextBox, Args);
            ValidateAddress(StatsTextBox, Args);
            ValidateAddress(GamespyTextBox, Args);

            // Enable button and check validations
            SaveButton.Enabled = true;
            if (HasInputErrors)
            {
                return;
            }

            // New server?
            if (SelectedProvider == null)
            {
                ClientSettings.ServiceProviders.Add(new ServiceProvider()
                {
                    Name = NameTextBox.Text,
                    StatsAddress = StatsTextBox.Text,
                    GamespyAddress = GamespyTextBox.Text
                });
            }
            else
            {
                SelectedProvider.Name = NameTextBox.Text;
                SelectedProvider.StatsAddress = StatsTextBox.Text;
                SelectedProvider.GamespyAddress = GamespyTextBox.Text;
            }

            // Save the server changes
            ClientSettings.Save();

            // Close the form with an OK
            this.DialogResult = DialogResult.OK;
        }

        private void NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            // Dont allow an empty username
            if (String.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                HasInputErrors = true;
                NameTextBox.WithError = true;
                metroToolTip1.SetToolTip(NameTextBox, " Please enter a name ! ");
                return;
            }

            // Define Comparer
            StringComparison Comparer = StringComparison.InvariantCultureIgnoreCase;

            // Name already exists
            if (SelectedProvider?.Name.Equals(NameTextBox.Text, Comparer) ?? false)
                return;

            // Check to see if we have a provider with this name
            ServiceProvider Exists = ClientSettings.ServiceProviders.Where(
                x => x.Name.Equals(NameTextBox.Text, Comparer))
            .FirstOrDefault();

            // If we have a provider here, then yea...
            if (Exists != null)
            {
                HasInputErrors = true;
                NameTextBox.WithError = true;
                metroToolTip1.SetToolTip(NameTextBox, "  A Provider with this name already exists!  ");
                return;
            }

            NameTextBox.WithError = false;
        }

        private void ValidateAddress(object sender, CancelEventArgs e)
        {
            MetroTextBox Box = (MetroTextBox)sender;

            // Validate Hostname or IP (Yes this works for both!)
            UriHostNameType Type = Uri.CheckHostName(Box.Text);
            if (Type == UriHostNameType.Unknown)
            {
                HasInputErrors = true;
                metroToolTip1.SetToolTip(Box, "  Invalid hostname or IPAddress provided.  ");
                Box.WithError = true;
                return;
            }

            Box.WithError = false;
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
