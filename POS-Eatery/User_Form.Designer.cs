namespace POS_Eatery
{
    partial class User_Form
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.owner = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.confirmpassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.titletext = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.loginstatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.currentpost = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.branch = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlText;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 346);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(857, 22);
            this.statusStrip1.TabIndex = 32;
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
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.branch);
            this.panel1.Controls.Add(this.owner);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.confirmpassword);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.titletext);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.username);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.loginstatus);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.currentpost);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lastname);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.firstname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(72, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 268);
            this.panel1.TabIndex = 31;
            // 
            // owner
            // 
            this.owner.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.owner.Location = new System.Drawing.Point(305, 121);
            this.owner.Name = "owner";
            this.owner.Size = new System.Drawing.Size(121, 27);
            this.owner.TabIndex = 682;
            this.owner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.owner.Visible = false;
            // 
            // name
            // 
            this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.LightCoral;
            this.name.FormattingEnabled = true;
            this.name.Items.AddRange(new object[] {
            "Sales Clerk",
            "Employee",
            "Guest",
            "Manager",
            "Admin",
            "Others"});
            this.name.Location = new System.Drawing.Point(145, 59);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(384, 25);
            this.name.TabIndex = 681;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 19);
            this.label8.TabIndex = 680;
            this.label8.Text = "Reg. Employee";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(363, 218);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(114, 38);
            this.button1.TabIndex = 679;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // confirmpassword
            // 
            this.confirmpassword.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpassword.ForeColor = System.Drawing.Color.LightCoral;
            this.confirmpassword.Location = new System.Drawing.Point(145, 182);
            this.confirmpassword.Name = "confirmpassword";
            this.confirmpassword.PasswordChar = '*';
            this.confirmpassword.Size = new System.Drawing.Size(336, 25);
            this.confirmpassword.TabIndex = 677;
            this.confirmpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 19);
            this.label7.TabIndex = 676;
            this.label7.Text = "Confirm Password";
            // 
            // titletext
            // 
            this.titletext.AutoSize = true;
            this.titletext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titletext.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titletext.ForeColor = System.Drawing.Color.Firebrick;
            this.titletext.Location = new System.Drawing.Point(229, 12);
            this.titletext.Name = "titletext";
            this.titletext.Size = new System.Drawing.Size(282, 24);
            this.titletext.TabIndex = 675;
            this.titletext.Text = "Point of Sales User Account Form";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Firebrick;
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Window;
            this.button3.Location = new System.Drawing.Point(488, 218);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(149, 38);
            this.button3.TabIndex = 674;
            this.button3.Text = "Create Account";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.LightCoral;
            this.password.Location = new System.Drawing.Point(490, 143);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(202, 25);
            this.password.TabIndex = 671;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(408, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 670;
            this.label5.Text = "Password";
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.LightCoral;
            this.username.Location = new System.Drawing.Point(145, 140);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(223, 25);
            this.username.TabIndex = 669;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label19.Location = new System.Drawing.Point(247, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(174, 24);
            this.label19.TabIndex = 659;
            this.label19.Text = "User Account Form";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 668;
            this.label6.Text = "User Name";
            // 
            // loginstatus
            // 
            this.loginstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loginstatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginstatus.ForeColor = System.Drawing.Color.Blue;
            this.loginstatus.FormattingEnabled = true;
            this.loginstatus.Items.AddRange(new object[] {
            "Sales Person",
            "Admin",
            "Super User"});
            this.loginstatus.Location = new System.Drawing.Point(488, 104);
            this.loginstatus.Name = "loginstatus";
            this.loginstatus.Size = new System.Drawing.Size(164, 25);
            this.loginstatus.TabIndex = 667;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(388, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 666;
            this.label4.Text = "Login Status";
            // 
            // currentpost
            // 
            this.currentpost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentpost.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentpost.ForeColor = System.Drawing.Color.LightCoral;
            this.currentpost.FormattingEnabled = true;
            this.currentpost.Items.AddRange(new object[] {
            "Sales Clerk",
            "Employee",
            "Guest",
            "Manager",
            "Admin",
            "Others"});
            this.currentpost.Location = new System.Drawing.Point(145, 100);
            this.currentpost.Name = "currentpost";
            this.currentpost.Size = new System.Drawing.Size(193, 25);
            this.currentpost.TabIndex = 665;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 19);
            this.label3.TabIndex = 664;
            this.label3.Text = "Current Post";
            // 
            // lastname
            // 
            this.lastname.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastname.ForeColor = System.Drawing.Color.LightCoral;
            this.lastname.Location = new System.Drawing.Point(513, 32);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(204, 25);
            this.lastname.TabIndex = 663;
            this.lastname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lastname.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(424, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 662;
            this.label2.Text = "Last Name";
            this.label2.Visible = false;
            // 
            // firstname
            // 
            this.firstname.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstname.ForeColor = System.Drawing.Color.LightCoral;
            this.firstname.Location = new System.Drawing.Point(170, 27);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(223, 25);
            this.firstname.TabIndex = 661;
            this.firstname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.firstname.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 660;
            this.label1.Text = "First Name";
            this.label1.Visible = false;
            // 
            // branch
            // 
            this.branch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branch.Location = new System.Drawing.Point(313, 129);
            this.branch.Name = "branch";
            this.branch.Size = new System.Drawing.Size(121, 27);
            this.branch.TabIndex = 891;
            this.branch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.branch.Visible = false;
            // 
            // User_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(857, 368);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "User_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "User_Form";
            this.Load += new System.EventHandler(this.User_Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox confirmpassword;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label titletext;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox username;
        internal System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox currentpost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lastname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstname;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox name;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox loginstatus;
        public System.Windows.Forms.TextBox owner;
        public System.Windows.Forms.TextBox branch;
    }
}