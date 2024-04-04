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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchVideoShort));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchYoutube = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvListyoutube = new System.Windows.Forms.DataGridView();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumVideo = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPathDownload = new System.Windows.Forms.TextBox();
            this.btnSelectPathDownload = new System.Windows.Forms.Button();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.cbISChannelName = new System.Windows.Forms.CheckBox();
            this.cbShortVideo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListyoutube)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.btnSearchYoutube.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearchYoutube.Location = new System.Drawing.Point(12, 170);
            this.btnSearchYoutube.Name = "btnSearchYoutube";
            this.btnSearchYoutube.Size = new System.Drawing.Size(302, 33);
            this.btnSearchYoutube.TabIndex = 1;
            this.btnSearchYoutube.Text = "Tìm Kiếm";
            this.btnSearchYoutube.UseVisualStyleBackColor = false;
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
            this.btnBack.Location = new System.Drawing.Point(320, 27);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 527);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Quay Về";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvListyoutube
            // 
            this.dgvListyoutube.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListyoutube.Location = new System.Drawing.Point(12, 209);
            this.dgvListyoutube.Name = "dgvListyoutube";
            this.dgvListyoutube.RowTemplate.Height = 25;
            this.dgvListyoutube.Size = new System.Drawing.Size(302, 174);
            this.dgvListyoutube.TabIndex = 4;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(235, 82);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(79, 23);
            this.txtCountry.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quốc gia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số lượng";
            // 
            // txtNumVideo
            // 
            this.txtNumVideo.Location = new System.Drawing.Point(235, 54);
            this.txtNumVideo.Name = "txtNumVideo";
            this.txtNumVideo.Size = new System.Drawing.Size(79, 23);
            this.txtNumVideo.TabIndex = 8;
            this.txtNumVideo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(12, 442);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(302, 32);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "Tải về";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Đường dẫn tải về";
            // 
            // txtPathDownload
            // 
            this.txtPathDownload.Location = new System.Drawing.Point(12, 413);
            this.txtPathDownload.Name = "txtPathDownload";
            this.txtPathDownload.Size = new System.Drawing.Size(207, 23);
            this.txtPathDownload.TabIndex = 11;
            // 
            // btnSelectPathDownload
            // 
            this.btnSelectPathDownload.Location = new System.Drawing.Point(225, 413);
            this.btnSelectPathDownload.Name = "btnSelectPathDownload";
            this.btnSelectPathDownload.Size = new System.Drawing.Size(89, 23);
            this.btnSelectPathDownload.TabIndex = 12;
            this.btnSelectPathDownload.Text = "Chọn";
            this.btnSelectPathDownload.UseVisualStyleBackColor = true;
            this.btnSelectPathDownload.Click += new System.EventHandler(this.btnSelectPathDownload_Click);
            // 
            // rtbResult
            // 
            this.rtbResult.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtbResult.Location = new System.Drawing.Point(12, 478);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(302, 76);
            this.rtbResult.TabIndex = 15;
            this.rtbResult.Text = "";
            this.rtbResult.TextChanged += new System.EventHandler(this.rtbResult_TextChanged);
            // 
            // cbISChannelName
            // 
            this.cbISChannelName.AutoSize = true;
            this.cbISChannelName.Location = new System.Drawing.Point(12, 86);
            this.cbISChannelName.Name = "cbISChannelName";
            this.cbISChannelName.Size = new System.Drawing.Size(132, 19);
            this.cbISChannelName.TabIndex = 22;
            this.cbISChannelName.Text = "Từ Khóa là Tên Kênh";
            this.cbISChannelName.UseVisualStyleBackColor = true;
            // 
            // cbShortVideo
            // 
            this.cbShortVideo.AutoSize = true;
            this.cbShortVideo.Location = new System.Drawing.Point(12, 56);
            this.cbShortVideo.Name = "cbShortVideo";
            this.cbShortVideo.Size = new System.Drawing.Size(97, 19);
            this.cbShortVideo.TabIndex = 23;
            this.cbShortVideo.Text = "Tìm Short Vid";
            this.cbShortVideo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtToDate);
            this.groupBox1.Controls.Add(this.txtFromDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 53);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ngày Đăng ( Định dạng: yyyyMMdd)";
            // 
            // txtToDate
            // 
            this.txtToDate.Enabled = false;
            this.txtToDate.Location = new System.Drawing.Point(175, 22);
            this.txtToDate.MaxLength = 8;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(100, 23);
            this.txtToDate.TabIndex = 3;
            this.txtToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Enabled = false;
            this.txtFromDate.Location = new System.Drawing.Point(35, 22);
            this.txtFromDate.MaxLength = 8;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(100, 23);
            this.txtFromDate.TabIndex = 2;
            this.txtFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Đến";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Từ";
            // 
            // SearchVideoShort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbShortVideo);
            this.Controls.Add(this.cbISChannelName);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.btnSelectPathDownload);
            this.Controls.Add(this.txtPathDownload);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtNumVideo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.dgvListyoutube);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.btnSearchYoutube);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchVideoShort";
            this.Text = "SearchVideoShort";
            this.Load += new System.EventHandler(this.SearchVideoShort_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListyoutube)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumVideo;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPathDownload;
        private System.Windows.Forms.Button btnSelectPathDownload;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.CheckBox cbISChannelName;
        private System.Windows.Forms.CheckBox cbShortVideo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}