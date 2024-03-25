namespace Moli_app
{
    partial class SearchVideoShort
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
            this.btnSearchYoutube = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvListyoutube = new System.Windows.Forms.DataGridView();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListyoutube)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ Khóa";
            // 
            // btnSearchYoutube
            // 
            this.btnSearchYoutube.Location = new System.Drawing.Point(508, 27);
            this.btnSearchYoutube.Name = "btnSearchYoutube";
            this.btnSearchYoutube.Size = new System.Drawing.Size(75, 23);
            this.btnSearchYoutube.TabIndex = 1;
            this.btnSearchYoutube.Text = "Tìm Kiếm";
            this.btnSearchYoutube.UseVisualStyleBackColor = true;
            this.btnSearchYoutube.Click += new System.EventHandler(this.btnSearchYoutube_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(81, 27);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(233, 23);
            this.txtKeyword.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBack.Location = new System.Drawing.Point(713, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 41);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Quay Về";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // dgvListyoutube
            // 
            this.dgvListyoutube.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListyoutube.Location = new System.Drawing.Point(12, 69);
            this.dgvListyoutube.Name = "dgvListyoutube";
            this.dgvListyoutube.RowTemplate.Height = 25;
            this.dgvListyoutube.Size = new System.Drawing.Size(776, 236);
            this.dgvListyoutube.TabIndex = 4;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(402, 28);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(100, 23);
            this.txtCountry.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quốc gia";
            // 
            // SearchVideoShort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.dgvListyoutube);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.btnSearchYoutube);
            this.Controls.Add(this.label1);
            this.Name = "SearchVideoShort";
            this.Text = "SearchVideoShort";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListyoutube)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchYoutube;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvListyoutube;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label2;
    }
}