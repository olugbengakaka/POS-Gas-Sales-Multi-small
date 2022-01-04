namespace POS_Eatery
{
    partial class Refactor
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
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.panel_ax = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.image_loading = new System.Windows.Forms.PictureBox();
            this.month1 = new System.Windows.Forms.ComboBox();
            this.year1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            this.panel_ax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_loading)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start Task";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView7
            // 
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Location = new System.Drawing.Point(75, 145);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.Size = new System.Drawing.Size(79, 23);
            this.dataGridView7.TabIndex = 131;
            this.dataGridView7.Visible = false;
            // 
            // panel_ax
            // 
            this.panel_ax.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel_ax.Controls.Add(this.label5);
            this.panel_ax.Controls.Add(this.image_loading);
            this.panel_ax.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_ax.ForeColor = System.Drawing.SystemColors.Window;
            this.panel_ax.Location = new System.Drawing.Point(42, 17);
            this.panel_ax.Name = "panel_ax";
            this.panel_ax.Size = new System.Drawing.Size(390, 36);
            this.panel_ax.TabIndex = 516;
            this.panel_ax.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 18);
            this.label5.TabIndex = 109;
            this.label5.Text = "Loading, please wait ...";
            // 
            // image_loading
            // 
            this.image_loading.BackColor = System.Drawing.Color.Transparent;
            this.image_loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.image_loading.Location = new System.Drawing.Point(33, 2);
            this.image_loading.Name = "image_loading";
            this.image_loading.Size = new System.Drawing.Size(42, 30);
            this.image_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_loading.TabIndex = 87;
            this.image_loading.TabStop = false;
            // 
            // month1
            // 
            this.month1.BackColor = System.Drawing.SystemColors.Window;
            this.month1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.month1.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.month1.Location = new System.Drawing.Point(205, 77);
            this.month1.Name = "month1";
            this.month1.Size = new System.Drawing.Size(147, 26);
            this.month1.TabIndex = 805;
            // 
            // year1
            // 
            this.year1.BackColor = System.Drawing.SystemColors.Window;
            this.year1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.year1.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year1.ForeColor = System.Drawing.Color.Firebrick;
            this.year1.FormattingEnabled = true;
            this.year1.Items.AddRange(new object[] {
            "Year",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.year1.Location = new System.Drawing.Point(42, 77);
            this.year1.Name = "year1";
            this.year1.Size = new System.Drawing.Size(131, 26);
            this.year1.TabIndex = 804;
            // 
            // Refactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.ClientSize = new System.Drawing.Size(462, 213);
            this.Controls.Add(this.month1);
            this.Controls.Add(this.year1);
            this.Controls.Add(this.panel_ax);
            this.Controls.Add(this.dataGridView7);
            this.Controls.Add(this.button1);
            this.Name = "Refactor";
            this.Text = "Refactor";
            this.Load += new System.EventHandler(this.Refactor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            this.panel_ax.ResumeLayout(false);
            this.panel_ax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.Panel panel_ax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox image_loading;
        private System.Windows.Forms.ComboBox month1;
        private System.Windows.Forms.ComboBox year1;
    }
}