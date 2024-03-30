namespace Moli_app
{
    partial class activeForm
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
            this.txtProductKey = new System.Windows.Forms.TextBox();
            this.btnActive = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbUsed = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbProductKey = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.rtxresult = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Key";
            // 
            // txtProductKey
            // 
            this.txtProductKey.Location = new System.Drawing.Point(122, 43);
            this.txtProductKey.Name = "txtProductKey";
            this.txtProductKey.Size = new System.Drawing.Size(351, 23);
            this.txtProductKey.TabIndex = 1;
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(479, 43);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(75, 23);
            this.btnActive.TabIndex = 2;
            this.btnActive.Text = "Kích hoạt";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbUsed);
            this.groupBox1.Controls.Add(this.lbMinute);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbProductKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(44, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 128);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Key";
            // 
            // lbUsed
            // 
            this.lbUsed.AutoSize = true;
            this.lbUsed.Location = new System.Drawing.Point(121, 70);
            this.lbUsed.Name = "lbUsed";
            this.lbUsed.Size = new System.Drawing.Size(41, 15);
            this.lbUsed.TabIndex = 8;
            this.lbUsed.Text = "0 Phút";
            // 
            // lbMinute
            // 
            this.lbMinute.AutoSize = true;
            this.lbMinute.Location = new System.Drawing.Point(121, 44);
            this.lbMinute.Name = "lbMinute";
            this.lbMinute.Size = new System.Drawing.Size(41, 15);
            this.lbMinute.TabIndex = 7;
            this.lbMinute.Text = "0 Phút";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tổng số phút";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Đã xử dụng";
            // 
            // lbProductKey
            // 
            this.lbProductKey.AutoSize = true;
            this.lbProductKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbProductKey.Location = new System.Drawing.Point(121, 19);
            this.lbProductKey.Name = "lbProductKey";
            this.lbProductKey.Size = new System.Drawing.Size(118, 15);
            this.lbProductKey.TabIndex = 4;
            this.lbProductKey.Text = "XXX-XXX-XXX-XXX";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(479, 218);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Quay về";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // rtxresult
            // 
            this.rtxresult.Location = new System.Drawing.Point(50, 244);
            this.rtxresult.Name = "rtxresult";
            this.rtxresult.Size = new System.Drawing.Size(410, 96);
            this.rtxresult.TabIndex = 6;
            this.rtxresult.Text = "";
            // 
            // activeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 441);
            this.Controls.Add(this.rtxresult);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.txtProductKey);
            this.Controls.Add(this.label1);
            this.Name = "activeForm";
            this.Text = "activeForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductKey;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbUsed;
        private System.Windows.Forms.Label lbMinute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbProductKey;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RichTextBox rtxresult;
    }
}