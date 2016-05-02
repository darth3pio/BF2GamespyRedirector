namespace BF2GamespyRedirector
{
    partial class ServerEditorForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ServerNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.ServerNameLabel = new System.Windows.Forms.Label();
            this.CloseBtn = new MetroFramework.Controls.MetroButton();
            this.SaveButton = new MetroFramework.Controls.MetroButton();
            this.PortTextBox = new MetroFramework.Controls.MetroTextBox();
            this.AddressTextBox = new MetroFramework.Controls.MetroTextBox();
            this.ProviderComboBox = new MetroFramework.Controls.MetroComboBox();
            this.ServiceLabel = new System.Windows.Forms.Label();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.ServerNameTextBox);
            this.panel1.Controls.Add(this.ServerNameLabel);
            this.panel1.Controls.Add(this.CloseBtn);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.PortTextBox);
            this.panel1.Controls.Add(this.AddressTextBox);
            this.panel1.Controls.Add(this.ProviderComboBox);
            this.panel1.Controls.Add(this.ServiceLabel);
            this.panel1.Controls.Add(this.ServerLabel);
            this.panel1.Controls.Add(this.AddressLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 230);
            this.panel1.TabIndex = 0;
            // 
            // ServerNameTextBox
            // 
            // 
            // 
            // 
            this.ServerNameTextBox.CustomButton.Image = null;
            this.ServerNameTextBox.CustomButton.Location = new System.Drawing.Point(232, 1);
            this.ServerNameTextBox.CustomButton.Name = "";
            this.ServerNameTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ServerNameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ServerNameTextBox.CustomButton.TabIndex = 1;
            this.ServerNameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ServerNameTextBox.CustomButton.UseSelectable = true;
            this.ServerNameTextBox.CustomButton.Visible = false;
            this.ServerNameTextBox.Lines = new string[0];
            this.ServerNameTextBox.Location = new System.Drawing.Point(252, 19);
            this.ServerNameTextBox.MaxLength = 32767;
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.PasswordChar = '\0';
            this.ServerNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ServerNameTextBox.SelectedText = "";
            this.ServerNameTextBox.SelectionLength = 0;
            this.ServerNameTextBox.SelectionStart = 0;
            this.ServerNameTextBox.Size = new System.Drawing.Size(254, 23);
            this.ServerNameTextBox.TabIndex = 1;
            this.ServerNameTextBox.UseSelectable = true;
            this.ServerNameTextBox.WaterMark = "Enter Server Name Here";
            this.ServerNameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ServerNameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ServerNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ServerNameTextBox_Validating);
            // 
            // ServerNameLabel
            // 
            this.ServerNameLabel.AutoSize = true;
            this.ServerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ServerNameLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ServerNameLabel.Location = new System.Drawing.Point(149, 19);
            this.ServerNameLabel.Name = "ServerNameLabel";
            this.ServerNameLabel.Size = new System.Drawing.Size(97, 20);
            this.ServerNameLabel.TabIndex = 34;
            this.ServerNameLabel.Text = "Server Name:";
            // 
            // CloseBtn
            // 
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(216, 176);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(90, 25);
            this.CloseBtn.Style = MetroFramework.MetroColorStyle.Red;
            this.CloseBtn.TabIndex = 50;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseSelectable = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(329, 176);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(90, 25);
            this.SaveButton.TabIndex = 60;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseSelectable = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PortTextBox
            // 
            // 
            // 
            // 
            this.PortTextBox.CustomButton.Image = null;
            this.PortTextBox.CustomButton.Location = new System.Drawing.Point(57, 1);
            this.PortTextBox.CustomButton.Name = "";
            this.PortTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PortTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PortTextBox.CustomButton.TabIndex = 1;
            this.PortTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PortTextBox.CustomButton.UseSelectable = true;
            this.PortTextBox.CustomButton.Visible = false;
            this.PortTextBox.Lines = new string[0];
            this.PortTextBox.Location = new System.Drawing.Point(252, 88);
            this.PortTextBox.MaxLength = 32767;
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.PasswordChar = '\0';
            this.PortTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PortTextBox.SelectedText = "";
            this.PortTextBox.SelectionLength = 0;
            this.PortTextBox.SelectionStart = 0;
            this.PortTextBox.Size = new System.Drawing.Size(79, 23);
            this.PortTextBox.TabIndex = 3;
            this.PortTextBox.UseSelectable = true;
            this.PortTextBox.WaterMark = "16567";
            this.PortTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PortTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.PortTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.PortTextBox_Validating);
            // 
            // AddressTextBox
            // 
            // 
            // 
            // 
            this.AddressTextBox.CustomButton.Image = null;
            this.AddressTextBox.CustomButton.Location = new System.Drawing.Point(232, 1);
            this.AddressTextBox.CustomButton.Name = "";
            this.AddressTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.AddressTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.AddressTextBox.CustomButton.TabIndex = 1;
            this.AddressTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AddressTextBox.CustomButton.UseSelectable = true;
            this.AddressTextBox.CustomButton.Visible = false;
            this.AddressTextBox.Lines = new string[0];
            this.AddressTextBox.Location = new System.Drawing.Point(252, 54);
            this.AddressTextBox.MaxLength = 32767;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.PasswordChar = '\0';
            this.AddressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AddressTextBox.SelectedText = "";
            this.AddressTextBox.SelectionLength = 0;
            this.AddressTextBox.SelectionStart = 0;
            this.AddressTextBox.Size = new System.Drawing.Size(254, 23);
            this.AddressTextBox.TabIndex = 2;
            this.AddressTextBox.UseSelectable = true;
            this.AddressTextBox.WaterMark = "Hostname or IPAddress";
            this.AddressTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.AddressTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.AddressTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AddressTextBox_Validating);
            // 
            // ProviderComboBox
            // 
            this.ProviderComboBox.FormattingEnabled = true;
            this.ProviderComboBox.ItemHeight = 23;
            this.ProviderComboBox.Items.AddRange(new object[] {
            "- None -"});
            this.ProviderComboBox.Location = new System.Drawing.Point(252, 123);
            this.ProviderComboBox.Name = "ProviderComboBox";
            this.ProviderComboBox.Size = new System.Drawing.Size(254, 29);
            this.ProviderComboBox.TabIndex = 4;
            this.ProviderComboBox.UseSelectable = true;
            // 
            // ServiceLabel
            // 
            this.ServiceLabel.AutoSize = true;
            this.ServiceLabel.BackColor = System.Drawing.Color.Transparent;
            this.ServiceLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ServiceLabel.Location = new System.Drawing.Point(128, 127);
            this.ServiceLabel.Name = "ServiceLabel";
            this.ServiceLabel.Size = new System.Drawing.Size(118, 20);
            this.ServiceLabel.TabIndex = 32;
            this.ServiceLabel.Text = "Service Provider:";
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.BackColor = System.Drawing.Color.Transparent;
            this.ServerLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ServerLabel.Location = new System.Drawing.Point(162, 88);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(84, 20);
            this.ServerLabel.TabIndex = 31;
            this.ServerLabel.Text = "Server Port:";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.BackColor = System.Drawing.Color.Transparent;
            this.AddressLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.AddressLabel.Location = new System.Drawing.Point(136, 54);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(110, 20);
            this.AddressLabel.TabIndex = 30;
            this.AddressLabel.Text = "Server Address:";
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // ServerEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(635, 230);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerEditorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ServerEditorForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ServiceLabel;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.Label AddressLabel;
        private MetroFramework.Controls.MetroComboBox ProviderComboBox;
        private MetroFramework.Controls.MetroTextBox PortTextBox;
        private MetroFramework.Controls.MetroTextBox AddressTextBox;
        private MetroFramework.Controls.MetroButton SaveButton;
        private MetroFramework.Controls.MetroButton CloseBtn;
        private MetroFramework.Controls.MetroTextBox ServerNameTextBox;
        private System.Windows.Forms.Label ServerNameLabel;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
    }
}