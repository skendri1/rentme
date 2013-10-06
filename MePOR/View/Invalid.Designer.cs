namespace MePOR.View
{
    partial class Invalid
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
            this.welcomeText = new System.Windows.Forms.Label();
            this.retryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeText
            // 
            this.welcomeText.AutoSize = true;
            this.welcomeText.Location = new System.Drawing.Point(12, 34);
            this.welcomeText.Name = "welcomeText";
            this.welcomeText.Size = new System.Drawing.Size(295, 13);
            this.welcomeText.TabIndex = 5;
            this.welcomeText.Text = "An invalid username and password combination was entered.";
            // 
            // retryButton
            // 
            this.retryButton.Location = new System.Drawing.Point(119, 64);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(75, 23);
            this.retryButton.TabIndex = 6;
            this.retryButton.Text = "Retry";
            this.retryButton.UseVisualStyleBackColor = true;
            this.retryButton.Click += new System.EventHandler(this.RetryButtonClick);
            // 
            // Invalid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 124);
            this.Controls.Add(this.retryButton);
            this.Controls.Add(this.welcomeText);
            this.Name = "Invalid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Please Try Again";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeText;
        private System.Windows.Forms.Button retryButton;
    }
}