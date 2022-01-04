namespace POS_Eatery
{
    partial class Report_Supplier
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.cst_name = new System.Windows.Forms.ComboBox();
            this.button_export = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_print = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.owner = new System.Windows.Forms.TextBox();
            this.users = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.employee_name = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.amountpaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.no_of_record = new System.Windows.Forms.TextBox();
            this.branch = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(18, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 19);
            this.label8.TabIndex = 733;
            this.label8.Text = "Customer\'s Name";
            this.label8.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // cst_name
            // 
            this.cst_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cst_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cst_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cst_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cst_name.FormattingEnabled = true;
            this.cst_name.Location = new System.Drawing.Point(150, 11);
            this.cst_name.Name = "cst_name";
            this.cst_name.Size = new System.Drawing.Size(339, 25);
            this.cst_name.TabIndex = 743;
            this.cst_name.Visible = false;
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.Firebrick;
            this.button_export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_export.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.ForeColor = System.Drawing.SystemColors.Window;
            this.button_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_export.Location = new System.Drawing.Point(863, 5);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(125, 36);
            this.button_export.TabIndex = 742;
            this.button_export.Text = "Export to Excel";
            this.button_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_export.UseVisualStyleBackColor = false;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Firebrick;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 598);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1034, 22);
            this.statusStrip1.TabIndex = 740;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.Window;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(524, 17);
            this.toolStripStatusLabel1.Text = "Point of Sales Application  (Bar-Code Scanner and Thermal/ Label Printer Compatib" +
                "ility) .  v1.0.0.0";
            // 
            // button_print
            // 
            this.button_print.BackColor = System.Drawing.Color.Firebrick;
            this.button_print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_print.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_print.ForeColor = System.Drawing.SystemColors.Window;
            this.button_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_print.Location = new System.Drawing.Point(734, 5);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(125, 36);
            this.button_print.TabIndex = 736;
            this.button_print.Text = "Print Record";
            this.button_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_print.UseVisualStyleBackColor = false;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_delete.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.SystemColors.Window;
            this.button_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_delete.Location = new System.Drawing.Point(605, 5);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(125, 36);
            this.button_delete.TabIndex = 735;
            this.button_delete.Text = "Delete Sales";
            this.button_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Visible = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.DarkOrchid;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.branch);
            this.panel1.Controls.Add(this.owner);
            this.panel1.Controls.Add(this.users);
            this.panel1.Controls.Add(this.status);
            this.panel1.Controls.Add(this.user);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.no_of_record);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(13, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 539);
            this.panel1.TabIndex = 730;
            // 
            // owner
            // 
            this.owner.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.owner.Location = new System.Drawing.Point(438, 255);
            this.owner.Name = "owner";
            this.owner.Size = new System.Drawing.Size(121, 27);
            this.owner.TabIndex = 716;
            this.owner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.owner.Visible = false;
            // 
            // users
            // 
            this.users.Location = new System.Drawing.Point(569, 66);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(345, 25);
            this.users.TabIndex = 715;
            this.users.Visible = false;
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(413, 284);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(213, 27);
            this.status.TabIndex = 116;
            this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.status.Visible = false;
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.BackColor = System.Drawing.Color.Green;
            this.user.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.SystemColors.Window;
            this.user.Location = new System.Drawing.Point(358, 287);
            this.user.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(49, 19);
            this.user.TabIndex = 115;
            this.user.Text = "Status";
            this.user.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Firebrick;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Orange;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(10, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(974, 467);
            this.dataGridView1.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(41, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(436, 21);
            this.label5.TabIndex = 53;
            this.label5.Text = "Current Account History/ Sales Record Based on the Selected Criteria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(17, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "No. of Record";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.employee_name);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.amountpaid);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(153, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 45);
            this.panel2.TabIndex = 54;
            this.panel2.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(13, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "Update/ Delete Sales";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Update Sales",
            "Delete Sales"});
            this.comboBox1.Location = new System.Drawing.Point(159, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 56;
            // 
            // employee_name
            // 
            this.employee_name.Location = new System.Drawing.Point(16, 13);
            this.employee_name.Name = "employee_name";
            this.employee_name.Size = new System.Drawing.Size(100, 25);
            this.employee_name.TabIndex = 56;
            this.employee_name.Visible = false;
            this.employee_name.WordWrap = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBox1.Location = new System.Drawing.Point(82, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 21);
            this.checkBox1.TabIndex = 55;
            this.checkBox1.Text = "Update Account";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // amountpaid
            // 
            this.amountpaid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountpaid.Location = new System.Drawing.Point(70, 1);
            this.amountpaid.Name = "amountpaid";
            this.amountpaid.Size = new System.Drawing.Size(89, 22);
            this.amountpaid.TabIndex = 23;
            this.amountpaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.amountpaid.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(6, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Amount";
            this.label9.Visible = false;
            // 
            // no_of_record
            // 
            this.no_of_record.BackColor = System.Drawing.SystemColors.Window;
            this.no_of_record.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_of_record.ForeColor = System.Drawing.Color.MidnightBlue;
            this.no_of_record.Location = new System.Drawing.Point(146, 506);
            this.no_of_record.Name = "no_of_record";
            this.no_of_record.ReadOnly = true;
            this.no_of_record.Size = new System.Drawing.Size(88, 25);
            this.no_of_record.TabIndex = 48;
            this.no_of_record.Text = "NIL";
            this.no_of_record.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // branch
            // 
            this.branch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branch.Location = new System.Drawing.Point(446, 263);
            this.branch.Name = "branch";
            this.branch.Size = new System.Drawing.Size(121, 27);
            this.branch.TabIndex = 887;
            this.branch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.branch.Visible = false;
            // 
            // Report_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.ClientSize = new System.Drawing.Size(1034, 620);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cst_name);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Report_Supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Report_Supplier";
            this.Load += new System.EventHandler(this.Report_Supplier_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ComboBox cst_name;
        public System.Windows.Forms.Button button_export;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.Button button_print;
        public System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox users;
        public System.Windows.Forms.TextBox status;
        public System.Windows.Forms.Label user;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox employee_name;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox amountpaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox no_of_record;
        public System.Windows.Forms.TextBox owner;
        public System.Windows.Forms.TextBox branch;
    }
}