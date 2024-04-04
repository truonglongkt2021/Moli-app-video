namespace Moli_app
{
    partial class AdminForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtKeySearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhutSuDung = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductKey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSearchEmail = new System.Windows.Forms.Button();
            this.btnSeachProductKey = new System.Windows.Forms.Button();
            this.txtSearchEmail = new System.Windows.Forms.TextBox();
            this.txtSearchProductKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddPhut = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.Label();
            this.txtTransIdAdd = new System.Windows.Forms.TextBox();
            this.txtPriceAdd = new System.Windows.Forms.TextBox();
            this.txtEmailAdd = new System.Windows.Forms.TextBox();
            this.txtKeyAdd = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCheckIncome = new System.Windows.Forms.Button();
            this.txtpinCodeCHeck = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lbTotalIncome = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbHoTenIncome = new System.Windows.Forms.Label();
            this.lbSoDienThoaiIncome = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(566, 336);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtKeySearch);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnSearchEmail);
            this.tabPage1.Controls.Add(this.btnSeachProductKey);
            this.tabPage1.Controls.Add(this.txtSearchEmail);
            this.tabPage1.Controls.Add(this.txtSearchProductKey);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(558, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Check User";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtKeySearch
            // 
            this.txtKeySearch.Location = new System.Drawing.Point(89, 10);
            this.txtKeySearch.Name = "txtKeySearch";
            this.txtKeySearch.PasswordChar = '*';
            this.txtKeySearch.Size = new System.Drawing.Size(360, 23);
            this.txtKeySearch.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "Key";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtPhutSuDung);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPhut);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtProductKey);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(16, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 173);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả tìm kiếm";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(139, 57);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(314, 23);
            this.txtEmail.TabIndex = 14;
            // 
            // txtPhutSuDung
            // 
            this.txtPhutSuDung.Location = new System.Drawing.Point(139, 114);
            this.txtPhutSuDung.Name = "txtPhutSuDung";
            this.txtPhutSuDung.Size = new System.Drawing.Size(100, 23);
            this.txtPhutSuDung.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product Key";
            // 
            // txtPhut
            // 
            this.txtPhut.Location = new System.Drawing.Point(139, 85);
            this.txtPhut.Name = "txtPhut";
            this.txtPhut.Size = new System.Drawing.Size(100, 23);
            this.txtPhut.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số phút có";
            // 
            // txtProductKey
            // 
            this.txtProductKey.Location = new System.Drawing.Point(139, 28);
            this.txtProductKey.Name = "txtProductKey";
            this.txtProductKey.Size = new System.Drawing.Size(314, 23);
            this.txtProductKey.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Số phút đã sử dụng";
            // 
            // btnSearchEmail
            // 
            this.btnSearchEmail.Location = new System.Drawing.Point(464, 70);
            this.btnSearchEmail.Name = "btnSearchEmail";
            this.btnSearchEmail.Size = new System.Drawing.Size(75, 23);
            this.btnSearchEmail.TabIndex = 11;
            this.btnSearchEmail.Text = "Tìm";
            this.btnSearchEmail.UseVisualStyleBackColor = true;
            this.btnSearchEmail.Click += new System.EventHandler(this.btnSearchEmail_Click);
            // 
            // btnSeachProductKey
            // 
            this.btnSeachProductKey.Location = new System.Drawing.Point(464, 41);
            this.btnSeachProductKey.Name = "btnSeachProductKey";
            this.btnSeachProductKey.Size = new System.Drawing.Size(75, 23);
            this.btnSeachProductKey.TabIndex = 10;
            this.btnSeachProductKey.Text = "Tìm";
            this.btnSeachProductKey.UseVisualStyleBackColor = true;
            this.btnSeachProductKey.Click += new System.EventHandler(this.btnSeachProductKey_Click);
            // 
            // txtSearchEmail
            // 
            this.txtSearchEmail.Location = new System.Drawing.Point(89, 69);
            this.txtSearchEmail.Name = "txtSearchEmail";
            this.txtSearchEmail.Size = new System.Drawing.Size(360, 23);
            this.txtSearchEmail.TabIndex = 9;
            // 
            // txtSearchProductKey
            // 
            this.txtSearchProductKey.Location = new System.Drawing.Point(89, 41);
            this.txtSearchProductKey.Name = "txtSearchProductKey";
            this.txtSearchProductKey.Size = new System.Drawing.Size(360, 23);
            this.txtSearchProductKey.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ProductKey";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddPhut);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.Key);
            this.tabPage2.Controls.Add(this.txtTransIdAdd);
            this.tabPage2.Controls.Add(this.txtPriceAdd);
            this.tabPage2.Controls.Add(this.txtEmailAdd);
            this.tabPage2.Controls.Add(this.txtKeyAdd);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(558, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Phút";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddPhut
            // 
            this.btnAddPhut.Location = new System.Drawing.Point(378, 162);
            this.btnAddPhut.Name = "btnAddPhut";
            this.btnAddPhut.Size = new System.Drawing.Size(75, 23);
            this.btnAddPhut.TabIndex = 8;
            this.btnAddPhut.Text = "Add Phút";
            this.btnAddPhut.UseVisualStyleBackColor = true;
            this.btnAddPhut.Click += new System.EventHandler(this.btnAddPhut_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "TransId";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email";
            // 
            // Key
            // 
            this.Key.AutoSize = true;
            this.Key.Location = new System.Drawing.Point(6, 36);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(26, 15);
            this.Key.TabIndex = 4;
            this.Key.Text = "Key";
            // 
            // txtTransIdAdd
            // 
            this.txtTransIdAdd.Location = new System.Drawing.Point(126, 120);
            this.txtTransIdAdd.Name = "txtTransIdAdd";
            this.txtTransIdAdd.Size = new System.Drawing.Size(327, 23);
            this.txtTransIdAdd.TabIndex = 3;
            // 
            // txtPriceAdd
            // 
            this.txtPriceAdd.Location = new System.Drawing.Point(126, 91);
            this.txtPriceAdd.Name = "txtPriceAdd";
            this.txtPriceAdd.Size = new System.Drawing.Size(327, 23);
            this.txtPriceAdd.TabIndex = 2;
            // 
            // txtEmailAdd
            // 
            this.txtEmailAdd.Location = new System.Drawing.Point(126, 62);
            this.txtEmailAdd.Name = "txtEmailAdd";
            this.txtEmailAdd.Size = new System.Drawing.Size(327, 23);
            this.txtEmailAdd.TabIndex = 1;
            // 
            // txtKeyAdd
            // 
            this.txtKeyAdd.Location = new System.Drawing.Point(126, 33);
            this.txtKeyAdd.Name = "txtKeyAdd";
            this.txtKeyAdd.PasswordChar = '*';
            this.txtKeyAdd.Size = new System.Drawing.Size(327, 23);
            this.txtKeyAdd.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbSoDienThoaiIncome);
            this.tabPage3.Controls.Add(this.lbHoTenIncome);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.btnCheckIncome);
            this.tabPage3.Controls.Add(this.txtpinCodeCHeck);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.lbTotalIncome);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(558, 308);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Thống Kê";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // btnCheckIncome
            // 
            this.btnCheckIncome.Location = new System.Drawing.Point(298, 16);
            this.btnCheckIncome.Name = "btnCheckIncome";
            this.btnCheckIncome.Size = new System.Drawing.Size(75, 23);
            this.btnCheckIncome.TabIndex = 4;
            this.btnCheckIncome.Text = "Check";
            this.btnCheckIncome.UseVisualStyleBackColor = true;
            this.btnCheckIncome.Click += new System.EventHandler(this.btnCheckIncome_Click);
            // 
            // txtpinCodeCHeck
            // 
            this.txtpinCodeCHeck.Location = new System.Drawing.Point(99, 16);
            this.txtpinCodeCHeck.Name = "txtpinCodeCHeck";
            this.txtpinCodeCHeck.Size = new System.Drawing.Size(182, 23);
            this.txtpinCodeCHeck.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "pinCode";
            // 
            // lbTotalIncome
            // 
            this.lbTotalIncome.AutoSize = true;
            this.lbTotalIncome.Location = new System.Drawing.Point(99, 57);
            this.lbTotalIncome.Name = "lbTotalIncome";
            this.lbTotalIncome.Size = new System.Drawing.Size(13, 15);
            this.lbTotalIncome.TabIndex = 1;
            this.lbTotalIncome.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tổng thu nhập";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Họ Tên";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "Số Điện Thoại";
            // 
            // lbHoTenIncome
            // 
            this.lbHoTenIncome.AutoSize = true;
            this.lbHoTenIncome.Location = new System.Drawing.Point(100, 84);
            this.lbHoTenIncome.Name = "lbHoTenIncome";
            this.lbHoTenIncome.Size = new System.Drawing.Size(82, 15);
            this.lbHoTenIncome.TabIndex = 7;
            this.lbHoTenIncome.Text = "Nguyễn văn A";
            // 
            // lbSoDienThoaiIncome
            // 
            this.lbSoDienThoaiIncome.AutoSize = true;
            this.lbSoDienThoaiIncome.Location = new System.Drawing.Point(99, 110);
            this.lbSoDienThoaiIncome.Name = "lbSoDienThoaiIncome";
            this.lbSoDienThoaiIncome.Size = new System.Drawing.Size(55, 15);
            this.lbSoDienThoaiIncome.TabIndex = 8;
            this.lbSoDienThoaiIncome.Text = "00000000";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 374);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtPhutSuDung;
        private System.Windows.Forms.TextBox txtPhut;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtProductKey;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearchEmail;
        private System.Windows.Forms.Button btnSeachProductKey;
        private System.Windows.Forms.TextBox txtSearchEmail;
        private System.Windows.Forms.TextBox txtSearchProductKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Key;
        private System.Windows.Forms.TextBox txtTransIdAdd;
        private System.Windows.Forms.TextBox txtPriceAdd;
        private System.Windows.Forms.TextBox txtEmailAdd;
        private System.Windows.Forms.TextBox txtKeyAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddPhut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtKeySearch;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCheckIncome;
        private System.Windows.Forms.TextBox txtpinCodeCHeck;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbTotalIncome;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbSoDienThoaiIncome;
        private System.Windows.Forms.Label lbHoTenIncome;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
    }
}