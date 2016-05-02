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
    public partial class LaunchParamsForm : Form
    {
        public ParamsCollection Params;

        public LaunchParamsForm(ParamsCollection Params)
        {
            // Create form controls
            InitializeComponent();

            // Set form colors
            this.BackColor = Color.FromArgb(255, 255, 255);
            groupBox1.BackColor = Color.FromArgb(255, 255, 255);
            groupBox2.BackColor = Color.FromArgb(255, 255, 255);

            // Load a params container
            this.Params = Params;
            foreach (KeyValuePair<string, string> Param in Params.Collection)
            {
                switch (Param.Key.ToLowerInvariant())
                {
                    case "fullscreen":
                        WindowedMode.Checked = (Param.Value == "0");
                        break;
                    case "szy":
                        HeightText.Text = Param.Value;
                        CustomRes.Checked = true;
                        break;
                    case "szx":
                        WidthText.Text = Param.Value;
                        CustomRes.Checked = true;
                        break;
                    case "restart":
                        Restart.Checked = (Param.Value == "1");
                        break;
                    case "disableswiff":
                        DisableSwiff.Checked = (Param.Value == "1");
                        break;
                    case "nosound":
                        NoSound.Checked = (Param.Value == "1");
                        break;
                    case "lowpriority":
                        LowPriority.Checked = (Param.Value == "1");
                        break;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Window Mode
            Params.AddOrSet("fullscreen", WindowedMode.Checked ? "0" : "1");

            // Custom Resolution
            if (CustomRes.Checked)
            {
                Params.AddOrSet("szx", WidthText.Text);
                Params.AddOrSet("szy", HeightText.Text);
            }
            else
            {
                Params.Remove("szx");
                Params.Remove("syx");
            }

            // Skip Intro Movies
            if (Restart.Checked)
                Params.AddOrSet("restart", Restart.Checked ? "1" : "0");
            else
                Params.Remove("restart");

            // Swiff Player
            if (DisableSwiff.Checked)
                Params.AddOrSet("disableSwiff", DisableSwiff.Checked ? "1" : "0");
            else
                Params.Remove("disableSwiff");

            // No sound mode
            if (NoSound.Checked)
                Params.AddOrSet("noSound", NoSound.Checked ? "1" : "0");
            else
                Params.Remove("noSound");

            // Low Priority
            if (LowPriority.Checked)
                Params.AddOrSet("lowPriority", LowPriority.Checked ? "1" : "0");
            else
                Params.Remove("lowPriority");

            // Save Config
            Program.Config.LaunchParams = Params.BuildString(false);
            Program.Config.Save();
            this.DialogResult = DialogResult.OK;
        }

        private void CustomRes_CheckedChanged(object sender, EventArgs e)
        {
            HeightText.Enabled = CustomRes.Checked;
            WidthText.Enabled = CustomRes.Checked;
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
