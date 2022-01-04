namespace POS_Eatery
{
    partial class Report_Expenditure
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
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.button_export = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_print = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.day = new System.Windows.Forms.ComboBox();
            this.month = new System.Windows.Forms.ComboBox();
            this.year = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.branch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.owner = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.employee_name = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.amountpaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.no_of_record = new System.Windows.Forms.TextBox();
            this.total_expenses = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.day1 = new System.Windows.Forms.ComboBox();
            this.month1 = new System.Windows.Forms.ComboBox();
            this.year1 = new System.Windows.Forms.ComboBox();
            this.expenditure = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.Firebrick;
            this.button_export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_export.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.ForeColor = System.Drawing.SystemColors.Window;
            this.button_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_export.Location = new System.Drawing.Point(917, 18);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(125, 36);
            this.button_export.TabIndex = 742;
            this.button_export.Text = "Export to Excel";
            this.button_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_export.UseVisualStyleBackColor = false;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Firebrick;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 629);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1074, 22);
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
            this.button_print.Location = new System.Drawing.Point(788, 18);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(125, 36);
            this.button_print.TabIndex = 736;
            this.button_print.Text = "Print Record";
            this.button_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_print.UseVisualStyleBackColor = false;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_delete.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.SystemColors.Window;
            this.button_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_delete.Location = new System.Drawing.Point(659, 18);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(125, 36);
            this.button_delete.TabIndex = 735;
            this.button_delete.Text = "Delete Record";
            this.button_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // day
            // 
            this.day.BackColor = System.Drawing.SystemColors.Window;
            this.day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.day.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day.ForeColor = System.Drawing.Color.Firebrick;
            this.day.FormattingEnabled = true;
            this.day.Items.AddRange(new object[] {
            "Day",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.day.Location = new System.Drawing.Point(177, 29);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(76, 25);
            this.day.TabIndex = 734;
            this.day.SelectedIndexChanged += new System.EventHandler(this.day_SelectedIndexChanged);
            // 
            // month
            // 
            this.month.BackColor = System.Drawing.SystemColors.Window;
            this.month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.month.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month.ForeColor = System.Drawing.Color.Firebrick;
            this.month.FormattingEnabled = true;
            this.month.Items.AddRange(new object[] {
            "Month",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.month.Location = new System.Drawing.Point(98, 29);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(73, 25);
            this.month.TabIndex = 732;
            this.month.SelectedIndexChanged += new System.EventHandler(this.month_SelectedIndexChanged);
            // 
            // year
            // 
            this.year.BackColor = System.Drawing.SystemColors.Window;
            this.year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.year.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year.ForeColor = System.Drawing.Color.Firebrick;
            this.year.FormattingEnabled = true;
            this.year.Items.AddRange(new object[] {
            "Year",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022"});
            this.year.Location = new System.Drawing.Point(13, 29);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(79, 25);
            this.year.TabIndex = 731;
            this.year.SelectedIndexChanged += new System.EventHandler(this.year_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.DarkOrchid;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.branch);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.owner);
            this.panel1.Controls.Add(this.status);
            this.panel1.Controls.Add(this.user);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.no_of_record);
            this.panel1.Controls.Add(this.total_expenses);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 539);
            this.panel1.TabIndex = 730;
            // 
            // branch
            // 
            this.branch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branch.Location = new System.Drawing.Point(466, 263);
            this.branch.Name = "branch";
            this.branch.Size = new System.Drawing.Size(121, 27);
            this.branch.TabIndex = 887;
            this.branch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.branch.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 129;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // owner
            // 
            this.owner.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.owner.Location = new System.Drawing.Point(458, 255);
            this.owner.Name = "owner";
            this.owner.Size = new System.Drawing.Size(121, 27);
            this.owner.TabIndex = 127;
            this.owner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.owner.Visible = false;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Orange;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
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
            this.dataGridView1.Size = new System.Drawing.Size(1014, 467);
            this.dataGridView1.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(194, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(436, 21);
            this.label5.TabIndex = 53;
            this.label5.Text = "Current Account History/ Sales Record Based on the Selected Criteria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(472, 512);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 51;
            this.label4.Text = "NGN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(45, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "No. of Records";
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
            this.no_of_record.Location = new System.Drawing.Point(151, 506);
            this.no_of_record.Name = "no_of_record";
            this.no_of_record.ReadOnly = true;
            this.no_of_record.Size = new System.Drawing.Size(88, 25);
            this.no_of_record.TabIndex = 48;
            this.no_of_record.Text = "NIL";
            this.no_of_record.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // total_expenses
            // 
            this.total_expenses.BackColor = System.Drawing.SystemColors.Window;
            this.total_expenses.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_expenses.ForeColor = System.Drawing.Color.MidnightBlue;
            this.total_expenses.Location = new System.Drawing.Point(359, 508);
            this.total_expenses.Name = "total_expenses";
            this.total_expenses.ReadOnly = true;
            this.total_expenses.Size = new System.Drawing.Size(110, 25);
            this.total_expenses.TabIndex = 46;
            this.total_expenses.Text = "NIL";
            this.total_expenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(248, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Total Expenditure";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(12, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 19);
            this.label7.TabIndex = 716;
            this.label7.Text = "Year";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(100, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 19);
            this.label8.TabIndex = 743;
            this.label8.Text = "Month";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Window;
            this.label12.Location = new System.Drawing.Point(177, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 19);
            this.label12.TabIndex = 744;
            this.label12.Text = "Day";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(257, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(7, 71);
            this.panel3.TabIndex = 117;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Location = new System.Drawing.Point(649, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(7, 71);
            this.panel4.TabIndex = 118;
            // 
            // day1
            // 
            this.day1.BackColor = System.Drawing.SystemColors.Window;
            this.day1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.day1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day1.ForeColor = System.Drawing.Color.Firebrick;
            this.day1.FormattingEnabled = true;
            this.day1.Items.AddRange(new object[] {
            "Day",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.day1.Location = new System.Drawing.Point(544, 40);
            this.day1.Name = "day1";
            this.day1.Size = new System.Drawing.Size(76, 25);
            this.day1.TabIndex = 747;
            this.day1.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // month1
            // 
            this.month1.BackColor = System.Drawing.SystemColors.Window;
            this.month1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.month1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month1.ForeColor = System.Drawing.Color.Firebrick;
            this.month1.FormattingEnabled = true;
            this.month1.Items.AddRange(new object[] {
            "Month",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.month1.Location = new System.Drawing.Point(448, 40);
            this.month1.Name = "month1";
            this.month1.Size = new System.Drawing.Size(90, 25);
            this.month1.TabIndex = 746;
            this.month1.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // year1
            // 
            this.year1.BackColor = System.Drawing.SystemColors.Window;
            this.year1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.year1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year1.ForeColor = System.Drawing.Color.Firebrick;
            this.year1.FormattingEnabled = true;
            this.year1.Items.AddRange(new object[] {
            "Year",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022"});
            this.year1.Location = new System.Drawing.Point(279, 40);
            this.year1.Name = "year1";
            this.year1.Size = new System.Drawing.Size(163, 25);
            this.year1.TabIndex = 745;
            this.year1.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // expenditure
            // 
            this.expenditure.BackColor = System.Drawing.SystemColors.Window;
            this.expenditure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expenditure.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenditure.ForeColor = System.Drawing.Color.Firebrick;
            this.expenditure.FormattingEnabled = true;
            this.expenditure.Items.AddRange(new object[] {
            "Year",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018"});
            this.expenditure.Location = new System.Drawing.Point(279, 7);
            this.expenditure.Name = "expenditure";
            this.expenditure.Size = new System.Drawing.Size(341, 25);
            this.expenditure.TabIndex = 748;
            this.expenditure.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // Report_Expenditure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.ClientSize = new System.Drawing.Size(1074, 651);
            this.Controls.Add(this.expenditure);
            this.Controls.Add(this.day1);
            this.Controls.Add(this.month1);
            this.Controls.Add(this.year1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.day);
            this.Controls.Add(this.month);
            this.Controls.Add(this.year);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Report_Expenditure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Report_Expenditure";
            this.Load += new System.EventHandler(this.Report_Expenditure_Load);
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

        private System.Windows.Forms.PrintDialog printDialog1;
        public System.Windows.Forms.Button button_export;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.Button button_print;
        public System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.ComboBox day;
        private System.Windows.Forms.ComboBox month;
        private System.Windows.Forms.ComboBox year;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox status;
        public System.Windows.Forms.Label user;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox employee_name;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox amountpaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox no_of_record;
        private System.Windows.Forms.TextBox total_expenses;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox day1;
        private System.Windows.Forms.ComboBox month1;
        private System.Windows.Forms.ComboBox year1;
        private System.Windows.Forms.ComboBox expenditure;
        public System.Windows.Forms.TextBox owner;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox branch;
    }
}