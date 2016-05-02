namespace BF2GamespyRedirector
{
    partial class SetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ChangeButton = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.InstallDirTextbox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.SaveButton = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeButton
            // 
            this.ChangeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChangeButton.Image = null;
            this.ChangeButton.Location = new System.Drawing.Point(344, 186);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(104, 23);
            this.ChangeButton.TabIndex = 8;
            this.ChangeButton.Text = "Change Path";
            this.ChangeButton.UseSelectable = true;
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // InstallDirTextbox
            // 
            this.InstallDirTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.InstallDirTextbox.CustomButton.Image = null;
            this.InstallDirTextbox.CustomButton.Location = new System.Drawing.Point(394, 1);
            this.InstallDirTextbox.CustomButton.Name = "";
            this.InstallDirTextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.InstallDirTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.InstallDirTextbox.CustomButton.TabIndex = 1;
            this.InstallDirTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.InstallDirTextbox.CustomButton.UseSelectable = true;
            this.InstallDirTextbox.CustomButton.Visible = false;
            this.InstallDirTextbox.Lines = new string[0];
            this.InstallDirTextbox.Location = new System.Drawing.Point(32, 157);
            this.InstallDirTextbox.MaxLength = 32767;
            this.InstallDirTextbox.Name = "InstallDirTextbox";
            this.InstallDirTextbox.PasswordChar = '\0';
            this.InstallDirTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.InstallDirTextbox.SelectedText = "";
            this.InstallDirTextbox.SelectionLength = 0;
            this.InstallDirTextbox.SelectionStart = 0;
            this.InstallDirTextbox.Size = new System.Drawing.Size(416, 23);
            this.InstallDirTextbox.TabIndex = 7;
            this.InstallDirTextbox.UseSelectable = true;
            this.InstallDirTextbox.WaterMark = "C:/Program Files (x86)/EA Games/Battlefield 2/";
            this.InstallDirTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.InstallDirTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel11
            // 
            this.metroLabel11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(32, 134);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(176, 19);
            this.metroLabel11.TabIndex = 6;
            this.metroLabel11.Text = "Battlefield 2 Installation Path:";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveButton.Image = null;
            this.SaveButton.Location = new System.Drawing.Point(192, 235);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(104, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseSelectable = true;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel14
            // 
            this.metroLabel14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel14.Location = new System.Drawing.Point(23, 76);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(442, 31);
            this.metroLabel14.TabIndex = 24;
            this.metroLabel14.Text = "Please provide the installation path the your Battlefield 2 game.";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 292);
            this.Controls.Add(this.metroLabel14);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.InstallDirTextbox);
            this.Controls.Add(this.metroLabel11);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.StyleManager = this.metroStyleManager1;
            this.Text = "Battlefield 2 Setup";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox.MetroTextButton ChangeButton;
        private MetroFramework.Controls.MetroTextBox InstallDirTextbox;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton SaveButton;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel metroLabel14;
    }
}