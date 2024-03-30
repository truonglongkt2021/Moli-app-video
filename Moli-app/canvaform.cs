using Moli_app.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moli_app
{
    public partial class canvaform : Form
    {

        private void Canvaform_Load(object sender, EventArgs e)
        {
            if (Program.MinuteRemain <= 0)
            {
                ShowActiveForm();
            }

            // Các hoạt động khác khi form được load
        }

        private void ShowActiveForm()
        {
            var activeForm = new activeForm();
            activeForm.ShowDialog(); // Hiển thị activeForm dưới dạng một dialog
        }
        public canvaform()
        {
            InitializeComponent();
            Util.KillAllFFMPEG();
            // Cố định kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Hoặc FixedDialog, Fixed3D
            this.MaximizeBox = false; // Ngăn không cho phóng to Form

            // Cố định kích thước bằng cách đặt giới hạn kích thước tối thiểu và tối đa
            this.MinimumSize = this.Size; // Hoặc thiết lập một giá trị cụ thể
            this.MaximumSize = this.Size; // Giữ giá trị giống nhau để cố định kích thước
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSearchYoutube_Click(object sender, EventArgs e)
        {
            // Tạo một instance mới của tiktok và kiểm tra điều kiện trước khi hiển thị
            CheckConditionAndShowForm(new SearchVideoShort());
        }
        private void CheckConditionAndShowForm(Form formToOpen)
        {
            // Kiểm tra điều kiện
            if (Program.MinuteRemain > 0)
            {
                // Hiển thị form được truyền vào nếu điều kiện được thỏa mãn
                formToOpen.Show();
            }
            else
            {
                // Hiển thị thông báo nếu điều kiện không được thỏa mãn
                MessageBox.Show("Bạn đã đạt giới hạn số phút được tạo, hãy dùng Product Key mới.");
            }
        }

        private void btnSplitVideo_Click(object sender, EventArgs e)
        {
            // Tạo một instance mới của tiktok và kiểm tra điều kiện trước khi hiển thị
            CheckConditionAndShowForm(new tiktok());
        }

        private void btnMergeVideo_Click(object sender, EventArgs e)
        {
            // Tạo một instance mới của MergeVideo và kiểm tra điều kiện trước khi hiển thị
            CheckConditionAndShowForm(new MergeVideo());
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            // Create an instance of FormABC
            activeForm formABC = new activeForm();
            // Show FormABC
            formABC.Show();
        }
    }
}
