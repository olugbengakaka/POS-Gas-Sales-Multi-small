namespace POS_Eatery
{
    partial class Sact
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
            this.act_key = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.school_id = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(105, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 22);
            this.label1.TabIndex = 136;
            this.label1.Text = "Enter Your SMS Activation Key";
            // 
            // act_key
            // 
            this.act_key.BackColor = System.Drawing.SystemColors.Window;
            this.act_key.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.act_key.ForeColor = System.Drawing.Color.DeepPink;
            this.act_key.Location = new System.Drawing.Point(109, 61);
            this.act_key.Name = "act_key";
            this.act_key.Size = new System.Drawing.Size(433, 29);
            this.act_key.TabIndex = 135;
            this.act_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Purple;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(367, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 37);
            this.button2.TabIndex = 134;
            this.button2.Text = "Activate SMS";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.Window;
            this.label29.Location = new System.Drawing.Point(105, 106);
            this.label29.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(168, 22);
            this.label29.TabIndex = 133;
            this.label29.Text = "Enter Your User ID";
            // 
            // school_id
            // 
            this.school_id.BackColor = System.Drawing.SystemColors.Window;
            this.school_id.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.school_id.ForeColor = System.Drawing.Color.DeepPink;
            this.school_id.Location = new System.Drawing.Point(109, 130);
            this.school_id.Name = "school_id";
            this.school_id.Size = new System.Drawing.Size(385, 29);
            this.school_id.TabIndex = 132;
            this.school_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Sact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(647, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.act_key);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.school_id);
            this.Name = "Sact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox act_key;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox school_id;
    }
}