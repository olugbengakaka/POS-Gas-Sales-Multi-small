namespace POS_Eatery
{
    partial class Form10
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
            this.s_day = new System.Windows.Forms.TextBox();
            this.s_month = new System.Windows.Forms.TextBox();
            this.s_year = new System.Windows.Forms.TextBox();
            this.s_date = new System.Windows.Forms.TextBox();
            this.s_time = new System.Windows.Forms.TextBox();
            this.branch = new System.Windows.Forms.TextBox();
            this.wb1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // s_day
            // 
            this.s_day.Location = new System.Drawing.Point(38, 29);
            this.s_day.Name = "s_day";
            this.s_day.Size = new System.Drawing.Size(56, 20);
            this.s_day.TabIndex = 0;
            this.s_day.Visible = false;
            // 
            // s_month
            // 
            this.s_month.Location = new System.Drawing.Point(100, 29);
            this.s_month.Name = "s_month";
            this.s_month.Size = new System.Drawing.Size(56, 20);
            this.s_month.TabIndex = 1;
            this.s_month.Visible = false;
            // 
            // s_year
            // 
            this.s_year.Location = new System.Drawing.Point(162, 29);
            this.s_year.Name = "s_year";
            this.s_year.Size = new System.Drawing.Size(56, 20);
            this.s_year.TabIndex = 2;
            this.s_year.Visible = false;
            // 
            // s_date
            // 
            this.s_date.Location = new System.Drawing.Point(267, 29);
            this.s_date.Name = "s_date";
            this.s_date.Size = new System.Drawing.Size(40, 20);
            this.s_date.TabIndex = 3;
            this.s_date.Visible = false;
            // 
            // s_time
            // 
            this.s_time.Location = new System.Drawing.Point(224, 29);
            this.s_time.Name = "s_time";
            this.s_time.Size = new System.Drawing.Size(37, 20);
            this.s_time.TabIndex = 4;
            this.s_time.Visible = false;
            // 
            // branch
            // 
            this.branch.Location = new System.Drawing.Point(288, 100);
            this.branch.Name = "branch";
            this.branch.Size = new System.Drawing.Size(180, 20);
            this.branch.TabIndex = 5;
            this.branch.Visible = false;
            // 
            // wb1
            // 
            this.wb1.Location = new System.Drawing.Point(458, 29);
            this.wb1.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb1.Name = "wb1";
            this.wb1.Size = new System.Drawing.Size(59, 46);
            this.wb1.TabIndex = 6;
            this.wb1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(183, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "ONGOING SERVER VERIFICATION ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(312, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "Please, wait ...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(854, 383);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wb1);
            this.Controls.Add(this.branch);
            this.Controls.Add(this.s_time);
            this.Controls.Add(this.s_date);
            this.Controls.Add(this.s_year);
            this.Controls.Add(this.s_month);
            this.Controls.Add(this.s_day);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Verification Module";
            this.Load += new System.EventHandler(this.Form10_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox s_day;
        private System.Windows.Forms.TextBox s_month;
        private System.Windows.Forms.TextBox s_year;
        private System.Windows.Forms.TextBox s_date;
        private System.Windows.Forms.TextBox s_time;
        public System.Windows.Forms.TextBox branch;
        private System.Windows.Forms.WebBrowser wb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}