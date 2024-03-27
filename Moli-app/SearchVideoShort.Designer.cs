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
            this.btnSplitVideoYoutube = new System.Windows.Forms.Button();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPathSplit = new System.Windows.Forms.TextBox();
            this.btnPathSplitOutput = new System.Windows.Forms.Button();
            this.txtChannelName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbMirror = new System.Windows.Forms.CheckBox();
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
            this.btnSearchYoutube.Location = new System.Drawing.Point(632, 26);
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
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvListyoutube
            // 
            this.dgvListyoutube.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListyoutube.Location = new System.Drawing.Point(12, 100);
            this.dgvListyoutube.Name = "dgvListyoutube";
            this.dgvListyoutube.RowTemplate.Height = 25;
            this.dgvListyoutube.Size = new System.Drawing.Size(776, 236);
            this.dgvListyoutube.TabIndex = 4;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(526, 27);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(100, 23);
            this.txtCountry.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quốc gia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số lượng";
            // 
            // txtNumVideo
            // 
            this.txtNumVideo.Location = new System.Drawing.Point(380, 27);
            this.txtNumVideo.Name = "txtNumVideo";
            this.txtNumVideo.Size = new System.Drawing.Size(79, 23);
            this.txtNumVideo.TabIndex = 8;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(12, 477);
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
            this.label4.Location = new System.Drawing.Point(12, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Đường dẫn tải về";
            // 
            // txtPathDownload
            // 
            this.txtPathDownload.Location = new System.Drawing.Point(115, 388);
            this.txtPathDownload.Name = "txtPathDownload";
            this.txtPathDownload.Size = new System.Drawing.Size(221, 23);
            this.txtPathDownload.TabIndex = 11;
            // 
            // btnSelectPathDownload
            // 
            this.btnSelectPathDownload.Location = new System.Drawing.Point(342, 388);
            this.btnSelectPathDownload.Name = "btnSelectPathDownload";
            this.btnSelectPathDownload.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPathDownload.TabIndex = 12;
            this.btnSelectPathDownload.Text = "Chọn";
            this.btnSelectPathDownload.UseVisualStyleBackColor = true;
            this.btnSelectPathDownload.Click += new System.EventHandler(this.btnSelectPathDownload_Click);
            // 
            // btnSplitVideoYoutube
            // 
            this.btnSplitVideoYoutube.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSplitVideoYoutube.Location = new System.Drawing.Point(569, 477);
            this.btnSplitVideoYoutube.Name = "btnSplitVideoYoutube";
            this.btnSplitVideoYoutube.Size = new System.Drawing.Size(219, 61);
            this.btnSplitVideoYoutube.TabIndex = 14;
            this.btnSplitVideoYoutube.Text = "Tách video";
            this.btnSplitVideoYoutube.UseVisualStyleBackColor = false;
            this.btnSplitVideoYoutube.Click += new System.EventHandler(this.btnSplitVideoYoutube_Click);
            // 
            // rtbResult
            // 
            this.rtbResult.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtbResult.Location = new System.Drawing.Point(224, 477);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(339, 61);
            this.rtbResult.TabIndex = 15;
            this.rtbResult.Text = "";
            this.rtbResult.TextChanged += new System.EventHandler(this.rtbResult_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(423, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tách video";
            // 
            // txtPathSplit
            // 
            this.txtPathSplit.Location = new System.Drawing.Point(492, 391);
            this.txtPathSplit.Name = "txtPathSplit";
            this.txtPathSplit.Size = new System.Drawing.Size(215, 23);
            this.txtPathSplit.TabIndex = 17;
            // 
            // btnPathSplitOutput
            // 
            this.btnPathSplitOutput.Location = new System.Drawing.Point(713, 392);
            this.btnPathSplitOutput.Name = "btnPathSplitOutput";
            this.btnPathSplitOutput.Size = new System.Drawing.Size(75, 23);
            this.btnPathSplitOutput.TabIndex = 18;
            this.btnPathSplitOutput.Text = "Chọn";
            this.btnPathSplitOutput.UseVisualStyleBackColor = true;
            this.btnPathSplitOutput.Click += new System.EventHandler(this.btnPathSplitOutput_Click);
            // 
            // txtChannelName
            // 
            this.txtChannelName.Location = new System.Drawing.Point(81, 71);
            this.txtChannelName.Name = "txtChannelName";
            this.txtChannelName.Size = new System.Drawing.Size(233, 23);
            this.txtChannelName.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Channel ";
            // 
            // cbMirror
            // 
            this.cbMirror.AutoSize = true;
            this.cbMirror.Checked = true;
            this.cbMirror.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMirror.Location = new System.Drawing.Point(12, 439);
            this.cbMirror.Name = "cbMirror";
            this.cbMirror.Size = new System.Drawing.Size(113, 19);
            this.cbMirror.TabIndex = 22;
            this.cbMirror.Text = "Hiệu ứng gương";
            this.cbMirror.UseVisualStyleBackColor = true;
            // 
            // SearchVideoShort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.cbMirror);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtChannelName);
            this.Controls.Add(this.btnPathSplitOutput);
            this.Controls.Add(this.txtPathSplit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.btnSplitVideoYoutube);
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
        private System.Windows.Forms.Button btnSplitVideoYoutube;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPathSplit;
        private System.Windows.Forms.Button btnPathSplitOutput;
        private System.Windows.Forms.TextBox txtChannelName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbMirror;
    }
}