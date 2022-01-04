namespace POS_Eatery
{
    partial class Enhance
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button36 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.owner = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(34, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(118, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 132;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.MidnightBlue;
            this.button36.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button36.ForeColor = System.Drawing.SystemColors.Window;
            this.button36.Location = new System.Drawing.Point(168, 50);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(229, 51);
            this.button36.TabIndex = 131;
            this.button36.Text = "Optimize Database Performance";
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(103, 66);
            this.dataGridView1.TabIndex = 130;
            this.dataGridView1.Visible = false;
            // 
            // owner
            // 
            this.owner.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.owner.Location = new System.Drawing.Point(204, 84);
            this.owner.Name = "owner";
            this.owner.Size = new System.Drawing.Size(121, 27);
            this.owner.TabIndex = 133;
            this.owner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.owner.Visible = false;
            // 
            // Enhance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.ClientSize = new System.Drawing.Size(528, 194);
            this.Controls.Add(this.owner);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Enhance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Enhance";
            this.Load += new System.EventHandler(this.Enhance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox owner;
    }
}