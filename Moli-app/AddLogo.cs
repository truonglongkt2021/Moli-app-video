using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Moli_app.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moli_app
{
    public partial class AddLogo : Form
    {
        LogoModelsV2 _LogoModelV2 = new LogoModelsV2();
        LibVLC _libVLC;
        public AddLogo(LogoModelsV2 logoModelV2)
        {
            InitializeComponent();
            _LogoModelV2 = logoModelV2;

            // Tải ảnh gốc
            //Image originalImage = Image.FromFile(logoModelV2.ImagePath);

            //// Sử dụng ResizeKeepAspect để tính toán kích thước mới mà không vượt quá chiều ngang 239px
            //Size newSize = LogoModels.ResizeKeepAspect(originalImage.Size, 239, int.MaxValue, false); // Sử dụng int.MaxValue cho chiều cao để không giới hạn chiều cao

            //// Tạo một Bitmap mới với kích thước đã được điều chỉnh
            //Bitmap finalImg = new Bitmap(originalImage, newSize.Width, newSize.Height);

            //// Cập nhật PictureBox
            //pbDemoAddLogo.SizeMode = PictureBoxSizeMode.CenterImage; // Hoặc sử dụng PictureBoxSizeMode.Zoom để tự động điều chỉnh kích thước nhưng vẫn giữ tỉ lệ
            //pbDemoAddLogo.Image = finalImg;

            //// Cập nhật kích thước PictureBox để phù hợp với ảnh, nếu muốn
            //pbDemoAddLogo.Size = newSize;

            //pbDemoAddLogo.Show();
            _libVLC = new LibVLC();
            vlcPlayer.MediaPlayer = new MediaPlayer(_libVLC);
            vlcPlayer.MediaPlayer.Play(new Media(_libVLC, logoModelV2.ImagePath, FromType.FromPath));
            // Phần còn lại của code
        }

        private void nSliderControl1_ValueChanged(Nevron.Nov.Dom.NValueChangeEventArgs arg)
        {
            //nSliderControl1.Value;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var buttons = gbPos.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked);
            if (buttons != null)
            {

                switch (buttons.TabIndex)
                {
                    case 1:
                        //Left_top
                        pbLogoOvelay.Location = new Point(23, 27);
                        pbLogoOvelay.Refresh();
                        _LogoModelV2.PosX = tbarX.Value = 23;
                        _LogoModelV2.PosY = tbarY.Value = 27;
                        break;
                    case 2:
                        //left_bottom
                        pbLogoOvelay.Location = new Point(23, (345 - pbLogoOvelay.Height));
                        pbLogoOvelay.Refresh();
                        _LogoModelV2.PosX = tbarX.Value = 23;
                        _LogoModelV2.PosY = tbarY.Value = (345 - pbLogoOvelay.Height);
                        break;
                    case 3:
                        //right_top
                        pbLogoOvelay.Location = new Point((504 - pbLogoOvelay.Width), 27);
                        pbLogoOvelay.Refresh();
                        _LogoModelV2.PosX = tbarX.Value = (504 - pbLogoOvelay.Width);
                        _LogoModelV2.PosY = tbarY.Value = 27;
                        break;
                    default:
                        //right_bottom
                        pbLogoOvelay.Location = new Point((504 - pbLogoOvelay.Width), (345 - pbLogoOvelay.Height));
                        pbLogoOvelay.Refresh();
                        _LogoModelV2.PosX = tbarX.Value = (504 - pbLogoOvelay.Width);
                        _LogoModelV2.PosY = tbarY.Value = (345 - pbLogoOvelay.Height);
                        break;
                }
            }
        }

        private void btnAddLogo2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Files|*.jpg;*.jpeg;*.png";
            //dlg.ShowDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                txtLogoPath.Text = fileName;
            }
            _LogoModelV2.Path_Logo = txtLogoPath.Text;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectLogo_Click(object sender, EventArgs e)
        {
            var checkedButton = gbPos.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            if (checkedButton != null)
                _LogoModelV2.Pos_Logo = (PosLogo)checkedButton.TabIndex;

            _LogoModelV2.Scale = (int)NumScale.Value;
        }

        private void tbarScale_Scroll(object sender, EventArgs e)
        {
            NumScale.Value = tbarScale.Value;
            ShowImages();
            tbarX.Maximum = (504 - pbLogoOvelay.Width)+1;
            tbarY.Maximum = (345 - pbLogoOvelay.Height)+1;
            lbx.Text = tbarX.Maximum.ToString();
            lby.Text = tbarY.Maximum.ToString();
        }

        private void NumScale_KeyPress(object sender, EventArgs e)
        {
            tbarScale.Value = (int)NumScale.Value;
            ShowImages();
            tbarX.Maximum = (504 - pbLogoOvelay.Width)+1;
            tbarY.Maximum = (345 - pbLogoOvelay.Height)+1;
            lbx.Text = tbarX.Maximum.ToString();
            lby.Text = tbarY.Maximum.ToString();
        }
        private void ShowImages()
        {
            pbLogoOvelay.Image = Image.FromFile(_LogoModelV2.Path_Logo);
            var size = LogoModels.ResizeKeepAspect(pbLogoOvelay.Size, tbarScale.Value, tbarScale.Value, false);

            Bitmap finalImg = new Bitmap(pbLogoOvelay.Image, size.Width, size.Height);
            pbLogoOvelay.SizeMode = PictureBoxSizeMode.AutoSize;
            pbLogoOvelay.Image = finalImg;
            pbLogoOvelay.Location = new Point(tbarX.Value, tbarY.Value);
            pbLogoOvelay.Show();
        }

        private void tbarX_ValueChanged(object sender, EventArgs e)
        {
            pbLogoOvelay.Location = new Point(tbarX.Value, pbLogoOvelay.Location.Y);
            _LogoModelV2.PosX = tbarX.Value;
            pbLogoOvelay.Refresh();
        }

        private void tbarY_ValueChanged(object sender, EventArgs e)
        {
            pbLogoOvelay.Location = new Point(pbLogoOvelay.Location.X, tbarY.Value);
            _LogoModelV2.PosY = tbarY.Value;
            pbLogoOvelay.Refresh();
        }
       
        
    }
}
