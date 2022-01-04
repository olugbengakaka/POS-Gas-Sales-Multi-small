namespace POS_Eatery
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.branch = new System.Windows.Forms.TextBox();
            this.s_time = new System.Windows.Forms.TextBox();
            this.s_date = new System.Windows.Forms.TextBox();
            this.s_year = new System.Windows.Forms.TextBox();
            this.s_month = new System.Windows.Forms.TextBox();
            this.s_day = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(937, 406);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(581, 687);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(679, 687);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.VisibleChanged += new System.EventHandler(this.button2_VisibleChanged);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(45, 456);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(937, 222);
            this.dataGridView2.TabIndex = 3;
            // 
            // branch
            // 
            this.branch.Location = new System.Drawing.Point(311, 13);
            this.branch.Name = "branch";
            this.branch.Size = new System.Drawing.Size(183, 20);
            this.branch.TabIndex = 4;
            this.branch.Visible = false;
            // 
            // s_time
            // 
            this.s_time.Location = new System.Drawing.Point(806, 13);
            this.s_time.Name = "s_time";
            this.s_time.Size = new System.Drawing.Size(37, 20);
            this.s_time.TabIndex = 701;
            this.s_time.Visible = false;
            // 
            // s_date
            // 
            this.s_date.Location = new System.Drawing.Point(760, 13);
            this.s_date.Name = "s_date";
            this.s_date.Size = new System.Drawing.Size(40, 20);
            this.s_date.TabIndex = 700;
            this.s_date.Visible = false;
            // 
            // s_year
            // 
            this.s_year.Location = new System.Drawing.Point(698, 13);
            this.s_year.Name = "s_year";
            this.s_year.Size = new System.Drawing.Size(56, 20);
            this.s_year.TabIndex = 699;
            this.s_year.Visible = false;
            // 
            // s_month
            // 
            this.s_month.Location = new System.Drawing.Point(636, 13);
            this.s_month.Name = "s_month";
            this.s_month.Size = new System.Drawing.Size(56, 20);
            this.s_month.TabIndex = 698;
            this.s_month.Visible = false;
            // 
            // s_day
            // 
            this.s_day.Location = new System.Drawing.Point(574, 13);
            this.s_day.Name = "s_day";
            this.s_day.Size = new System.Drawing.Size(56, 20);
            this.s_day.TabIndex = 697;
            this.s_day.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 734);
            this.Controls.Add(this.s_time);
            this.Controls.Add(this.s_date);
            this.Controls.Add(this.s_year);
            this.Controls.Add(this.s_month);
            this.Controls.Add(this.s_day);
            this.Controls.Add(this.branch);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        public System.Windows.Forms.TextBox branch;
        public System.Windows.Forms.TextBox s_time;
        public System.Windows.Forms.TextBox s_date;
        public System.Windows.Forms.TextBox s_year;
        public System.Windows.Forms.TextBox s_month;
        public System.Windows.Forms.TextBox s_day;
    }
}