namespace Moli_app
{
    partial class canvaform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(canvaform));
            this.btnSearchYoutube = new System.Windows.Forms.Button();
            this.btnSplitVideo = new System.Windows.Forms.Button();
            this.btnMergeVideo = new System.Windows.Forms.Button();
            this.btnActive = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearchYoutube
            // 
            this.btnSearchYoutube.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSearchYoutube.Location = new System.Drawing.Point(145, 37);
            this.btnSearchYoutube.Name = "btnSearchYoutube";
            this.btnSearchYoutube.Size = new System.Drawing.Size(299, 75);
            this.btnSearchYoutube.TabIndex = 0;
            this.btnSearchYoutube.Text = "Tìm Video Youtube";
            this.btnSearchYoutube.UseVisualStyleBackColor = false;
            this.btnSearchYoutube.Click += new System.EventHandler(this.btnSearchYoutube_Click);
            // 
            // btnSplitVideo
            // 
            this.btnSplitVideo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSplitVideo.Location = new System.Drawing.Point(145, 137);
            this.btnSplitVideo.Name = "btnSplitVideo";
            this.btnSplitVideo.Size = new System.Drawing.Size(299, 75);
            this.btnSplitVideo.TabIndex = 1;
            this.btnSplitVideo.Text = "Tách Video theo Scense";
            this.btnSplitVideo.UseVisualStyleBackColor = false;
            this.btnSplitVideo.Click += new System.EventHandler(this.btnSplitVideo_Click);
            // 
            // btnMergeVideo
            // 
            this.btnMergeVideo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnMergeVideo.Location = new System.Drawing.Point(145, 233);
            this.btnMergeVideo.Name = "btnMergeVideo";
            this.btnMergeVideo.Size = new System.Drawing.Size(299, 75);
            this.btnMergeVideo.TabIndex = 2;
            this.btnMergeVideo.Text = "Ghép Video";
            this.btnMergeVideo.UseVisualStyleBackColor = false;
            this.btnMergeVideo.Click += new System.EventHandler(this.btnMergeVideo_Click);
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(145, 334);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(299, 60);
            this.btnActive.TabIndex = 3;
            this.btnActive.Text = "Nhập Mã Code Active";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(461, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // canvaform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.btnMergeVideo);
            this.Controls.Add(this.btnSplitVideo);
            this.Controls.Add(this.btnSearchYoutube);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "canvaform";
            this.Text = "Amazing Editor Video";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearchYoutube;
        private System.Windows.Forms.Button btnSplitVideo;
        private System.Windows.Forms.Button btnMergeVideo;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button button1;
    }
}