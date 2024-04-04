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

namespace Moli_app
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private async void btnAddPhut_Click(object sender, EventArgs e)
        {
            if (txtKeyAdd.Text=="" || txtEmailAdd.Text=="" || txtPriceAdd.Text=="" || txtTransIdAdd.Text=="")
            {
                MessageBox.Show("Vui Lòng điền đủ thông tin");
                return;
            }
            else
            {
                DisableAllButtons(this, false);
                var result = await ApiHelper.Addtrans(txtKeyAdd.Text,txtEmailAdd.Text,double.Parse(txtPriceAdd.Text),txtTransIdAdd.Text);
                if (result)
                {
                    MessageBox.Show("Đã tạo thành công số phút, vui lòng check lại lần nữa");
                    DisableAllButtons(this, true);

                    return;
                }
                else
                {
                    MessageBox.Show("Tạo thất bại, vui lòng kiểm tra lại");
                    DisableAllButtons(this, true);

                    return;
                }
            }
        }

        private async void btnSeachProductKey_Click(object sender, EventArgs e)
        {
            if (txtSearchProductKey.Text=="")
            {
                MessageBox.Show("Vui lòng nhập Product key");
                return;
            }
            if (txtKeySearch.Text=="")
            {
                MessageBox.Show("Vui lòng nhập Product key");
                return;
            }
            DisableAllButtons(this, false);
            var result = await ApiHelper.CheckInfoByEmailorProductKey(txtKeySearch.Text,"", txtSearchProductKey.Text);
            txtProductKey.Text = result.ProductKey;
            txtEmail.Text = result.Email;
            txtPhutSuDung.Text = Math.Round((result.NumberUsed / 60), 1).ToString() + " Phút";
            txtPhut.Text = Math.Round((result.NumberMin / 60), 1).ToString() + " Phút";
            DisableAllButtons(this, true);

        }

        private async void btnSearchEmail_Click(object sender, EventArgs e)
        {
            if (txtKeySearch.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Product key");
                return;
            }
            if (txtSearchEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Email");
            }
            DisableAllButtons(this, false);
            var result = await ApiHelper.CheckInfoByEmailorProductKey(txtKeySearch.Text, txtSearchEmail.Text,"");
            txtProductKey.Text = result.ProductKey;
            txtEmail.Text = result.Email;
            txtPhutSuDung.Text = Math.Round((result.NumberUsed / 60), 1).ToString() + " Phút";
            txtPhut.Text = Math.Round((result.NumberMin / 60), 1).ToString() + " Phút";
            DisableAllButtons(this, true);

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
    }
}
