namespace BF2GamespyRedirector
{
    partial class TaskForm
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
            this.labelInstructionText = new System.Windows.Forms.Label();
            this.labelContent = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.CnlButton = new BF2GamespyRedirector.MetroColorButton();
            this.SuspendLayout();
            // 
            // labelInstructionText
            // 
            this.labelInstructionText.AutoSize = true;
            this.labelInstructionText.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstructionText.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelInstructionText.Location = new System.Drawing.Point(86, 24);
            this.labelInstructionText.Name = "labelInstructionText";
            this.labelInstructionText.Size = new System.Drawing.Size(116, 25);
            this.labelInstructionText.TabIndex = 1;
            this.labelInstructionText.Text = "Header Text";
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContent.Location = new System.Drawing.Point(87, 63);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(89, 17);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "Message Text";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(90, 110);
            this.progressBar.MarqueeAnimationSpeed = 20;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(458, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            // 
            // CancelButton
            // 
            this.CnlButton.Image = null;
            this.CnlButton.Location = new System.Drawing.Point(473, 150);
            this.CnlButton.Name = "CancelButton";
            this.CnlButton.Size = new System.Drawing.Size(75, 23);
            this.CnlButton.TabIndex = 4;
            this.CnlButton.Text = "Cancel";
            this.CnlButton.UseSelectable = true;
            this.CnlButton.UseVisualStyleBackColor = true;
            this.CnlButton.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 200);
            this.ControlBox = false;
            this.Controls.Add(this.CnlButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.labelInstructionText);
            this.DisplayHeader = false;
            this.Movable = false;
            this.Name = "TaskForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TaskForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelInstructionText;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.ProgressBar progressBar;
        private MetroColorButton CnlButton;
    }
}