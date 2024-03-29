﻿namespace MePOR.View
{
    partial class AdminInterface
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminInterface));
            this.adminSearchGrid = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.sqlQueryGroupBox = new System.Windows.Forms.GroupBox();
            this.queryTextbox = new System.Windows.Forms.RichTextBox();
            this.findTransactionsGroupBox = new System.Windows.Forms.GroupBox();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.adminSearchGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.sqlQueryGroupBox.SuspendLayout();
            this.findTransactionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminSearchGrid
            // 
            this.adminSearchGrid.AllowUserToAddRows = false;
            this.adminSearchGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.adminSearchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.adminSearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.adminSearchGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.adminSearchGrid.Location = new System.Drawing.Point(22, 154);
            this.adminSearchGrid.Name = "adminSearchGrid";
            this.adminSearchGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.adminSearchGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.adminSearchGrid.Size = new System.Drawing.Size(545, 246);
            this.adminSearchGrid.TabIndex = 18;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(492, 406);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 16;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sqlQueryGroupBox);
            this.groupBox1.Controls.Add(this.findTransactionsGroupBox);
            this.groupBox1.Location = new System.Drawing.Point(22, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 137);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(6, 44);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(58, 13);
            this.startDateLabel.TabIndex = 4;
            this.startDateLabel.Text = "Start Date:";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(6, 69);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(55, 13);
            this.endDateLabel.TabIndex = 8;
            this.endDateLabel.Text = "End Date:";
            // 
            // sqlQueryGroupBox
            // 
            this.sqlQueryGroupBox.Controls.Add(this.queryTextbox);
            this.sqlQueryGroupBox.Location = new System.Drawing.Point(238, 19);
            this.sqlQueryGroupBox.Name = "sqlQueryGroupBox";
            this.sqlQueryGroupBox.Size = new System.Drawing.Size(301, 112);
            this.sqlQueryGroupBox.TabIndex = 14;
            this.sqlQueryGroupBox.TabStop = false;
            this.sqlQueryGroupBox.Text = "SQL Query";
            // 
            // queryTextbox
            // 
            this.queryTextbox.Location = new System.Drawing.Point(6, 20);
            this.queryTextbox.Name = "queryTextbox";
            this.queryTextbox.Size = new System.Drawing.Size(289, 86);
            this.queryTextbox.TabIndex = 0;
            this.queryTextbox.Text = "";
            // 
            // findTransactionsGroupBox
            // 
            this.findTransactionsGroupBox.Controls.Add(this.endDatePicker);
            this.findTransactionsGroupBox.Controls.Add(this.endDateLabel);
            this.findTransactionsGroupBox.Controls.Add(this.startDateLabel);
            this.findTransactionsGroupBox.Controls.Add(this.startDatePicker);
            this.findTransactionsGroupBox.Location = new System.Drawing.Point(6, 19);
            this.findTransactionsGroupBox.Name = "findTransactionsGroupBox";
            this.findTransactionsGroupBox.Size = new System.Drawing.Size(226, 112);
            this.findTransactionsGroupBox.TabIndex = 15;
            this.findTransactionsGroupBox.TabStop = false;
            this.findTransactionsGroupBox.Text = "Find Transactions";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(67, 38);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(150, 20);
            this.startDatePicker.TabIndex = 0;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(67, 62);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(150, 20);
            this.endDatePicker.TabIndex = 9;
            // 
            // AdminInterface
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 441);
            this.Controls.Add(this.adminSearchGrid);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminInterface";
            ((System.ComponentModel.ISupportInitialize)(this.adminSearchGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.sqlQueryGroupBox.ResumeLayout(false);
            this.findTransactionsGroupBox.ResumeLayout(false);
            this.findTransactionsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView adminSearchGrid;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.GroupBox sqlQueryGroupBox;
        private System.Windows.Forms.RichTextBox queryTextbox;
        private System.Windows.Forms.GroupBox findTransactionsGroupBox;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
    }
}