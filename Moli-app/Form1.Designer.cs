namespace Moli_app
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMergeVideo = new System.Windows.Forms.TabPage();
            this.btnProcess3 = new System.Windows.Forms.Button();
            this.btnProcess2 = new System.Windows.Forms.Button();
            this.btnProcess1 = new System.Windows.Forms.Button();
            this.cboxYoutubeStarndard = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBitrateMergeVideo = new System.Windows.Forms.TextBox();
            this.txtNumMergeCompleted = new System.Windows.Forms.TextBox();
            this.txtTotalVideoEachVideo_2 = new System.Windows.Forms.TextBox();
            this.txtTotalVideoEachVideo_1 = new System.Windows.Forms.TextBox();
            this.txtTotalMerge = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLogoPath = new System.Windows.Forms.TextBox();
            this.btnAddLogo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSelectVideoLast = new System.Windows.Forms.ComboBox();
            this.cbSelectVideoFirst = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVideoOutput = new System.Windows.Forms.Button();
            this.txtVideoOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddLastVideo = new System.Windows.Forms.Button();
            this.txtAddLastVideo = new System.Windows.Forms.TextBox();
            this.btnAddFirstVideo = new System.Windows.Forms.Button();
            this.txtAddFirstVideo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddFolderVideo = new System.Windows.Forms.Button();
            this.txtFolderVideo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabRandomVideoTime = new System.Windows.Forms.TabPage();
            this.tabDownBitrateVideo = new System.Windows.Forms.TabPage();
            this.tabAddProxy = new System.Windows.Forms.TabPage();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbox1 = new System.Windows.Forms.GroupBox();
            this.btnDownloadVideoYoutube = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VideoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtGoogleAPI = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.rtbResultProcess = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.rtbCommandProcess = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabMergeVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMergeVideo);
            this.tabControl1.Controls.Add(this.tabRandomVideoTime);
            this.tabControl1.Controls.Add(this.tabDownBitrateVideo);
            this.tabControl1.Controls.Add(this.tabAddProxy);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 600);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMergeVideo
            // 
            this.tabMergeVideo.Controls.Add(this.btnProcess3);
            this.tabMergeVideo.Controls.Add(this.btnProcess2);
            this.tabMergeVideo.Controls.Add(this.btnProcess1);
            this.tabMergeVideo.Controls.Add(this.cboxYoutubeStarndard);
            this.tabMergeVideo.Controls.Add(this.dataGridView1);
            this.tabMergeVideo.Controls.Add(this.label12);
            this.tabMergeVideo.Controls.Add(this.txtBitrateMergeVideo);
            this.tabMergeVideo.Controls.Add(this.txtNumMergeCompleted);
            this.tabMergeVideo.Controls.Add(this.txtTotalVideoEachVideo_2);
            this.tabMergeVideo.Controls.Add(this.txtTotalVideoEachVideo_1);
            this.tabMergeVideo.Controls.Add(this.txtTotalMerge);
            this.tabMergeVideo.Controls.Add(this.label11);
            this.tabMergeVideo.Controls.Add(this.label10);
            this.tabMergeVideo.Controls.Add(this.label9);
            this.tabMergeVideo.Controls.Add(this.label8);
            this.tabMergeVideo.Controls.Add(this.txtLogoPath);
            this.tabMergeVideo.Controls.Add(this.btnAddLogo);
            this.tabMergeVideo.Controls.Add(this.label7);
            this.tabMergeVideo.Controls.Add(this.cbSelectVideoLast);
            this.tabMergeVideo.Controls.Add(this.cbSelectVideoFirst);
            this.tabMergeVideo.Controls.Add(this.label6);
            this.tabMergeVideo.Controls.Add(this.label5);
            this.tabMergeVideo.Controls.Add(this.btnVideoOutput);
            this.tabMergeVideo.Controls.Add(this.txtVideoOutput);
            this.tabMergeVideo.Controls.Add(this.label4);
            this.tabMergeVideo.Controls.Add(this.btnAddLastVideo);
            this.tabMergeVideo.Controls.Add(this.txtAddLastVideo);
            this.tabMergeVideo.Controls.Add(this.btnAddFirstVideo);
            this.tabMergeVideo.Controls.Add(this.txtAddFirstVideo);
            this.tabMergeVideo.Controls.Add(this.label3);
            this.tabMergeVideo.Controls.Add(this.label2);
            this.tabMergeVideo.Controls.Add(this.btnAddFolderVideo);
            this.tabMergeVideo.Controls.Add(this.txtFolderVideo);
            this.tabMergeVideo.Controls.Add(this.label1);
            this.tabMergeVideo.Location = new System.Drawing.Point(4, 24);
            this.tabMergeVideo.Name = "tabMergeVideo";
            this.tabMergeVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabMergeVideo.Size = new System.Drawing.Size(597, 572);
            this.tabMergeVideo.TabIndex = 0;
            this.tabMergeVideo.Text = "Nối Video";
            this.tabMergeVideo.UseVisualStyleBackColor = true;
            // 
            // btnProcess3
            // 
            this.btnProcess3.Location = new System.Drawing.Point(484, 532);
            this.btnProcess3.Name = "btnProcess3";
            this.btnProcess3.Size = new System.Drawing.Size(106, 23);
            this.btnProcess3.TabIndex = 33;
            this.btnProcess3.Text = "Thực hiện 3";
            this.btnProcess3.UseVisualStyleBackColor = true;
            // 
            // btnProcess2
            // 
            this.btnProcess2.Location = new System.Drawing.Point(372, 533);
            this.btnProcess2.Name = "btnProcess2";
            this.btnProcess2.Size = new System.Drawing.Size(106, 23);
            this.btnProcess2.TabIndex = 32;
            this.btnProcess2.Text = "Thực hiện 2";
            this.btnProcess2.UseVisualStyleBackColor = true;
            // 
            // btnProcess1
            // 
            this.btnProcess1.Location = new System.Drawing.Point(260, 533);
            this.btnProcess1.Name = "btnProcess1";
            this.btnProcess1.Size = new System.Drawing.Size(106, 23);
            this.btnProcess1.TabIndex = 1;
            this.btnProcess1.Text = "Nối Video";
            this.btnProcess1.UseVisualStyleBackColor = true;
            this.btnProcess1.Click += new System.EventHandler(this.btnProcess1_Click);
            // 
            // cboxYoutubeStarndard
            // 
            this.cboxYoutubeStarndard.AutoSize = true;
            this.cboxYoutubeStarndard.Enabled = false;
            this.cboxYoutubeStarndard.Location = new System.Drawing.Point(11, 536);
            this.cboxYoutubeStarndard.Name = "cboxYoutubeStarndard";
            this.cboxYoutubeStarndard.Size = new System.Drawing.Size(137, 19);
            this.cboxYoutubeStarndard.TabIndex = 31;
            this.cboxYoutubeStarndard.Text = "Xử lý Chuẩn Youtube";
            this.cboxYoutubeStarndard.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 242);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(582, 284);
            this.dataGridView1.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(260, 210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 15);
            this.label12.TabIndex = 29;
            this.label12.Text = "-";
            // 
            // txtBitrateMergeVideo
            // 
            this.txtBitrateMergeVideo.Location = new System.Drawing.Point(474, 207);
            this.txtBitrateMergeVideo.Name = "txtBitrateMergeVideo";
            this.txtBitrateMergeVideo.Size = new System.Drawing.Size(116, 23);
            this.txtBitrateMergeVideo.TabIndex = 28;
            // 
            // txtNumMergeCompleted
            // 
            this.txtNumMergeCompleted.Enabled = false;
            this.txtNumMergeCompleted.Location = new System.Drawing.Point(357, 207);
            this.txtNumMergeCompleted.Name = "txtNumMergeCompleted";
            this.txtNumMergeCompleted.Size = new System.Drawing.Size(111, 23);
            this.txtNumMergeCompleted.TabIndex = 27;
            // 
            // txtTotalVideoEachVideo_2
            // 
            this.txtTotalVideoEachVideo_2.Enabled = false;
            this.txtTotalVideoEachVideo_2.Location = new System.Drawing.Point(278, 207);
            this.txtTotalVideoEachVideo_2.Name = "txtTotalVideoEachVideo_2";
            this.txtTotalVideoEachVideo_2.Size = new System.Drawing.Size(70, 23);
            this.txtTotalVideoEachVideo_2.TabIndex = 26;
            // 
            // txtTotalVideoEachVideo_1
            // 
            this.txtTotalVideoEachVideo_1.Enabled = false;
            this.txtTotalVideoEachVideo_1.Location = new System.Drawing.Point(184, 207);
            this.txtTotalVideoEachVideo_1.Name = "txtTotalVideoEachVideo_1";
            this.txtTotalVideoEachVideo_1.Size = new System.Drawing.Size(70, 23);
            this.txtTotalVideoEachVideo_1.TabIndex = 25;
            // 
            // txtTotalMerge
            // 
            this.txtTotalMerge.Enabled = false;
            this.txtTotalMerge.Location = new System.Drawing.Point(8, 207);
            this.txtTotalMerge.Name = "txtTotalMerge";
            this.txtTotalMerge.Size = new System.Drawing.Size(167, 23);
            this.txtTotalMerge.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(503, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Bitrate (Mbit/s)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(357, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Đã ghép";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(181, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Số video trong mỗi video";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Số Video Ghép";
            // 
            // txtLogoPath
            // 
            this.txtLogoPath.Location = new System.Drawing.Point(357, 164);
            this.txtLogoPath.Name = "txtLogoPath";
            this.txtLogoPath.Size = new System.Drawing.Size(182, 23);
            this.txtLogoPath.TabIndex = 19;
            // 
            // btnAddLogo
            // 
            this.btnAddLogo.Enabled = false;
            this.btnAddLogo.Location = new System.Drawing.Point(544, 163);
            this.btnAddLogo.Name = "btnAddLogo";
            this.btnAddLogo.Size = new System.Drawing.Size(46, 23);
            this.btnAddLogo.TabIndex = 18;
            this.btnAddLogo.Text = "+";
            this.btnAddLogo.UseVisualStyleBackColor = true;
            this.btnAddLogo.Click += new System.EventHandler(this.btnAddLogo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Logo";
            // 
            // cbSelectVideoLast
            // 
            this.cbSelectVideoLast.Enabled = false;
            this.cbSelectVideoLast.FormattingEnabled = true;
            this.cbSelectVideoLast.Location = new System.Drawing.Point(181, 163);
            this.cbSelectVideoLast.Name = "cbSelectVideoLast";
            this.cbSelectVideoLast.Size = new System.Drawing.Size(170, 23);
            this.cbSelectVideoLast.TabIndex = 15;
            // 
            // cbSelectVideoFirst
            // 
            this.cbSelectVideoFirst.Enabled = false;
            this.cbSelectVideoFirst.FormattingEnabled = true;
            this.cbSelectVideoFirst.Location = new System.Drawing.Point(8, 163);
            this.cbSelectVideoFirst.Name = "cbSelectVideoFirst";
            this.cbSelectVideoFirst.Size = new System.Drawing.Size(167, 23);
            this.cbSelectVideoFirst.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Video Cuối";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Video Đầu";
            // 
            // btnVideoOutput
            // 
            this.btnVideoOutput.Location = new System.Drawing.Point(544, 118);
            this.btnVideoOutput.Name = "btnVideoOutput";
            this.btnVideoOutput.Size = new System.Drawing.Size(46, 23);
            this.btnVideoOutput.TabIndex = 11;
            this.btnVideoOutput.Text = "+";
            this.btnVideoOutput.UseVisualStyleBackColor = true;
            this.btnVideoOutput.Click += new System.EventHandler(this.btnVideoOutput_Click);
            // 
            // txtVideoOutput
            // 
            this.txtVideoOutput.Location = new System.Drawing.Point(8, 119);
            this.txtVideoOutput.Name = "txtVideoOutput";
            this.txtVideoOutput.Size = new System.Drawing.Size(531, 23);
            this.txtVideoOutput.TabIndex = 10;
            this.txtVideoOutput.Text = "F:\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Folder Kết quả";
            // 
            // btnAddLastVideo
            // 
            this.btnAddLastVideo.Location = new System.Drawing.Point(544, 76);
            this.btnAddLastVideo.Name = "btnAddLastVideo";
            this.btnAddLastVideo.Size = new System.Drawing.Size(46, 23);
            this.btnAddLastVideo.TabIndex = 8;
            this.btnAddLastVideo.Text = "+";
            this.btnAddLastVideo.UseVisualStyleBackColor = true;
            this.btnAddLastVideo.Click += new System.EventHandler(this.btnAddLastVideo_Click);
            // 
            // txtAddLastVideo
            // 
            this.txtAddLastVideo.Location = new System.Drawing.Point(278, 76);
            this.txtAddLastVideo.Name = "txtAddLastVideo";
            this.txtAddLastVideo.Size = new System.Drawing.Size(260, 23);
            this.txtAddLastVideo.TabIndex = 7;
            this.txtAddLastVideo.Text = "E:\\";
            // 
            // btnAddFirstVideo
            // 
            this.btnAddFirstVideo.Location = new System.Drawing.Point(225, 75);
            this.btnAddFirstVideo.Name = "btnAddFirstVideo";
            this.btnAddFirstVideo.Size = new System.Drawing.Size(47, 23);
            this.btnAddFirstVideo.TabIndex = 6;
            this.btnAddFirstVideo.Text = "+";
            this.btnAddFirstVideo.UseVisualStyleBackColor = true;
            this.btnAddFirstVideo.Click += new System.EventHandler(this.btnAddFirstVideo_Click);
            // 
            // txtAddFirstVideo
            // 
            this.txtAddFirstVideo.Location = new System.Drawing.Point(8, 75);
            this.txtAddFirstVideo.Name = "txtAddFirstVideo";
            this.txtAddFirstVideo.Size = new System.Drawing.Size(211, 23);
            this.txtAddFirstVideo.TabIndex = 5;
            this.txtAddFirstVideo.Text = "E:\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Path Video Cuối";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Path Video Đầu";
            // 
            // btnAddFolderVideo
            // 
            this.btnAddFolderVideo.Location = new System.Drawing.Point(544, 29);
            this.btnAddFolderVideo.Name = "btnAddFolderVideo";
            this.btnAddFolderVideo.Size = new System.Drawing.Size(46, 23);
            this.btnAddFolderVideo.TabIndex = 2;
            this.btnAddFolderVideo.Text = "+";
            this.btnAddFolderVideo.UseVisualStyleBackColor = true;
            this.btnAddFolderVideo.Click += new System.EventHandler(this.btnAddFolderVideo_Click);
            // 
            // txtFolderVideo
            // 
            this.txtFolderVideo.Location = new System.Drawing.Point(8, 29);
            this.txtFolderVideo.Name = "txtFolderVideo";
            this.txtFolderVideo.Size = new System.Drawing.Size(531, 23);
            this.txtFolderVideo.TabIndex = 1;
            this.txtFolderVideo.Text = "C:\\Users\\Admins\\Downloads";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder chứa video";
            // 
            // tabRandomVideoTime
            // 
            this.tabRandomVideoTime.Location = new System.Drawing.Point(4, 24);
            this.tabRandomVideoTime.Name = "tabRandomVideoTime";
            this.tabRandomVideoTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabRandomVideoTime.Size = new System.Drawing.Size(597, 572);
            this.tabRandomVideoTime.TabIndex = 1;
            this.tabRandomVideoTime.Text = "Random Thời gian video";
            this.tabRandomVideoTime.UseVisualStyleBackColor = true;
            // 
            // tabDownBitrateVideo
            // 
            this.tabDownBitrateVideo.Location = new System.Drawing.Point(4, 24);
            this.tabDownBitrateVideo.Name = "tabDownBitrateVideo";
            this.tabDownBitrateVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownBitrateVideo.Size = new System.Drawing.Size(597, 572);
            this.tabDownBitrateVideo.TabIndex = 2;
            this.tabDownBitrateVideo.Text = "Giảm Bitrate Video";
            this.tabDownBitrateVideo.UseVisualStyleBackColor = true;
            // 
            // tabAddProxy
            // 
            this.tabAddProxy.Location = new System.Drawing.Point(4, 24);
            this.tabAddProxy.Name = "tabAddProxy";
            this.tabAddProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddProxy.Size = new System.Drawing.Size(597, 572);
            this.tabAddProxy.TabIndex = 3;
            this.tabAddProxy.Text = "Add Proxy";
            this.tabAddProxy.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // gbox1
            // 
            this.gbox1.Controls.Add(this.btnDownloadVideoYoutube);
            this.gbox1.Controls.Add(this.dataGridView2);
            this.gbox1.Controls.Add(this.txtKeyword);
            this.gbox1.Controls.Add(this.label14);
            this.gbox1.Controls.Add(this.txtGoogleAPI);
            this.gbox1.Controls.Add(this.label13);
            this.gbox1.Location = new System.Drawing.Point(623, 12);
            this.gbox1.Name = "gbox1";
            this.gbox1.Size = new System.Drawing.Size(388, 324);
            this.gbox1.TabIndex = 1;
            this.gbox1.TabStop = false;
            this.gbox1.Text = "Tải Video";
            // 
            // btnDownloadVideoYoutube
            // 
            this.btnDownloadVideoYoutube.Location = new System.Drawing.Point(7, 290);
            this.btnDownloadVideoYoutube.Name = "btnDownloadVideoYoutube";
            this.btnDownloadVideoYoutube.Size = new System.Drawing.Size(106, 23);
            this.btnDownloadVideoYoutube.TabIndex = 34;
            this.btnDownloadVideoYoutube.Text = "Thực hiện tải video";
            this.btnDownloadVideoYoutube.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.VideoID,
            this.status});
            this.dataGridView2.Location = new System.Drawing.Point(7, 134);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(375, 150);
            this.dataGridView2.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "#";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // VideoID
            // 
            this.VideoID.HeaderText = "Video ID";
            this.VideoID.Name = "VideoID";
            // 
            // status
            // 
            this.status.HeaderText = "Trạng Thái";
            this.status.Name = "status";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(6, 100);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(376, 23);
            this.txtKeyword.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 15);
            this.label14.TabIndex = 2;
            this.label14.Text = "Từ Khóa";
            // 
            // txtGoogleAPI
            // 
            this.txtGoogleAPI.Location = new System.Drawing.Point(6, 53);
            this.txtGoogleAPI.Name = "txtGoogleAPI";
            this.txtGoogleAPI.Size = new System.Drawing.Size(376, 23);
            this.txtGoogleAPI.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Google API";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(630, 339);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 15);
            this.label15.TabIndex = 35;
            this.label15.Text = "Kết quả xử lý";
            // 
            // rtbResultProcess
            // 
            this.rtbResultProcess.BackColor = System.Drawing.SystemColors.Control;
            this.rtbResultProcess.Location = new System.Drawing.Point(629, 357);
            this.rtbResultProcess.Name = "rtbResultProcess";
            this.rtbResultProcess.Size = new System.Drawing.Size(376, 92);
            this.rtbResultProcess.TabIndex = 36;
            this.rtbResultProcess.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(629, 452);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 15);
            this.label16.TabIndex = 37;
            this.label16.Text = "Lệnh xử lý";
            // 
            // rtbCommandProcess
            // 
            this.rtbCommandProcess.BackColor = System.Drawing.SystemColors.Control;
            this.rtbCommandProcess.Location = new System.Drawing.Point(629, 470);
            this.rtbCommandProcess.Name = "rtbCommandProcess";
            this.rtbCommandProcess.Size = new System.Drawing.Size(376, 138);
            this.rtbCommandProcess.TabIndex = 38;
            this.rtbCommandProcess.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1023, 624);
            this.Controls.Add(this.rtbCommandProcess);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.rtbResultProcess);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.gbox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabMergeVideo.ResumeLayout(false);
            this.tabMergeVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbox1.ResumeLayout(false);
            this.gbox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMergeVideo;
        private System.Windows.Forms.TabPage tabRandomVideoTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddFolderVideo;
        private System.Windows.Forms.TextBox txtFolderVideo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabDownBitrateVideo;
        private System.Windows.Forms.TabPage tabAddProxy;
        private System.Windows.Forms.Button btnAddFirstVideo;
        private System.Windows.Forms.TextBox txtAddFirstVideo;
        private System.Windows.Forms.Button btnAddLastVideo;
        private System.Windows.Forms.TextBox txtAddLastVideo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLogoPath;
        private System.Windows.Forms.Button btnAddLogo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSelectVideoLast;
        private System.Windows.Forms.ComboBox cbSelectVideoFirst;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVideoOutput;
        private System.Windows.Forms.TextBox txtVideoOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBitrateMergeVideo;
        private System.Windows.Forms.TextBox txtNumMergeCompleted;
        private System.Windows.Forms.TextBox txtTotalVideoEachVideo_2;
        private System.Windows.Forms.TextBox txtTotalVideoEachVideo_1;
        private System.Windows.Forms.TextBox txtTotalMerge;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnProcess3;
        private System.Windows.Forms.Button btnProcess2;
        private System.Windows.Forms.Button btnProcess1;
        private System.Windows.Forms.CheckBox cboxYoutubeStarndard;
        private System.Windows.Forms.GroupBox gbox1;
        private System.Windows.Forms.Button btnDownloadVideoYoutube;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtGoogleAPI;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox rtbResultProcess;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox rtbCommandProcess;
        private System.Windows.Forms.Timer timer1;
    }
}
