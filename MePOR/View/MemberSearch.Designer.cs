namespace MePOR.View
{
    partial class MemberSearch
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
            this.fnameTextBox = new System.Windows.Forms.TextBox();
            this.fnameLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.lnameTextBox = new System.Windows.Forms.TextBox();
            this.lnameLabel = new System.Windows.Forms.Label();
            this.orLabel = new System.Windows.Forms.Label();
            this.searchByTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fnameTextBox
            // 
            this.fnameTextBox.Location = new System.Drawing.Point(85, 24);
            this.fnameTextBox.Name = "fnameTextBox";
            this.fnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.fnameTextBox.TabIndex = 5;
            // 
            // fnameLabel
            // 
            this.fnameLabel.AutoSize = true;
            this.fnameLabel.Location = new System.Drawing.Point(19, 27);
            this.fnameLabel.Name = "fnameLabel";
            this.fnameLabel.Size = new System.Drawing.Size(60, 13);
            this.fnameLabel.TabIndex = 4;
            this.fnameLabel.Text = "First Name:";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(313, 37);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTextBox.TabIndex = 7;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(266, 40);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(41, 13);
            this.phoneLabel.TabIndex = 6;
            this.phoneLabel.Text = "Phone:";
            // 
            // lnameTextBox
            // 
            this.lnameTextBox.Location = new System.Drawing.Point(85, 50);
            this.lnameTextBox.Name = "lnameTextBox";
            this.lnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lnameTextBox.TabIndex = 9;
            // 
            // lnameLabel
            // 
            this.lnameLabel.AutoSize = true;
            this.lnameLabel.Location = new System.Drawing.Point(19, 53);
            this.lnameLabel.Name = "lnameLabel";
            this.lnameLabel.Size = new System.Drawing.Size(61, 13);
            this.lnameLabel.TabIndex = 8;
            this.lnameLabel.Text = "Last Name:";
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Location = new System.Drawing.Point(219, 40);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(23, 13);
            this.orLabel.TabIndex = 10;
            this.orLabel.Text = "OR";
            // 
            // searchByTitle
            // 
            this.searchByTitle.AutoSize = true;
            this.searchByTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchByTitle.Location = new System.Drawing.Point(219, 13);
            this.searchByTitle.Name = "searchByTitle";
            this.searchByTitle.Size = new System.Drawing.Size(86, 20);
            this.searchByTitle.TabIndex = 11;
            this.searchByTitle.Text = "SearchBy";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnameTextBox);
            this.groupBox1.Controls.Add(this.fnameLabel);
            this.groupBox1.Controls.Add(this.phoneTextBox);
            this.groupBox1.Controls.Add(this.phoneLabel);
            this.groupBox1.Controls.Add(this.orLabel);
            this.groupBox1.Controls.Add(this.fnameTextBox);
            this.groupBox1.Controls.Add(this.lnameLabel);
            this.groupBox1.Location = new System.Drawing.Point(32, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 86);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(397, 336);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(32, 131);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(439, 199);
            this.richTextBox.TabIndex = 15;
            this.richTextBox.Text = "";
            // 
            // MemberSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 377);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchByTitle);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MemberSearch";
            this.Text = "MemberSearch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fnameTextBox;
        private System.Windows.Forms.Label fnameLabel;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox lnameTextBox;
        private System.Windows.Forms.Label lnameLabel;
        private System.Windows.Forms.Label orLabel;
        private System.Windows.Forms.Label searchByTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}