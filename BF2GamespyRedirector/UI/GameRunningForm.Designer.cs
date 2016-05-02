namespace BF2GamespyRedirector
{
    partial class GameRunningForm
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
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroColorButton1 = new BF2GamespyRedirector.MetroColorButton();
            this.SuspendLayout();
            // 
            // metroLabel8
            // 
            this.metroLabel8.Location = new System.Drawing.Point(65, 30);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(270, 49);
            this.metroLabel8.TabIndex = 7;
            this.metroLabel8.Text = "Battlefield 2 is Running. Any modification will not take affect until Battlefield" +
    " 2 is restarted.";
            this.metroLabel8.WrapToLine = true;
            // 
            // metroColorButton1
            // 
            this.metroColorButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.metroColorButton1.Image = null;
            this.metroColorButton1.Location = new System.Drawing.Point(87, 123);
            this.metroColorButton1.Name = "metroColorButton1";
            this.metroColorButton1.Size = new System.Drawing.Size(226, 24);
            this.metroColorButton1.TabIndex = 8;
            this.metroColorButton1.Text = "Close";
            this.metroColorButton1.UseSelectable = true;
            this.metroColorButton1.UseVisualStyleBackColor = true;
            // 
            // GameRunningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 167);
            this.ControlBox = false;
            this.Controls.Add(this.metroColorButton1);
            this.Controls.Add(this.metroLabel8);
            this.DisplayHeader = false;
            this.Name = "GameRunningForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroColorButton metroColorButton1;
    }
}