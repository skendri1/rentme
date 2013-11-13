namespace MePOR
{
    partial class MePOR
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
            this.userLabel = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.memberSearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.Location = new System.Drawing.Point(87, 9);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(251, 36);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Employee System";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(33, 62);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(109, 61);
            this.registerBtn.TabIndex = 2;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // memberSearchButton
            // 
            this.memberSearchButton.Location = new System.Drawing.Point(33, 140);
            this.memberSearchButton.Name = "memberSearchButton";
            this.memberSearchButton.Size = new System.Drawing.Size(109, 70);
            this.memberSearchButton.TabIndex = 3;
            this.memberSearchButton.Text = "Member Search";
            this.memberSearchButton.UseVisualStyleBackColor = true;
            this.memberSearchButton.Click += new System.EventHandler(this.memberSearchButton_Click);
            // 
            // MePOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 344);
            this.Controls.Add(this.memberSearchButton);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.userLabel);
            this.Name = "MePOR";
            this.Text = "MePOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button memberSearchButton;
    }
}