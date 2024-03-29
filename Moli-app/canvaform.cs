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
    public partial class canvaform : Form
    {
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
            // Create an instance of FormABC
            SearchVideoShort formABC = new SearchVideoShort();
            // Show FormABC
            formABC.Show();
        }

        private void btnSplitVideo_Click(object sender, EventArgs e)
        {
            // Create an instance of FormABC
            tiktok formABC = new tiktok();
            // Show FormABC
            formABC.Show();
        }

        private void btnMergeVideo_Click(object sender, EventArgs e)
        {
            // Create an instance of FormABC
            MergeVideo formABC = new MergeVideo();
            // Show FormABC
            formABC.Show();
        }
    }
}
