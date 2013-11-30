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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MePOR));
            this.registerButton = new System.Windows.Forms.Button();
            this.memberSearchButton = new System.Windows.Forms.Button();
            this.transactionTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.returnRadio = new System.Windows.Forms.RadioButton();
            this.rentalRadio = new System.Windows.Forms.RadioButton();
            this.memberInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.memberDataGridView = new System.Windows.Forms.DataGridView();
            this.selectedItemsGroupBox = new System.Windows.Forms.GroupBox();
            this.clearSelectedItemsButton = new System.Windows.Forms.Button();
            this.selectedItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.searchForItemsGroupBox = new System.Windows.Forms.GroupBox();
            this.addToSelectedItemsButton = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchItemsButton = new System.Windows.Forms.Button();
            this.searchByLabel = new System.Windows.Forms.Label();
            this.searchByDropDown = new System.Windows.Forms.ComboBox();
            this.searchItemsGridView = new System.Windows.Forms.DataGridView();
            this.rentOrReturnExecuteButton = new System.Windows.Forms.Button();
            this.transactionTypeGroupBox.SuspendLayout();
            this.memberInformationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberDataGridView)).BeginInit();
            this.selectedItemsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedItemsDataGridView)).BeginInit();
            this.searchForItemsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchItemsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(12, 69);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(127, 48);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // memberSearchButton
            // 
            this.memberSearchButton.Location = new System.Drawing.Point(441, 87);
            this.memberSearchButton.Name = "memberSearchButton";
            this.memberSearchButton.Size = new System.Drawing.Size(93, 24);
            this.memberSearchButton.TabIndex = 4;
            this.memberSearchButton.Text = "Member Search";
            this.memberSearchButton.UseVisualStyleBackColor = true;
            this.memberSearchButton.Click += new System.EventHandler(this.memberSearchButton_Click);
            // 
            // transactionTypeGroupBox
            // 
            this.transactionTypeGroupBox.Controls.Add(this.returnRadio);
            this.transactionTypeGroupBox.Controls.Add(this.rentalRadio);
            this.transactionTypeGroupBox.Location = new System.Drawing.Point(12, 22);
            this.transactionTypeGroupBox.Name = "transactionTypeGroupBox";
            this.transactionTypeGroupBox.Size = new System.Drawing.Size(127, 41);
            this.transactionTypeGroupBox.TabIndex = 4;
            this.transactionTypeGroupBox.TabStop = false;
            this.transactionTypeGroupBox.Text = "Transaction Type";
            // 
            // returnRadio
            // 
            this.returnRadio.AutoSize = true;
            this.returnRadio.Location = new System.Drawing.Point(68, 17);
            this.returnRadio.Name = "returnRadio";
            this.returnRadio.Size = new System.Drawing.Size(57, 17);
            this.returnRadio.TabIndex = 2;
            this.returnRadio.TabStop = true;
            this.returnRadio.Text = "Return";
            this.returnRadio.UseVisualStyleBackColor = true;
            this.returnRadio.CheckedChanged += new System.EventHandler(this.returnRadio_CheckedChanged);
            // 
            // rentalRadio
            // 
            this.rentalRadio.AutoSize = true;
            this.rentalRadio.Checked = true;
            this.rentalRadio.Location = new System.Drawing.Point(6, 17);
            this.rentalRadio.Name = "rentalRadio";
            this.rentalRadio.Size = new System.Drawing.Size(56, 17);
            this.rentalRadio.TabIndex = 1;
            this.rentalRadio.TabStop = true;
            this.rentalRadio.Text = "Rental";
            this.rentalRadio.UseVisualStyleBackColor = true;
            this.rentalRadio.CheckedChanged += new System.EventHandler(this.rentalRadio_CheckedChanged);
            // 
            // memberInformationGroupBox
            // 
            this.memberInformationGroupBox.Controls.Add(this.memberDataGridView);
            this.memberInformationGroupBox.Controls.Add(this.memberSearchButton);
            this.memberInformationGroupBox.Location = new System.Drawing.Point(157, 13);
            this.memberInformationGroupBox.Name = "memberInformationGroupBox";
            this.memberInformationGroupBox.Size = new System.Drawing.Size(540, 117);
            this.memberInformationGroupBox.TabIndex = 5;
            this.memberInformationGroupBox.TabStop = false;
            this.memberInformationGroupBox.Text = "Member Information";
            // 
            // memberDataGridView
            // 
            this.memberDataGridView.AllowUserToAddRows = false;
            this.memberDataGridView.AllowUserToResizeRows = false;
            this.memberDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memberDataGridView.Location = new System.Drawing.Point(6, 19);
            this.memberDataGridView.Name = "memberDataGridView";
            this.memberDataGridView.Size = new System.Drawing.Size(528, 62);
            this.memberDataGridView.TabIndex = 6;
            this.memberDataGridView.TabStop = false;
            // 
            // selectedItemsGroupBox
            // 
            this.selectedItemsGroupBox.Controls.Add(this.clearSelectedItemsButton);
            this.selectedItemsGroupBox.Controls.Add(this.selectedItemsDataGridView);
            this.selectedItemsGroupBox.Location = new System.Drawing.Point(12, 136);
            this.selectedItemsGroupBox.Name = "selectedItemsGroupBox";
            this.selectedItemsGroupBox.Size = new System.Drawing.Size(685, 170);
            this.selectedItemsGroupBox.TabIndex = 6;
            this.selectedItemsGroupBox.TabStop = false;
            this.selectedItemsGroupBox.Text = "Selected Items";
            // 
            // clearSelectedItemsButton
            // 
            this.clearSelectedItemsButton.Location = new System.Drawing.Point(604, 141);
            this.clearSelectedItemsButton.Name = "clearSelectedItemsButton";
            this.clearSelectedItemsButton.Size = new System.Drawing.Size(75, 23);
            this.clearSelectedItemsButton.TabIndex = 8;
            this.clearSelectedItemsButton.Text = "Clear";
            this.clearSelectedItemsButton.UseVisualStyleBackColor = true;
            this.clearSelectedItemsButton.Click += new System.EventHandler(this.clearSelectedItemsButton_Click);
            // 
            // selectedItemsDataGridView
            // 
            this.selectedItemsDataGridView.AllowUserToAddRows = false;
            this.selectedItemsDataGridView.AllowUserToDeleteRows = false;
            this.selectedItemsDataGridView.AllowUserToResizeRows = false;
            this.selectedItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedItemsDataGridView.Location = new System.Drawing.Point(6, 19);
            this.selectedItemsDataGridView.Name = "selectedItemsDataGridView";
            this.selectedItemsDataGridView.Size = new System.Drawing.Size(673, 109);
            this.selectedItemsDataGridView.TabIndex = 7;
            this.selectedItemsDataGridView.TabStop = false;
            this.selectedItemsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectedItemsDataGridView_CellEndEdit);
            // 
            // searchForItemsGroupBox
            // 
            this.searchForItemsGroupBox.Controls.Add(this.addToSelectedItemsButton);
            this.searchForItemsGroupBox.Controls.Add(this.search);
            this.searchForItemsGroupBox.Controls.Add(this.searchLabel);
            this.searchForItemsGroupBox.Controls.Add(this.searchItemsButton);
            this.searchForItemsGroupBox.Controls.Add(this.searchByLabel);
            this.searchForItemsGroupBox.Controls.Add(this.searchByDropDown);
            this.searchForItemsGroupBox.Controls.Add(this.searchItemsGridView);
            this.searchForItemsGroupBox.Location = new System.Drawing.Point(12, 312);
            this.searchForItemsGroupBox.Name = "searchForItemsGroupBox";
            this.searchForItemsGroupBox.Size = new System.Drawing.Size(685, 208);
            this.searchForItemsGroupBox.TabIndex = 7;
            this.searchForItemsGroupBox.TabStop = false;
            this.searchForItemsGroupBox.Text = "Search For Items";
            // 
            // addToSelectedItemsButton
            // 
            this.addToSelectedItemsButton.Location = new System.Drawing.Point(576, 176);
            this.addToSelectedItemsButton.Name = "addToSelectedItemsButton";
            this.addToSelectedItemsButton.Size = new System.Drawing.Size(103, 23);
            this.addToSelectedItemsButton.TabIndex = 12;
            this.addToSelectedItemsButton.Text = "Add To Selected";
            this.addToSelectedItemsButton.UseVisualStyleBackColor = true;
            this.addToSelectedItemsButton.Click += new System.EventHandler(this.addToSelectedItemsButton_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(230, 24);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(156, 20);
            this.search.TabIndex = 6;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(180, 26);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(44, 13);
            this.searchLabel.TabIndex = 11;
            this.searchLabel.Text = "Search:";
            // 
            // searchItemsButton
            // 
            this.searchItemsButton.Location = new System.Drawing.Point(604, 23);
            this.searchItemsButton.Name = "searchItemsButton";
            this.searchItemsButton.Size = new System.Drawing.Size(75, 23);
            this.searchItemsButton.TabIndex = 7;
            this.searchItemsButton.Text = "Search";
            this.searchItemsButton.UseVisualStyleBackColor = true;
            this.searchItemsButton.Click += new System.EventHandler(this.searchItemsButton_Click);
            // 
            // searchByLabel
            // 
            this.searchByLabel.AutoSize = true;
            this.searchByLabel.Location = new System.Drawing.Point(7, 26);
            this.searchByLabel.Name = "searchByLabel";
            this.searchByLabel.Size = new System.Drawing.Size(59, 13);
            this.searchByLabel.TabIndex = 9;
            this.searchByLabel.Text = "Search By:";
            // 
            // searchByDropDown
            // 
            this.searchByDropDown.FormattingEnabled = true;
            this.searchByDropDown.Location = new System.Drawing.Point(72, 23);
            this.searchByDropDown.Name = "searchByDropDown";
            this.searchByDropDown.Size = new System.Drawing.Size(102, 21);
            this.searchByDropDown.TabIndex = 5;
            // 
            // searchItemsGridView
            // 
            this.searchItemsGridView.AllowUserToAddRows = false;
            this.searchItemsGridView.AllowUserToDeleteRows = false;
            this.searchItemsGridView.AllowUserToResizeRows = false;
            this.searchItemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchItemsGridView.Location = new System.Drawing.Point(6, 61);
            this.searchItemsGridView.Name = "searchItemsGridView";
            this.searchItemsGridView.ReadOnly = true;
            this.searchItemsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchItemsGridView.Size = new System.Drawing.Size(673, 109);
            this.searchItemsGridView.TabIndex = 7;
            this.searchItemsGridView.TabStop = false;
            // 
            // rentOrReturnExecuteButton
            // 
            this.rentOrReturnExecuteButton.Location = new System.Drawing.Point(616, 526);
            this.rentOrReturnExecuteButton.Name = "rentOrReturnExecuteButton";
            this.rentOrReturnExecuteButton.Size = new System.Drawing.Size(75, 23);
            this.rentOrReturnExecuteButton.TabIndex = 8;
            this.rentOrReturnExecuteButton.UseVisualStyleBackColor = true;
            this.rentOrReturnExecuteButton.Click += new System.EventHandler(this.rentOrReturnExecuteButton_Click);
            // 
            // MePOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 561);
            this.Controls.Add(this.rentOrReturnExecuteButton);
            this.Controls.Add(this.searchForItemsGroupBox);
            this.Controls.Add(this.selectedItemsGroupBox);
            this.Controls.Add(this.memberInformationGroupBox);
            this.Controls.Add(this.transactionTypeGroupBox);
            this.Controls.Add(this.registerButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MePOR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Interface";
            this.transactionTypeGroupBox.ResumeLayout(false);
            this.transactionTypeGroupBox.PerformLayout();
            this.memberInformationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memberDataGridView)).EndInit();
            this.selectedItemsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedItemsDataGridView)).EndInit();
            this.searchForItemsGroupBox.ResumeLayout(false);
            this.searchForItemsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchItemsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button memberSearchButton;
        private System.Windows.Forms.GroupBox transactionTypeGroupBox;
        private System.Windows.Forms.RadioButton returnRadio;
        private System.Windows.Forms.RadioButton rentalRadio;
        private System.Windows.Forms.GroupBox memberInformationGroupBox;
        private System.Windows.Forms.DataGridView memberDataGridView;
        private System.Windows.Forms.GroupBox selectedItemsGroupBox;
        private System.Windows.Forms.DataGridView selectedItemsDataGridView;
        private System.Windows.Forms.GroupBox searchForItemsGroupBox;
        private System.Windows.Forms.Button searchItemsButton;
        private System.Windows.Forms.Label searchByLabel;
        private System.Windows.Forms.ComboBox searchByDropDown;
        private System.Windows.Forms.DataGridView searchItemsGridView;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button rentOrReturnExecuteButton;
        private System.Windows.Forms.Button addToSelectedItemsButton;
        private System.Windows.Forms.Button clearSelectedItemsButton;
    }
}