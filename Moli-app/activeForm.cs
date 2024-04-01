using Moli_app.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
                lbMinute.Text = returnModel.NumberMin.ToString() + " Giây";
                lbUsed.Text = returnModel.NumberUsed.ToString() + " Giây";
                DisableAllButtons(this, true);
            }
            catch (Exception ex)
            {
                DisableAllButtons(this, true);
                MessageBox.Show("Error: " + ex.Message);
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
            lbMinute.Text = ReturnModel.NumberMin.ToString() + " Giây";
            lbUsed.Text = ReturnModel.NumberUsed.ToString() + " Giây";
            Program.MinuteRemain = ReturnModel.NumberMin - ReturnModel.NumberUsed;
            Program.MinuteUsed = ReturnModel.NumberUsed;
            DisableAllButtons(this, true);
        }

        private async void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
        private async void button1_Click(object sender, EventArgs e)
        {
            DisableAllButtons(this, false);
            // Kiểm tra xem các trường có bị để trống không
            if (string.IsNullOrWhiteSpace(txtHoten.Text))
            {
                DisableAllButtons(this, true);
                MessageBox.Show("Họ tên không được để trống!");
                return; // Dừng xử lý thêm nếu trường này bị lỗi
            }

            if (string.IsNullOrWhiteSpace(txtSodienthoai.Text))
            {
                DisableAllButtons(this, true);
                MessageBox.Show("Số điện thoại không được để trống!");
                return; // Dừng xử lý thêm nếu trường này bị lỗi
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                DisableAllButtons(this, true);
                MessageBox.Show("Email không được để trống!");
                return; // Dừng xử lý thêm nếu trường này bị lỗi
            }

            // Kiểm tra định dạng Email
            Regex regexEmail = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"); // Regex đơn giản cho định dạng Email
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                DisableAllButtons(this, true);
                MessageBox.Show("Email không hợp lệ!");
                return; // Dừng xử lý thêm nếu trường này bị lỗi
            }

            // Kiểm tra định dạng số điện thoại (ví dụ: định dạng Việt Nam)
            Regex regexPhone = new Regex(@"^(0|\+84)\d{9}$"); // Giả sử số điện thoại Việt Nam gồm 10 số và bắt đầu bằng '0' hoặc '+84'
            if (!regexPhone.IsMatch(txtSodienthoai.Text))
            {
                DisableAllButtons(this, true);
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return; // Dừng xử lý thêm nếu trường này bị lỗi
            }

            // Nếu tất cả các kiểm tra đều thành công

            var result = await ApiHelper.CreateUser(txtHoten.Text, txtSodienthoai.Text, txtEmail.Text);
            if (result.IsActive)
            {
                //Program.MinuteRemain = result.NumberMin - result.NumberUsed;
                //Program.MinuteUsed = result.NumberUsed;
                MessageBox.Show("Product Key đã được gửi qua mail, vui lòng check mail để nhận Product Key");
                DisableAllButtons(this, true);
                return;
            }
            else
            {
                MessageBox.Show(result.Message);
                DisableAllButtons(this, true);
                return;
            }
        }
        // Biến cờ để kiểm soát việc thêm ký tự để tránh vòng lặp vô tận
        private bool isProgrammaticallyChanged = false;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isProgrammaticallyChanged) return;

            // Lấy nội dung hiện tại của TextBox và chuyển thành chữ hoa
            string text = txtProductKey.Text.ToUpper().Replace("-", ""); // Chuyển thành chữ hoa và loại bỏ dấu gạch ngang

            // Kiểm tra và thêm dấu gạch ngang ở vị trí thích hợp
            if (text.Length > 16) text = text.Substring(0, 16); // Giới hạn độ dài tối đa

            string newText = "";
            for (int i = 0; i < text.Length; i++)
            {
                newText += text[i];
                if ((i + 1) % 4 == 0 && i + 1 < text.Length) newText += "-";
            }

            isProgrammaticallyChanged = true;

            int selectionStart = txtProductKey.SelectionStart; // Lưu vị trí con trỏ hiện tại
            txtProductKey.Text = newText;
            // Điều chỉnh vị trí con trỏ, tính thêm dấu gạch ngang nếu cần
            txtProductKey.SelectionStart = selectionStart + ((selectionStart + 1) % 5 == 0 ? 1 : 0);

            isProgrammaticallyChanged = false;
        }

        private async void btnReProduct_Click(object sender, EventArgs e)
        {
            DisableAllButtons(this, false);
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                DisableAllButtons(this, true);
                MessageBox.Show("Email không được để trống!");
                return; // Dừng xử lý thêm nếu trường này bị lỗi
            }
            // Kiểm tra định dạng Email
            Regex regexEmail = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"); // Regex đơn giản cho định dạng Email
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                DisableAllButtons(this, true);
                MessageBox.Show("Email không hợp lệ!");
                return; // Dừng xử lý thêm nếu trường này bị lỗi
            }
            var result = await ApiHelper.ReCreateProductKey(txtEmail.Text);
            if (result.IsActive)
            {
                MessageBox.Show(result.Message);
                DisableAllButtons(this, true);
                return;
            }
            else
            {
                MessageBox.Show(result.Message);
                DisableAllButtons(this, true);
                return;
            }
        }

        private void btnGetQRCode_Click(object sender, EventArgs e)
        {
            var amount = cbAmount.SelectedIndex==1?500000:1000000;
            var productKey = SystemInfoHelper.getProductKey(); // Giả sử bạn đã có hàm GetProductKey()
            var url = $"https://img.vietqr.io/image/970423-00136212001-compact2.jpg?amount={amount}&addInfo={productKey}&accountName=Truong%20Long";
            pbQRcode.SizeMode = PictureBoxSizeMode.Zoom;
            LoadImageAsync(url);
        }
        // Hàm tải và hiển thị hình ảnh
        public async Task LoadImageAsync(string imageUrl)
        {
            using (var client = new HttpClient())
            {
                // Tải hình ảnh từ URL
                var response = await client.GetAsync(imageUrl);
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        var image = Image.FromStream(stream);

                        // Đảm bảo thực hiện việc cập nhật UI từ luồng UI
                        this.Invoke((MethodInvoker)delegate
                        {
                            // Gán hình ảnh cho PictureBox
                            pbQRcode.Image = image;
                        });
                    }
                }
                else
                {
                    // Xử lý trường hợp không tải được hình ảnh
                    MessageBox.Show("Không thể tải hình ảnh.");
                }
            }
        }
    }
}
