namespace Moli_app
{
    partial class AddLogo
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
            this.components = new System.ComponentModel.Container();
            this.pbDemoAddLogo = new System.Windows.Forms.PictureBox();
            this.bannerTextProvider1 = new Syncfusion.Windows.Forms.BannerTextProvider(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.txtLogoPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddLogo2 = new System.Windows.Forms.Button();
            this.gbPos = new System.Windows.Forms.GroupBox();
            this.rbPosRB = new System.Windows.Forms.RadioButton();
            this.rbPosLB = new System.Windows.Forms.RadioButton();
            this.rbPosRT = new System.Windows.Forms.RadioButton();
            this.rbPosLT = new System.Windows.Forms.RadioButton();
            this.lb22 = new System.Windows.Forms.Label();
            this.tbarScale = new System.Windows.Forms.TrackBar();
            this.pbLogoPreview = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSelectLogo = new System.Windows.Forms.Button();
            this.NumScale = new System.Windows.Forms.NumericUpDown();
            this.pbLogoOvelay = new System.Windows.Forms.PictureBox();
            this.tbarY = new System.Windows.Forms.TrackBar();
            this.tbarX = new System.Windows.Forms.TrackBar();
            this.lbx = new System.Windows.Forms.Label();
            this.lby = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDemoAddLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.gbPos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoOvelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarX)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDemoAddLogo
            // 
            this.pbDemoAddLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbDemoAddLogo.Location = new System.Drawing.Point(12, 12);
            this.pbDemoAddLogo.Name = "pbDemoAddLogo";
            this.pbDemoAddLogo.Size = new System.Drawing.Size(512, 360);
            this.pbDemoAddLogo.TabIndex = 0;
            this.pbDemoAddLogo.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 378);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(776, 45);
            this.trackBar1.TabIndex = 3;
            // 
            // txtLogoPath
            // 
            this.txtLogoPath.Location = new System.Drawing.Point(530, 36);
            this.txtLogoPath.Name = "txtLogoPath";
            this.txtLogoPath.Size = new System.Drawing.Size(206, 23);
            this.txtLogoPath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chọn logo";
            // 
            // btnAddLogo2
            // 
            this.btnAddLogo2.Location = new System.Drawing.Point(742, 36);
            this.btnAddLogo2.Name = "btnAddLogo2";
            this.btnAddLogo2.Size = new System.Drawing.Size(46, 23);
            this.btnAddLogo2.TabIndex = 12;
            this.btnAddLogo2.Text = "+";
            this.btnAddLogo2.UseVisualStyleBackColor = true;
            this.btnAddLogo2.Click += new System.EventHandler(this.btnAddLogo2_Click);
            // 
            // gbPos
            // 
            this.gbPos.Controls.Add(this.rbPosRB);
            this.gbPos.Controls.Add(this.rbPosLB);
            this.gbPos.Controls.Add(this.rbPosRT);
            this.gbPos.Controls.Add(this.rbPosLT);
            this.gbPos.Location = new System.Drawing.Point(536, 272);
            this.gbPos.Name = "gbPos";
            this.gbPos.Size = new System.Drawing.Size(252, 100);
            this.gbPos.TabIndex = 13;
            this.gbPos.TabStop = false;
            this.gbPos.Text = "Vị Trí";
            // 
            // rbPosRB
            // 
            this.rbPosRB.AutoSize = true;
            this.rbPosRB.Location = new System.Drawing.Point(133, 65);
            this.rbPosRB.Name = "rbPosRB";
            this.rbPosRB.Size = new System.Drawing.Size(107, 19);
            this.rbPosRB.TabIndex = 4;
            this.rbPosRB.Text = "Bên Phải - Dưới";
            this.rbPosRB.UseVisualStyleBackColor = true;
            this.rbPosRB.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbPosLB
            // 
            this.rbPosLB.AutoSize = true;
            this.rbPosLB.Location = new System.Drawing.Point(18, 65);
            this.rbPosLB.Name = "rbPosLB";
            this.rbPosLB.Size = new System.Drawing.Size(102, 19);
            this.rbPosLB.TabIndex = 2;
            this.rbPosLB.Text = "Bên Trái - Dưới";
            this.rbPosLB.UseVisualStyleBackColor = true;
            this.rbPosLB.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbPosRT
            // 
            this.rbPosRT.AutoSize = true;
            this.rbPosRT.Location = new System.Drawing.Point(133, 31);
            this.rbPosRT.Name = "rbPosRT";
            this.rbPosRT.Size = new System.Drawing.Size(104, 19);
            this.rbPosRT.TabIndex = 3;
            this.rbPosRT.Text = "Bên Phải - Trên";
            this.rbPosRT.UseVisualStyleBackColor = true;
            this.rbPosRT.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbPosLT
            // 
            this.rbPosLT.AutoSize = true;
            this.rbPosLT.Checked = true;
            this.rbPosLT.Location = new System.Drawing.Point(18, 31);
            this.rbPosLT.Name = "rbPosLT";
            this.rbPosLT.Size = new System.Drawing.Size(99, 19);
            this.rbPosLT.TabIndex = 1;
            this.rbPosLT.TabStop = true;
            this.rbPosLT.Text = "Bên Trái - Trên";
            this.rbPosLT.UseVisualStyleBackColor = true;
            this.rbPosLT.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lb22
            // 
            this.lb22.AutoSize = true;
            this.lb22.Location = new System.Drawing.Point(530, 71);
            this.lb22.Name = "lb22";
            this.lb22.Size = new System.Drawing.Size(64, 15);
            this.lb22.TabIndex = 14;
            this.lb22.Text = "Kích thước";
            // 
            // tbarScale
            // 
            this.tbarScale.Location = new System.Drawing.Point(530, 89);
            this.tbarScale.Maximum = 100;
            this.tbarScale.Minimum = 10;
            this.tbarScale.Name = "tbarScale";
            this.tbarScale.Size = new System.Drawing.Size(258, 45);
            this.tbarScale.TabIndex = 15;
            this.tbarScale.Value = 50;
            this.tbarScale.Scroll += new System.EventHandler(this.tbarScale_Scroll);
            // 
            // pbLogoPreview
            // 
            this.pbLogoPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLogoPreview.Location = new System.Drawing.Point(608, 191);
            this.pbLogoPreview.Name = "pbLogoPreview";
            this.pbLogoPreview.Size = new System.Drawing.Size(103, 75);
            this.pbLogoPreview.TabIndex = 16;
            this.pbLogoPreview.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(701, 415);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Quay Về";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSelectLogo
            // 
            this.btnSelectLogo.Location = new System.Drawing.Point(620, 415);
            this.btnSelectLogo.Name = "btnSelectLogo";
            this.btnSelectLogo.Size = new System.Drawing.Size(75, 23);
            this.btnSelectLogo.TabIndex = 18;
            this.btnSelectLogo.Text = "Lưu Logo";
            this.btnSelectLogo.UseVisualStyleBackColor = true;
            this.btnSelectLogo.Click += new System.EventHandler(this.btnSelectLogo_Click);
            // 
            // NumScale
            // 
            this.NumScale.Location = new System.Drawing.Point(711, 71);
            this.NumScale.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumScale.Name = "NumScale";
            this.NumScale.Size = new System.Drawing.Size(77, 23);
            this.NumScale.TabIndex = 20;
            this.NumScale.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NumScale.ValueChanged += new System.EventHandler(this.NumScale_KeyPress);
            // 
            // pbLogoOvelay
            // 
            this.pbLogoOvelay.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoOvelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLogoOvelay.Location = new System.Drawing.Point(441, 36);
            this.pbLogoOvelay.MinimumSize = new System.Drawing.Size(30, 30);
            this.pbLogoOvelay.Name = "pbLogoOvelay";
            this.pbLogoOvelay.Size = new System.Drawing.Size(50, 50);
            this.pbLogoOvelay.TabIndex = 21;
            this.pbLogoOvelay.TabStop = false;
            // 
            // tbarY
            // 
            this.tbarY.Location = new System.Drawing.Point(659, 140);
            this.tbarY.Maximum = 500;
            this.tbarY.Minimum = 12;
            this.tbarY.Name = "tbarY";
            this.tbarY.Size = new System.Drawing.Size(117, 45);
            this.tbarY.SmallChange = 10;
            this.tbarY.TabIndex = 22;
            this.tbarY.Value = 27;
            this.tbarY.ValueChanged += new System.EventHandler(this.tbarY_ValueChanged);
            // 
            // tbarX
            // 
            this.tbarX.Location = new System.Drawing.Point(536, 140);
            this.tbarX.Maximum = 500;
            this.tbarX.Minimum = 12;
            this.tbarX.Name = "tbarX";
            this.tbarX.Size = new System.Drawing.Size(120, 45);
            this.tbarX.SmallChange = 10;
            this.tbarX.TabIndex = 23;
            this.tbarX.Value = 23;
            this.tbarX.ValueChanged += new System.EventHandler(this.tbarX_ValueChanged);
            // 
            // lbx
            // 
            this.lbx.AutoSize = true;
            this.lbx.Location = new System.Drawing.Point(536, 119);
            this.lbx.Name = "lbx";
            this.lbx.Size = new System.Drawing.Size(41, 15);
            this.lbx.TabIndex = 24;
            this.lbx.Text = "Vị trí X";
            // 
            // lby
            // 
            this.lby.AutoSize = true;
            this.lby.Location = new System.Drawing.Point(669, 119);
            this.lby.Name = "lby";
            this.lby.Size = new System.Drawing.Size(42, 15);
            this.lby.TabIndex = 25;
            this.lby.Text = "Vị Trí Y";
            // 
            // AddLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lby);
            this.Controls.Add(this.lbx);
            this.Controls.Add(this.tbarX);
            this.Controls.Add(this.pbLogoOvelay);
            this.Controls.Add(this.NumScale);
            this.Controls.Add(this.btnSelectLogo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pbLogoPreview);
            this.Controls.Add(this.tbarScale);
            this.Controls.Add(this.lb22);
            this.Controls.Add(this.gbPos);
            this.Controls.Add(this.btnAddLogo2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogoPath);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pbDemoAddLogo);
            this.Controls.Add(this.tbarY);
            this.Name = "AddLogo";
            this.Text = "AddLogo";
            ((System.ComponentModel.ISupportInitialize)(this.pbDemoAddLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.gbPos.ResumeLayout(false);
            this.gbPos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoOvelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDemoAddLogo;
        private Syncfusion.Windows.Forms.BannerTextProvider bannerTextProvider1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox txtLogoPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddLogo2;
        private System.Windows.Forms.GroupBox gbPos;
        private System.Windows.Forms.RadioButton rbPosLB;
        private System.Windows.Forms.RadioButton rbPosRT;
        private System.Windows.Forms.RadioButton rbPosLT;
        private System.Windows.Forms.RadioButton rbPosRB;
        private System.Windows.Forms.Label lb22;
        private System.Windows.Forms.TrackBar tbarScale;
        private System.Windows.Forms.PictureBox pbLogoPreview;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSelectLogo;
        private System.Windows.Forms.NumericUpDown NumScale;
        private System.Windows.Forms.PictureBox pbLogoOvelay;
        private System.Windows.Forms.TrackBar tbarY;
        private System.Windows.Forms.TrackBar tbarX;
        private System.Windows.Forms.Label lbx;
        private System.Windows.Forms.Label lby;
    }
}