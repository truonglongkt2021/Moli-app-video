using Moli_app.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Moli_app
{
    public partial class activeForm : Form
    {
        public activeForm()
        {
            InitializeComponent();
            DisableAllButtons(this, false);
            this.Load += ActiveForm_Load;
        }
        private async void ActiveForm_Load(object sender, EventArgs e)
        {
            string registryPath = @"HKEY_CURRENT_USER\Software\Amazingtech\AVID";
            string valueName = "ProductKey";
            string defaultValue = "XXX-XXX-XXX-XXX";
            string productKey = defaultValue;
            try
            {
                productKey = (string)Microsoft.Win32.Registry.GetValue(registryPath, valueName, defaultValue);
            }
            catch (Exception)
            {
                DisableAllButtons(this, true);
            }

            if (productKey == defaultValue)
            {
                MessageBox.Show("Default or no product key found.");
                DisableAllButtons(this, true);
            }
            else
            {
                lbProductKey.Text = productKey;
            }

            try
            {
                ActivationResponse returnModel = await ApiHelper.CheckActivate();
                if (!returnModel.IsActive)
                {
                    DisableAllButtons(this, true);
                    return;
                }

                lbProductKey.Text = productKey;
                lbMinute.Text = returnModel.NumberMin.ToString() + " Phút";
                lbUsed.Text = returnModel.NumberUsed.ToString() + " Phút";
                DisableAllButtons(this, true);
            }
            catch (Exception ex)
            {
                DisableAllButtons(this, true);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DisableAllButtons(Control parent, bool enablebutton = false)
        {
            foreach (Control c in parent.Controls)
            {
                // Nếu control là Button, vô hiệu hóa nó
                if (c is Button)
                {
                    ((Button)c).Enabled = enablebutton;
                }

                // Nếu control chứa các control khác (ví dụ: Panel, GroupBox,...), kiểm tra chúng một cách đệ quy
                if (c.HasChildren)
                {
                    DisableAllButtons(c, enablebutton);
                }
            }
        }
        private async void btnActive_Click(object sender, EventArgs e)
        {
            DisableAllButtons(this, false);
            string productKey = txtProductKey.Text == "" ? "1" : txtProductKey.Text;
            // Định nghĩa vị trí lưu trong registry
            // Ví dụ: "HKEY_CURRENT_USER\Software\TênCôngTy\TênỨngDụng"
            string registryPath = @"HKEY_CURRENT_USER\Software\Amazingtech\AVID";

            // Tên của giá trị trong registry
            string valueName = "ProductKey";

            try
            {
                // Lưu giá trị vào registry
                Microsoft.Win32.Registry.SetValue(registryPath, valueName, productKey);

                //MessageBox.Show("Product key has been saved successfully.");
            }
            catch (Exception ex)
            {
                DisableAllButtons(this, true);
                // Xử lý lỗi nếu có
                MessageBox.Show("Error saving product key: " + ex.Message);
            }

            var ReturnModel = await ApiHelper.CheckActivate();
            if (!ReturnModel.IsActive)
            {
                MessageBox.Show("Product Key không chính xác");
                DisableAllButtons(this, true);
                return;
            }
            // showw result 
            lbProductKey.Text = productKey;
            lbMinute.Text = ReturnModel.NumberMin.ToString() + " Phút";
            lbUsed.Text = ReturnModel.NumberUsed.ToString() + " Phút";
            Program.MinuteRemain = ReturnModel.NumberMin - ReturnModel.NumberUsed;
            Program.MinuteUsed= ReturnModel.NumberUsed;
            DisableAllButtons(this, true);
        }

        private async void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
