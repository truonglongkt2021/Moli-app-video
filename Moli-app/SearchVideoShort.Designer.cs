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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumVideo = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPathDownload = new System.Windows.Forms.TextBox();
            this.btnSelectPathDownload = new System.Windows.Forms.Button();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.cbISChannelName = new System.Windows.Forms.CheckBox();
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
            this.btnSearchYoutube.Location = new System.Drawing.Point(12, 123);
            this.btnSearchYoutube.Name = "btnSearchYoutube";
            this.btnSearchYoutube.Size = new System.Drawing.Size(405, 33);
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
            this.btnBack.Location = new System.Drawing.Point(320, 27);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(97, 90);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Quay Về";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvListyoutube
            // 
            this.dgvListyoutube.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListyoutube.Location = new System.Drawing.Point(12, 162);
            this.dgvListyoutube.Name = "dgvListyoutube";
            this.dgvListyoutube.RowTemplate.Height = 25;
            this.dgvListyoutube.Size = new System.Drawing.Size(405, 174);
            this.dgvListyoutube.TabIndex = 4;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(227, 94);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(87, 23);
            this.txtCountry.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quốc gia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số lượng";
            // 
            // txtNumVideo
            // 
            this.txtNumVideo.Location = new System.Drawing.Point(81, 94);
            this.txtNumVideo.Name = "txtNumVideo";
            this.txtNumVideo.Size = new System.Drawing.Size(79, 23);
            this.txtNumVideo.TabIndex = 8;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(12, 403);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(206, 61);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "Tải về";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Đường dẫn tải về";
            // 
            // txtPathDownload
            // 
            this.txtPathDownload.Location = new System.Drawing.Point(115, 357);
            this.txtPathDownload.Name = "txtPathDownload";
            this.txtPathDownload.Size = new System.Drawing.Size(221, 23);
            this.txtPathDownload.TabIndex = 11;
            // 
            // btnSelectPathDownload
            // 
            this.btnSelectPathDownload.Location = new System.Drawing.Point(342, 357);
            this.btnSelectPathDownload.Name = "btnSelectPathDownload";
            this.btnSelectPathDownload.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPathDownload.TabIndex = 12;
            this.btnSelectPathDownload.Text = "Chọn";
            this.btnSelectPathDownload.UseVisualStyleBackColor = true;
            this.btnSelectPathDownload.Click += new System.EventHandler(this.btnSelectPathDownload_Click);
            // 
            // rtbResult
            // 
            this.rtbResult.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtbResult.Location = new System.Drawing.Point(224, 403);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(193, 61);
            this.rtbResult.TabIndex = 15;
            this.rtbResult.Text = "";
            this.rtbResult.TextChanged += new System.EventHandler(this.rtbResult_TextChanged);
            // 
            // cbISChannelName
            // 
            this.cbISChannelName.AutoSize = true;
            this.cbISChannelName.Location = new System.Drawing.Point(12, 64);
            this.cbISChannelName.Name = "cbISChannelName";
            this.cbISChannelName.Size = new System.Drawing.Size(132, 19);
            this.cbISChannelName.TabIndex = 22;
            this.cbISChannelName.Text = "Từ Khóa là Tên Kênh";
            this.cbISChannelName.UseVisualStyleBackColor = true;
            // 
            // SearchVideoShort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 484);
            this.Controls.Add(this.cbISChannelName);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.btnSelectPathDownload);
            this.Controls.Add(this.txtPathDownload);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtNumVideo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.dgvListyoutube);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.btnSearchYoutube);
            this.Controls.Add(this.label1);
            this.Name = "SearchVideoShort";
            this.Text = "SearchVideoShort";
            this.Load += new System.EventHandler(this.SearchVideoShort_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumVideo;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPathDownload;
        private System.Windows.Forms.Button btnSelectPathDownload;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.CheckBox cbISChannelName;
    }
}