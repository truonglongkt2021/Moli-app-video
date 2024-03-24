namespace Moli_app
{
    partial class MergeVideo
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
            this.lbtotalDurationVideo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTotalVideoSource = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSourceVideoMerge = new System.Windows.Forms.TextBox();
            this.btnSelectVideoMerge = new System.Windows.Forms.Button();
            this.btnMergeVideo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDurationVideo = new System.Windows.Forms.TextBox();
            this.txtNumOfVideo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvListOutput = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceAudio = new System.Windows.Forms.TextBox();
            this.btnSelectSourceAudio = new System.Windows.Forms.Button();
            this.dgvAudioList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTotalAudio = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbTotalDurationAudio = new System.Windows.Forms.Label();
            this.btnSplitVideo = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.aaa = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnSelectOutputPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudioList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbtotalDurationVideo
            // 
            this.lbtotalDurationVideo.AutoSize = true;
            this.lbtotalDurationVideo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbtotalDurationVideo.Location = new System.Drawing.Point(190, 242);
            this.lbtotalDurationVideo.Name = "lbtotalDurationVideo";
            this.lbtotalDurationVideo.Size = new System.Drawing.Size(55, 15);
            this.lbtotalDurationVideo.TabIndex = 34;
            this.lbtotalDurationVideo.Text = "00:00:00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(123, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "Thời lượng";
            // 
            // lbTotalVideoSource
            // 
            this.lbTotalVideoSource.AutoSize = true;
            this.lbTotalVideoSource.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTotalVideoSource.Location = new System.Drawing.Point(86, 241);
            this.lbTotalVideoSource.Name = "lbTotalVideoSource";
            this.lbTotalVideoSource.Size = new System.Drawing.Size(14, 15);
            this.lbTotalVideoSource.TabIndex = 32;
            this.lbTotalVideoSource.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Số lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Nguồn Video";
            // 
            // txtSourceVideoMerge
            // 
            this.txtSourceVideoMerge.Location = new System.Drawing.Point(106, 19);
            this.txtSourceVideoMerge.Name = "txtSourceVideoMerge";
            this.txtSourceVideoMerge.Size = new System.Drawing.Size(315, 23);
            this.txtSourceVideoMerge.TabIndex = 29;
            // 
            // btnSelectVideoMerge
            // 
            this.btnSelectVideoMerge.Location = new System.Drawing.Point(427, 19);
            this.btnSelectVideoMerge.Name = "btnSelectVideoMerge";
            this.btnSelectVideoMerge.Size = new System.Drawing.Size(102, 23);
            this.btnSelectVideoMerge.TabIndex = 28;
            this.btnSelectVideoMerge.Text = "Chọn";
            this.btnSelectVideoMerge.UseVisualStyleBackColor = true;
            this.btnSelectVideoMerge.Click += new System.EventHandler(this.btnSelectVideoMerge_Click);
            // 
            // btnMergeVideo
            // 
            this.btnMergeVideo.Location = new System.Drawing.Point(449, 312);
            this.btnMergeVideo.Name = "btnMergeVideo";
            this.btnMergeVideo.Size = new System.Drawing.Size(170, 23);
            this.btnMergeVideo.TabIndex = 27;
            this.btnMergeVideo.Text = "Ghép";
            this.btnMergeVideo.UseVisualStyleBackColor = true;
            this.btnMergeVideo.Click += new System.EventHandler(this.btnMergeVideo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Thời Lượng :";
            // 
            // txtDurationVideo
            // 
            this.txtDurationVideo.Location = new System.Drawing.Point(322, 313);
            this.txtDurationVideo.Name = "txtDurationVideo";
            this.txtDurationVideo.Size = new System.Drawing.Size(102, 23);
            this.txtDurationVideo.TabIndex = 25;
            // 
            // txtNumOfVideo
            // 
            this.txtNumOfVideo.Location = new System.Drawing.Point(120, 313);
            this.txtNumOfVideo.Name = "txtNumOfVideo";
            this.txtNumOfVideo.Size = new System.Drawing.Size(104, 23);
            this.txtNumOfVideo.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Số Lượng Video: ";
            // 
            // dgvListOutput
            // 
            this.dgvListOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListOutput.Location = new System.Drawing.Point(23, 53);
            this.dgvListOutput.Name = "dgvListOutput";
            this.dgvListOutput.RowTemplate.Height = 25;
            this.dgvListOutput.Size = new System.Drawing.Size(506, 179);
            this.dgvListOutput.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Nguồn âm thanh";
            // 
            // txtSourceAudio
            // 
            this.txtSourceAudio.Location = new System.Drawing.Point(669, 24);
            this.txtSourceAudio.Name = "txtSourceAudio";
            this.txtSourceAudio.Size = new System.Drawing.Size(319, 23);
            this.txtSourceAudio.TabIndex = 36;
            // 
            // btnSelectSourceAudio
            // 
            this.btnSelectSourceAudio.Location = new System.Drawing.Point(994, 24);
            this.btnSelectSourceAudio.Name = "btnSelectSourceAudio";
            this.btnSelectSourceAudio.Size = new System.Drawing.Size(98, 23);
            this.btnSelectSourceAudio.TabIndex = 37;
            this.btnSelectSourceAudio.Text = "Chọn";
            this.btnSelectSourceAudio.UseVisualStyleBackColor = true;
            this.btnSelectSourceAudio.Click += new System.EventHandler(this.btnSelectSourceAudio_Click);
            // 
            // dgvAudioList
            // 
            this.dgvAudioList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAudioList.Location = new System.Drawing.Point(565, 53);
            this.dgvAudioList.Name = "dgvAudioList";
            this.dgvAudioList.RowTemplate.Height = 25;
            this.dgvAudioList.Size = new System.Drawing.Size(527, 179);
            this.dgvAudioList.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "Số lượng";
            // 
            // lbTotalAudio
            // 
            this.lbTotalAudio.AutoSize = true;
            this.lbTotalAudio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTotalAudio.Location = new System.Drawing.Point(622, 242);
            this.lbTotalAudio.Name = "lbTotalAudio";
            this.lbTotalAudio.Size = new System.Drawing.Size(14, 15);
            this.lbTotalAudio.TabIndex = 40;
            this.lbTotalAudio.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(669, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 41;
            this.label11.Text = "Thời Lượng";
            // 
            // lbTotalDurationAudio
            // 
            this.lbTotalDurationAudio.AutoSize = true;
            this.lbTotalDurationAudio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTotalDurationAudio.Location = new System.Drawing.Point(742, 242);
            this.lbTotalDurationAudio.Name = "lbTotalDurationAudio";
            this.lbTotalDurationAudio.Size = new System.Drawing.Size(55, 15);
            this.lbTotalDurationAudio.TabIndex = 42;
            this.lbTotalDurationAudio.Text = "00:00:00";
            // 
            // btnSplitVideo
            // 
            this.btnSplitVideo.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSplitVideo.Location = new System.Drawing.Point(651, 312);
            this.btnSplitVideo.Name = "btnSplitVideo";
            this.btnSplitVideo.Size = new System.Drawing.Size(170, 24);
            this.btnSplitVideo.TabIndex = 43;
            this.btnSplitVideo.Text = "Tách Video";
            this.btnSplitVideo.UseVisualStyleBackColor = false;
            this.btnSplitVideo.Click += new System.EventHandler(this.btnSplitVideo_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtbOutput.Location = new System.Drawing.Point(847, 239);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(245, 96);
            this.rtbOutput.TabIndex = 44;
            this.rtbOutput.Text = "";
            // 
            // aaa
            // 
            this.aaa.AutoSize = true;
            this.aaa.Location = new System.Drawing.Point(58, 284);
            this.aaa.Name = "aaa";
            this.aaa.Size = new System.Drawing.Size(56, 15);
            this.aaa.TabIndex = 45;
            this.aaa.Text = "Xuất file: ";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(120, 281);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(304, 23);
            this.txtOutputPath.TabIndex = 46;
            // 
            // btnSelectOutputPath
            // 
            this.btnSelectOutputPath.Location = new System.Drawing.Point(454, 280);
            this.btnSelectOutputPath.Name = "btnSelectOutputPath";
            this.btnSelectOutputPath.Size = new System.Drawing.Size(165, 23);
            this.btnSelectOutputPath.TabIndex = 47;
            this.btnSelectOutputPath.Text = "Chọn";
            this.btnSelectOutputPath.UseVisualStyleBackColor = true;
            this.btnSelectOutputPath.Click += new System.EventHandler(this.btnSelectOutputPath_Click);
            // 
            // MergeVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 358);
            this.Controls.Add(this.btnSelectOutputPath);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.aaa);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.btnSplitVideo);
            this.Controls.Add(this.lbTotalDurationAudio);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbTotalAudio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAudioList);
            this.Controls.Add(this.btnSelectSourceAudio);
            this.Controls.Add(this.txtSourceAudio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbtotalDurationVideo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbTotalVideoSource);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSourceVideoMerge);
            this.Controls.Add(this.btnSelectVideoMerge);
            this.Controls.Add(this.btnMergeVideo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDurationVideo);
            this.Controls.Add(this.txtNumOfVideo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvListOutput);
            this.Name = "MergeVideo";
            this.Text = "MergeVideo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudioList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbtotalDurationVideo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTotalVideoSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSourceVideoMerge;
        private System.Windows.Forms.Button btnSelectVideoMerge;
        private System.Windows.Forms.Button btnMergeVideo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDurationVideo;
        private System.Windows.Forms.TextBox txtNumOfVideo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvListOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceAudio;
        private System.Windows.Forms.Button btnSelectSourceAudio;
        private System.Windows.Forms.DataGridView dgvAudioList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTotalAudio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSplitVideo;
        private System.Windows.Forms.Label lbTotalDurationAudio;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Label aaa;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnSelectOutputPath;
    }
}