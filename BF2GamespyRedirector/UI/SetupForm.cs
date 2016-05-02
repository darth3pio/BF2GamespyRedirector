using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Win32;

namespace BF2GamespyRedirector
{
    public partial class SetupForm : MetroForm
    {
        /// <summary>
        /// The installation path for the bf2 client
        /// </summary>
        protected string ClientInstallPath = "";

        public SetupForm(Form parent)
        {
            // Create form controls
            InitializeComponent();

            // Set theme
            metroStyleManager1.Theme = MetroThemeStyle.Light;
            metroStyleManager1.Style = MetroColorStyle.Blue;

            // Configure parent data
            if (parent != null)
            {
                //this.Width = parent.Width;
                this.StartPosition = FormStartPosition.CenterParent;
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
            }

            // Check for BF2 Client Installation (32 bit)
            try
            {
                ClientInstallPath = Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Battlefield 2",
                    "InstallDir",
                    String.Empty).ToString();
                InstallDirTextbox.Text = ClientInstallPath;
            }
            catch (IOException) // Entry Doesnt Exist, Try 64 Bit Installation
            {
                try
                {
                    ClientInstallPath = Registry.GetValue(
                        @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Electronic Arts\EA Games\Battlefield 2",
                        "InstallDir",
                        String.Empty).ToString();
                    InstallDirTextbox.Text = ClientInstallPath;
                }
                catch { }
            }
            catch { }
        }

        /// <summary>
        /// Event fired when the Client Path button is clicked... Opens the Dialog to select
        /// the Client executable
        /// </summary>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.FileName = "bf2.exe";
            Dialog.Filter = "BF2 Executable|bf2.exe";

            // Set the initial search directory if we found an install path via registry
            if (!String.IsNullOrWhiteSpace(ClientInstallPath))
                Dialog.InitialDirectory = ClientInstallPath;

            if (Dialog.ShowDialog() == DialogResult.OK)
                InstallDirTextbox.Text = Path.GetDirectoryName(Dialog.FileName);
        }

        /// <summary>
        /// Event fired when the Save button is clicked
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Make sure the server path is not empty
            if (String.IsNullOrWhiteSpace(InstallDirTextbox.Text))
            {
                MetroMessageBox.Show(this, 
                    "You must set the server path before proceeding.", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning, 
                    160
                );
                return;
            }

            // Make sure the bf2.exe exists
            if (!File.Exists(Path.Combine(InstallDirTextbox.Text, "bf2.exe")))
            {
                MetroMessageBox.Show(this, 
                    "Invalid battlefield 2 installtion path provided! Please try again.", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error, 
                    160
                );
                return;
            }

            // Save config
            Program.Config.Bf2InstallDir = InstallDirTextbox.Text;
            Program.Config.Save();

            // Tell the main form we are OK
            this.DialogResult = DialogResult.OK;
        }
    }
}
