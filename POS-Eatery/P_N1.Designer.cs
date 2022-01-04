namespace POS_Eatery
{
    partial class P_N1
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
            this.label1 = new System.Windows.Forms.Label();
            this.receipt_date = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.name_admin = new System.Windows.Forms.TextBox();
            this.name_sales = new System.Windows.Forms.TextBox();
            this.branch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(103, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "User Name";
            // 
            // receipt_date
            // 
            this.receipt_date.AutoSize = true;
            this.receipt_date.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receipt_date.ForeColor = System.Drawing.SystemColors.ControlText;
            this.receipt_date.Location = new System.Drawing.Point(103, 92);
            this.receipt_date.Name = "receipt_date";
            this.receipt_date.Size = new System.Drawing.Size(86, 22);
            this.receipt_date.TabIndex = 10;
            this.receipt_date.Text = "Password";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(107, 120);
            this.password.Name = "password";
            this.password.PasswordChar = '-';
            this.password.Size = new System.Drawing.Size(232, 26);
            this.password.TabIndex = 9;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(107, 57);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(232, 26);
            this.username.TabIndex = 8;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // name_admin
            // 
            this.name_admin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_admin.Location = new System.Drawing.Point(65, 12);
            this.name_admin.Name = "name_admin";
            this.name_admin.Size = new System.Drawing.Size(121, 27);
            this.name_admin.TabIndex = 711;
            this.name_admin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name_admin.Visible = false;
            // 
            // name_sales
            // 
            this.name_sales.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_sales.Location = new System.Drawing.Point(192, 12);
            this.name_sales.Name = "name_sales";
            this.name_sales.Size = new System.Drawing.Size(121, 27);
            this.name_sales.TabIndex = 710;
            this.name_sales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name_sales.Visible = false;
            // 
            // branch
            // 
            this.branch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branch.Location = new System.Drawing.Point(319, 12);
            this.branch.Name = "branch";
            this.branch.Size = new System.Drawing.Size(121, 27);
            this.branch.TabIndex = 712;
            this.branch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.branch.Visible = false;
            // 
            // P_N1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleVioletRed;
            this.ClientSize = new System.Drawing.Size(475, 236);
            this.Controls.Add(this.branch);
            this.Controls.Add(this.name_admin);
            this.Controls.Add(this.name_sales);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.receipt_date);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.button1);
            this.Name = "P_N1";
            this.Text = "P_N1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label receipt_date;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox name_admin;
        public System.Windows.Forms.TextBox name_sales;
        public System.Windows.Forms.TextBox branch;
    }
}