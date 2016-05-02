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

namespace BF2GamespyRedirector
{
    public partial class LoginForm : Form
    {
        public LoginForm(ServiceProvider Provider)
        {
            // Create form controls
            InitializeComponent();

            // Set control colors
            this.BackColor = Color.FromArgb(1, 64, 81);
            ProviderNameLabel.Text = Provider?.Name ?? "<none>";
            metroLabel1.BackColor = Color.FromArgb(1, 64, 81);
            metroLabel2.BackColor = Color.FromArgb(1, 64, 81);
            metroLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            metroLabel2.ForeColor = Color.FromArgb(255, 255, 255);
            ProviderNameLabel.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Dont allow an empty username
            if (String.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                UsernameTextBox.WithError = true;
                return;
            }

            this.DialogResult = DialogResult.OK;
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
            LoginButton.Focus();
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
