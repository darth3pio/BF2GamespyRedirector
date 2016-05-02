namespace BF2GamespyRedirector
{
    partial class LaunchParamsForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CustomRes = new MetroFramework.Controls.MetroCheckBox();
            this.WindowedMode = new MetroFramework.Controls.MetroCheckBox();
            this.WidthText = new System.Windows.Forms.TextBox();
            this.HeightText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CloseBtn = new MetroFramework.Controls.MetroButton();
            this.SaveButton = new MetroFramework.Controls.MetroButton();
            this.Restart = new MetroFramework.Controls.MetroCheckBox();
            this.DisableSwiff = new MetroFramework.Controls.MetroCheckBox();
            this.NoSound = new MetroFramework.Controls.MetroCheckBox();
            this.LowPriority = new MetroFramework.Controls.MetroCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LowPriority);
            this.groupBox2.Controls.Add(this.NoSound);
            this.groupBox2.Controls.Add(this.DisableSwiff);
            this.groupBox2.Controls.Add(this.Restart);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(320, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 145);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Misc";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CustomRes);
            this.groupBox1.Controls.Add(this.WindowedMode);
            this.groupBox1.Controls.Add(this.WidthText);
            this.groupBox1.Controls.Add(this.HeightText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(79, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 145);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screen Settings";
            // 
            // CustomRes
            // 
            this.CustomRes.AutoSize = true;
            this.CustomRes.Location = new System.Drawing.Point(46, 53);
            this.CustomRes.Name = "CustomRes";
            this.CustomRes.Size = new System.Drawing.Size(156, 15);
            this.CustomRes.TabIndex = 9;
            this.CustomRes.Text = "Force Custom Resolution";
            this.CustomRes.UseSelectable = true;
            this.CustomRes.CheckedChanged += new System.EventHandler(this.CustomRes_CheckedChanged);
            // 
            // WindowedMode
            // 
            this.WindowedMode.AutoSize = true;
            this.WindowedMode.Location = new System.Drawing.Point(46, 32);
            this.WindowedMode.Name = "WindowedMode";
            this.WindowedMode.Size = new System.Drawing.Size(114, 15);
            this.WindowedMode.TabIndex = 8;
            this.WindowedMode.Text = "Windowed Mode";
            this.WindowedMode.UseSelectable = true;
            // 
            // WidthText
            // 
            this.WidthText.Enabled = false;
            this.WidthText.Location = new System.Drawing.Point(57, 82);
            this.WidthText.Name = "WidthText";
            this.WidthText.Size = new System.Drawing.Size(47, 25);
            this.WidthText.TabIndex = 5;
            this.WidthText.Text = "1920";
            // 
            // HeightText
            // 
            this.HeightText.Enabled = false;
            this.HeightText.Location = new System.Drawing.Point(161, 82);
            this.HeightText.Name = "HeightText";
            this.HeightText.Size = new System.Drawing.Size(47, 25);
            this.HeightText.TabIndex = 7;
            this.HeightText.Text = "1080";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Height: ";
            // 
            // CloseBtn
            // 
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(216, 203);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(90, 25);
            this.CloseBtn.Style = MetroFramework.MetroColorStyle.Red;
            this.CloseBtn.TabIndex = 17;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseSelectable = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(329, 203);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(90, 25);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseSelectable = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Restart
            // 
            this.Restart.AutoSize = true;
            this.Restart.Location = new System.Drawing.Point(35, 32);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(114, 15);
            this.Restart.TabIndex = 9;
            this.Restart.Text = "Skip Intro Movies";
            this.Restart.UseSelectable = true;
            // 
            // DisableSwiff
            // 
            this.DisableSwiff.AutoSize = true;
            this.DisableSwiff.Location = new System.Drawing.Point(35, 53);
            this.DisableSwiff.Name = "DisableSwiff";
            this.DisableSwiff.Size = new System.Drawing.Size(125, 15);
            this.DisableSwiff.TabIndex = 10;
            this.DisableSwiff.Text = "Disable Swiff Player";
            this.DisableSwiff.UseSelectable = true;
            // 
            // NoSound
            // 
            this.NoSound.AutoSize = true;
            this.NoSound.Location = new System.Drawing.Point(35, 74);
            this.NoSound.Name = "NoSound";
            this.NoSound.Size = new System.Drawing.Size(98, 15);
            this.NoSound.TabIndex = 11;
            this.NoSound.Text = "Disable Sound";
            this.NoSound.UseSelectable = true;
            // 
            // LowPriority
            // 
            this.LowPriority.AutoSize = true;
            this.LowPriority.Location = new System.Drawing.Point(35, 95);
            this.LowPriority.Name = "LowPriority";
            this.LowPriority.Size = new System.Drawing.Size(121, 15);
            this.LowPriority.TabIndex = 12;
            this.LowPriority.Text = "Run as low priority";
            this.LowPriority.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width:";
            // 
            // LaunchParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 240);
            this.ControlBox = false;
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LaunchParamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LaunchParamsForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox WidthText;
        private System.Windows.Forms.TextBox HeightText;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton CloseBtn;
        private MetroFramework.Controls.MetroButton SaveButton;
        private MetroFramework.Controls.MetroCheckBox WindowedMode;
        private MetroFramework.Controls.MetroCheckBox CustomRes;
        private MetroFramework.Controls.MetroCheckBox Restart;
        private MetroFramework.Controls.MetroCheckBox DisableSwiff;
        private MetroFramework.Controls.MetroCheckBox NoSound;
        private MetroFramework.Controls.MetroCheckBox LowPriority;
        private System.Windows.Forms.Label label1;
    }
}