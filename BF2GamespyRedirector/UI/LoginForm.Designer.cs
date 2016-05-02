namespace BF2GamespyRedirector
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.PasswordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.UsernameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.LoginButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.CanButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ProviderNameLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.PasswordTextBox.CustomButton.Image = null;
            this.PasswordTextBox.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.PasswordTextBox.CustomButton.Name = "";
            this.PasswordTextBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.PasswordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PasswordTextBox.CustomButton.TabIndex = 1;
            this.PasswordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PasswordTextBox.CustomButton.UseSelectable = true;
            this.PasswordTextBox.CustomButton.Visible = false;
            this.PasswordTextBox.DisplayIcon = true;
            this.PasswordTextBox.Icon = ((System.Drawing.Image)(resources.GetObject("PasswordTextBox.Icon")));
            this.PasswordTextBox.Lines = new string[0];
            this.PasswordTextBox.Location = new System.Drawing.Point(178, 138);
            this.PasswordTextBox.MaxLength = 32767;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '●';
            this.PasswordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasswordTextBox.SelectedText = "";
            this.PasswordTextBox.SelectionLength = 0;
            this.PasswordTextBox.SelectionStart = 0;
            this.PasswordTextBox.Size = new System.Drawing.Size(279, 28);
            this.PasswordTextBox.Style = MetroFramework.MetroColorStyle.Black;
            this.PasswordTextBox.TabIndex = 9;
            this.PasswordTextBox.UseSelectable = true;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.WaterMark = "Password";
            this.PasswordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PasswordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.UsernameTextBox.CustomButton.Image = null;
            this.UsernameTextBox.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.UsernameTextBox.CustomButton.Name = "";
            this.UsernameTextBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.UsernameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UsernameTextBox.CustomButton.TabIndex = 1;
            this.UsernameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UsernameTextBox.CustomButton.UseSelectable = true;
            this.UsernameTextBox.CustomButton.Visible = false;
            this.UsernameTextBox.DisplayIcon = true;
            this.UsernameTextBox.Icon = ((System.Drawing.Image)(resources.GetObject("UsernameTextBox.Icon")));
            this.UsernameTextBox.Lines = new string[0];
            this.UsernameTextBox.Location = new System.Drawing.Point(178, 104);
            this.UsernameTextBox.MaxLength = 32767;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.PasswordChar = '\0';
            this.UsernameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UsernameTextBox.SelectedText = "";
            this.UsernameTextBox.SelectionLength = 0;
            this.UsernameTextBox.SelectionStart = 0;
            this.UsernameTextBox.Size = new System.Drawing.Size(279, 28);
            this.UsernameTextBox.Style = MetroFramework.MetroColorStyle.Black;
            this.UsernameTextBox.TabIndex = 8;
            this.UsernameTextBox.UseSelectable = true;
            this.UsernameTextBox.WaterMark = "Username";
            this.UsernameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UsernameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginButton.Location = new System.Drawing.Point(360, 187);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(97, 33);
            this.LoginButton.TabIndex = 10;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseSelectable = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(175, 12);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(279, 55);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = "In order to Auto Join a server or bypass the login menu, you must login first.";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            this.metroLabel2.WrapToLine = true;
            // 
            // CanButton
            // 
            this.CanButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CanButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CanButton.Location = new System.Drawing.Point(178, 187);
            this.CanButton.Name = "CanButton";
            this.CanButton.Size = new System.Drawing.Size(97, 33);
            this.CanButton.TabIndex = 12;
            this.CanButton.Text = "Cancel";
            this.CanButton.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(175, 76);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(142, 21);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "Entrer credentials for:";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            this.metroLabel1.WrapToLine = true;
            // 
            // ProviderNameLabel
            // 
            this.ProviderNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProviderNameLabel.Location = new System.Drawing.Point(315, 76);
            this.ProviderNameLabel.Name = "ProviderNameLabel";
            this.ProviderNameLabel.Size = new System.Drawing.Size(273, 21);
            this.ProviderNameLabel.Style = MetroFramework.MetroColorStyle.Teal;
            this.ProviderNameLabel.TabIndex = 14;
            this.ProviderNameLabel.Text = "Provider Name";
            this.ProviderNameLabel.UseCustomBackColor = true;
            this.ProviderNameLabel.UseCustomForeColor = true;
            this.ProviderNameLabel.WrapToLine = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 232);
            this.ControlBox = false;
            this.Controls.Add(this.ProviderNameLabel);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.CanButton);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoginForm";
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton LoginButton;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton CanButton;
        public MetroFramework.Controls.MetroTextBox UsernameTextBox;
        public MetroFramework.Controls.MetroTextBox PasswordTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel ProviderNameLabel;
    }
}