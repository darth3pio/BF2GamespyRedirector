namespace BF2GamespyRedirector
{
    partial class ProviderEditorForm
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
            this.GamespyTextBox = new MetroFramework.Controls.MetroTextBox();
            this.NameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.ServerNameLabel = new System.Windows.Forms.Label();
            this.CloseBtn = new MetroFramework.Controls.MetroButton();
            this.SaveButton = new MetroFramework.Controls.MetroButton();
            this.StatsTextBox = new MetroFramework.Controls.MetroTextBox();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.GamespyTextBox);
            this.panel1.Controls.Add(this.NameTextBox);
            this.panel1.Controls.Add(this.ServerNameLabel);
            this.panel1.Controls.Add(this.CloseBtn);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.StatsTextBox);
            this.panel1.Controls.Add(this.ServerLabel);
            this.panel1.Controls.Add(this.AddressLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 200);
            this.panel1.TabIndex = 1;
            // 
            // GamespyTextBox
            // 
            // 
            // 
            // 
            this.GamespyTextBox.CustomButton.Image = null;
            this.GamespyTextBox.CustomButton.Location = new System.Drawing.Point(232, 1);
            this.GamespyTextBox.CustomButton.Name = "";
            this.GamespyTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.GamespyTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.GamespyTextBox.CustomButton.TabIndex = 1;
            this.GamespyTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.GamespyTextBox.CustomButton.UseSelectable = true;
            this.GamespyTextBox.CustomButton.Visible = false;
            this.GamespyTextBox.Lines = new string[0];
            this.GamespyTextBox.Location = new System.Drawing.Point(258, 88);
            this.GamespyTextBox.MaxLength = 32767;
            this.GamespyTextBox.Name = "GamespyTextBox";
            this.GamespyTextBox.PasswordChar = '\0';
            this.GamespyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GamespyTextBox.SelectedText = "";
            this.GamespyTextBox.SelectionLength = 0;
            this.GamespyTextBox.SelectionStart = 0;
            this.GamespyTextBox.Size = new System.Drawing.Size(254, 23);
            this.GamespyTextBox.TabIndex = 3;
            this.GamespyTextBox.UseSelectable = true;
            this.GamespyTextBox.WaterMark = "Hostname or IPAddress";
            this.GamespyTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.GamespyTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.GamespyTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateAddress);
            // 
            // NameTextBox
            // 
            // 
            // 
            // 
            this.NameTextBox.CustomButton.Image = null;
            this.NameTextBox.CustomButton.Location = new System.Drawing.Point(232, 1);
            this.NameTextBox.CustomButton.Name = "";
            this.NameTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.NameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NameTextBox.CustomButton.TabIndex = 1;
            this.NameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NameTextBox.CustomButton.UseSelectable = true;
            this.NameTextBox.CustomButton.Visible = false;
            this.NameTextBox.Lines = new string[0];
            this.NameTextBox.Location = new System.Drawing.Point(258, 19);
            this.NameTextBox.MaxLength = 32767;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PasswordChar = '\0';
            this.NameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameTextBox.SelectedText = "";
            this.NameTextBox.SelectionLength = 0;
            this.NameTextBox.SelectionStart = 0;
            this.NameTextBox.Size = new System.Drawing.Size(254, 23);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.UseSelectable = true;
            this.NameTextBox.WaterMark = "Enter Provider Name Here";
            this.NameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.NameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameTextBox_Validating);
            // 
            // ServerNameLabel
            // 
            this.ServerNameLabel.AutoSize = true;
            this.ServerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ServerNameLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ServerNameLabel.Location = new System.Drawing.Point(141, 19);
            this.ServerNameLabel.Name = "ServerNameLabel";
            this.ServerNameLabel.Size = new System.Drawing.Size(111, 20);
            this.ServerNameLabel.TabIndex = 34;
            this.ServerNameLabel.Text = "Provider Name:";
            // 
            // CloseBtn
            // 
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(216, 142);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(90, 25);
            this.CloseBtn.Style = MetroFramework.MetroColorStyle.Red;
            this.CloseBtn.TabIndex = 5;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseSelectable = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(329, 142);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(90, 25);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseSelectable = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // StatsTextBox
            // 
            // 
            // 
            // 
            this.StatsTextBox.CustomButton.Image = null;
            this.StatsTextBox.CustomButton.Location = new System.Drawing.Point(232, 1);
            this.StatsTextBox.CustomButton.Name = "";
            this.StatsTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.StatsTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.StatsTextBox.CustomButton.TabIndex = 1;
            this.StatsTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.StatsTextBox.CustomButton.UseSelectable = true;
            this.StatsTextBox.CustomButton.Visible = false;
            this.StatsTextBox.Lines = new string[0];
            this.StatsTextBox.Location = new System.Drawing.Point(258, 54);
            this.StatsTextBox.MaxLength = 32767;
            this.StatsTextBox.Name = "StatsTextBox";
            this.StatsTextBox.PasswordChar = '\0';
            this.StatsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.StatsTextBox.SelectedText = "";
            this.StatsTextBox.SelectionLength = 0;
            this.StatsTextBox.SelectionStart = 0;
            this.StatsTextBox.Size = new System.Drawing.Size(254, 23);
            this.StatsTextBox.TabIndex = 2;
            this.StatsTextBox.UseSelectable = true;
            this.StatsTextBox.WaterMark = "Hostname or IPAddress";
            this.StatsTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.StatsTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.StatsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateAddress);
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.BackColor = System.Drawing.Color.Transparent;
            this.ServerLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ServerLabel.Location = new System.Drawing.Point(122, 88);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(130, 20);
            this.ServerLabel.TabIndex = 31;
            this.ServerLabel.Text = "Gamespy Address:";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.BackColor = System.Drawing.Color.Transparent;
            this.AddressLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.AddressLabel.Location = new System.Drawing.Point(151, 54);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(101, 20);
            this.AddressLabel.TabIndex = 30;
            this.AddressLabel.Text = "Stats Address:";
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // ProviderEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 200);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProviderEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProviderEditorForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTextBox NameTextBox;
        private System.Windows.Forms.Label ServerNameLabel;
        private MetroFramework.Controls.MetroButton CloseBtn;
        private MetroFramework.Controls.MetroButton SaveButton;
        private MetroFramework.Controls.MetroTextBox StatsTextBox;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.Label AddressLabel;
        private MetroFramework.Controls.MetroTextBox GamespyTextBox;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
    }
}