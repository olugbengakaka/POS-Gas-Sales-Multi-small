namespace POS_Eatery
{
    partial class ssssss
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
            this.button1 = new System.Windows.Forms.Button();
            this.s_t = new System.Windows.Forms.TextBox();
            this.receipient = new System.Windows.Forms.TextBox();
            this.body = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // s_t
            // 
            this.s_t.Location = new System.Drawing.Point(112, 35);
            this.s_t.Name = "s_t";
            this.s_t.Size = new System.Drawing.Size(157, 20);
            this.s_t.TabIndex = 1;
            // 
            // receipient
            // 
            this.receipient.Location = new System.Drawing.Point(112, 80);
            this.receipient.Name = "receipient";
            this.receipient.Size = new System.Drawing.Size(157, 20);
            this.receipient.TabIndex = 2;
            // 
            // body
            // 
            this.body.Location = new System.Drawing.Point(112, 125);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(157, 20);
            this.body.TabIndex = 3;
            // 
            // ssssss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 343);
            this.Controls.Add(this.body);
            this.Controls.Add(this.receipient);
            this.Controls.Add(this.s_t);
            this.Controls.Add(this.button1);
            this.Name = "ssssss";
            this.Text = "ssssss";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox s_t;
        private System.Windows.Forms.TextBox receipient;
        private System.Windows.Forms.TextBox body;
    }
}