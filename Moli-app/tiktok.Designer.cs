namespace Moli_app
{
    partial class tiktok
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
            this.txtSourceVideoPath = new System.Windows.Forms.TextBox();
            this.btnSelectFileSource = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestPath = new System.Windows.Forms.TextBox();
            this.btnSelectDestPath = new System.Windows.Forms.Button();
            this.btnSplitScense = new System.Windows.Forms.Button();
            this.rtbResultProcess = new System.Windows.Forms.RichTextBox();
            this.rtxError = new System.Windows.Forms.RichTextBox();
            this.btnMergeForm = new System.Windows.Forms.Button();
            this.btnSearchYoutubeShort = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSourceVideoPath
            // 
            this.txtSourceVideoPath.Location = new System.Drawing.Point(98, 20);
            this.txtSourceVideoPath.Name = "txtSourceVideoPath";
            this.txtSourceVideoPath.Size = new System.Drawing.Size(330, 23);
            this.txtSourceVideoPath.TabIndex = 0;
            // 
            // btnSelectFileSource
            // 
            this.btnSelectFileSource.Location = new System.Drawing.Point(434, 20);
            this.btnSelectFileSource.Name = "btnSelectFileSource";
            this.btnSelectFileSource.Size = new System.Drawing.Size(102, 23);
            this.btnSelectFileSource.TabIndex = 1;
            this.btnSelectFileSource.Text = "Select";
            this.btnSelectFileSource.UseVisualStyleBackColor = true;
            this.btnSelectFileSource.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output File";
            // 
            // txtDestPath
            // 
            this.txtDestPath.Location = new System.Drawing.Point(98, 59);
            this.txtDestPath.Name = "txtDestPath";
            this.txtDestPath.Size = new System.Drawing.Size(330, 23);
            this.txtDestPath.TabIndex = 4;
            // 
            // btnSelectDestPath
            // 
            this.btnSelectDestPath.Location = new System.Drawing.Point(434, 59);
            this.btnSelectDestPath.Name = "btnSelectDestPath";
            this.btnSelectDestPath.Size = new System.Drawing.Size(102, 23);
            this.btnSelectDestPath.TabIndex = 5;
            this.btnSelectDestPath.Text = "Select";
            this.btnSelectDestPath.UseVisualStyleBackColor = true;
            this.btnSelectDestPath.Click += new System.EventHandler(this.btnSelectDestPath_Click);
            // 
            // btnSplitScense
            // 
            this.btnSplitScense.Location = new System.Drawing.Point(30, 232);
            this.btnSplitScense.Name = "btnSplitScense";
            this.btnSplitScense.Size = new System.Drawing.Size(506, 35);
            this.btnSplitScense.TabIndex = 6;
            this.btnSplitScense.Text = "Tách Video";
            this.btnSplitScense.UseVisualStyleBackColor = true;
            this.btnSplitScense.Click += new System.EventHandler(this.btnSplitScense_ClickAsync);
            // 
            // rtbResultProcess
            // 
            this.rtbResultProcess.BackColor = System.Drawing.SystemColors.Menu;
            this.rtbResultProcess.Location = new System.Drawing.Point(30, 99);
            this.rtbResultProcess.Name = "rtbResultProcess";
            this.rtbResultProcess.Size = new System.Drawing.Size(239, 127);
            this.rtbResultProcess.TabIndex = 7;
            this.rtbResultProcess.Text = "";
            // 
            // rtxError
            // 
            this.rtxError.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtxError.Location = new System.Drawing.Point(275, 99);
            this.rtxError.Name = "rtxError";
            this.rtxError.Size = new System.Drawing.Size(261, 127);
            this.rtxError.TabIndex = 8;
            this.rtxError.Text = "";
            // 
            // btnMergeForm
            // 
            this.btnMergeForm.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnMergeForm.Location = new System.Drawing.Point(30, 273);
            this.btnMergeForm.Name = "btnMergeForm";
            this.btnMergeForm.Size = new System.Drawing.Size(506, 35);
            this.btnMergeForm.TabIndex = 9;
            this.btnMergeForm.Text = "Ghép Video";
            this.btnMergeForm.UseVisualStyleBackColor = false;
            this.btnMergeForm.Click += new System.EventHandler(this.btnMergeForm_Click);
            // 
            // btnSearchYoutubeShort
            // 
            this.btnSearchYoutubeShort.Location = new System.Drawing.Point(30, 314);
            this.btnSearchYoutubeShort.Name = "btnSearchYoutubeShort";
            this.btnSearchYoutubeShort.Size = new System.Drawing.Size(506, 43);
            this.btnSearchYoutubeShort.TabIndex = 10;
            this.btnSearchYoutubeShort.Text = "Tìm Video Short";
            this.btnSearchYoutubeShort.UseVisualStyleBackColor = true;
            this.btnSearchYoutubeShort.Click += new System.EventHandler(this.btnSearchYoutubeShort_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tiktok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 409);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSearchYoutubeShort);
            this.Controls.Add(this.btnMergeForm);
            this.Controls.Add(this.rtxError);
            this.Controls.Add(this.rtbResultProcess);
            this.Controls.Add(this.btnSplitScense);
            this.Controls.Add(this.btnSelectDestPath);
            this.Controls.Add(this.txtDestPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectFileSource);
            this.Controls.Add(this.txtSourceVideoPath);
            this.Name = "tiktok";
            this.Text = "tiktok";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceVideoPath;
        private System.Windows.Forms.Button btnSelectFileSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestPath;
        private System.Windows.Forms.Button btnSelectDestPath;
        private System.Windows.Forms.Button btnSplitScense;
        private System.Windows.Forms.RichTextBox rtbResultProcess;
        private System.Windows.Forms.RichTextBox rtxError;
        private System.Windows.Forms.Button btnMergeForm;
        private System.Windows.Forms.Button btnSearchYoutubeShort;
        private System.Windows.Forms.Button button1;
    }
}