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
            this.SuspendLayout();
            // 
            // txtSourceVideoPath
            // 
            this.txtSourceVideoPath.Location = new System.Drawing.Point(118, 47);
            this.txtSourceVideoPath.Name = "txtSourceVideoPath";
            this.txtSourceVideoPath.Size = new System.Drawing.Size(330, 23);
            this.txtSourceVideoPath.TabIndex = 0;
            // 
            // btnSelectFileSource
            // 
            this.btnSelectFileSource.Location = new System.Drawing.Point(454, 47);
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
            this.label1.Location = new System.Drawing.Point(30, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output File";
            // 
            // txtDestPath
            // 
            this.txtDestPath.Location = new System.Drawing.Point(118, 86);
            this.txtDestPath.Name = "txtDestPath";
            this.txtDestPath.Size = new System.Drawing.Size(330, 23);
            this.txtDestPath.TabIndex = 4;
            // 
            // btnSelectDestPath
            // 
            this.btnSelectDestPath.Location = new System.Drawing.Point(454, 86);
            this.btnSelectDestPath.Name = "btnSelectDestPath";
            this.btnSelectDestPath.Size = new System.Drawing.Size(102, 23);
            this.btnSelectDestPath.TabIndex = 5;
            this.btnSelectDestPath.Text = "Select";
            this.btnSelectDestPath.UseVisualStyleBackColor = true;
            this.btnSelectDestPath.Click += new System.EventHandler(this.btnSelectDestPath_Click);
            // 
            // btnSplitScense
            // 
            this.btnSplitScense.Location = new System.Drawing.Point(30, 158);
            this.btnSplitScense.Name = "btnSplitScense";
            this.btnSplitScense.Size = new System.Drawing.Size(114, 23);
            this.btnSplitScense.TabIndex = 6;
            this.btnSplitScense.Text = "Split Scense";
            this.btnSplitScense.UseVisualStyleBackColor = true;
            this.btnSplitScense.Click += new System.EventHandler(this.btnSplitScense_ClickAsync);
            // 
            // rtbResultProcess
            // 
            this.rtbResultProcess.BackColor = System.Drawing.SystemColors.Menu;
            this.rtbResultProcess.Location = new System.Drawing.Point(30, 187);
            this.rtbResultProcess.Name = "rtbResultProcess";
            this.rtbResultProcess.Size = new System.Drawing.Size(317, 208);
            this.rtbResultProcess.TabIndex = 7;
            this.rtbResultProcess.Text = "";
            // 
            // rtxError
            // 
            this.rtxError.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtxError.Location = new System.Drawing.Point(369, 187);
            this.rtxError.Name = "rtxError";
            this.rtxError.Size = new System.Drawing.Size(291, 208);
            this.rtxError.TabIndex = 8;
            this.rtxError.Text = "";
            // 
            // tiktok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}