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
        public AddLogo()
        {
            InitializeComponent();
            pbDemoAddLogo.Image = Image.FromFile(LogoModels.ImagePath);
            Bitmap finalImg = new Bitmap(pbDemoAddLogo.Image, pbDemoAddLogo.Image.Width, pbDemoAddLogo.Image.Height);
            pbDemoAddLogo.SizeMode = PictureBoxSizeMode.CenterImage;
            pbDemoAddLogo.Image = finalImg;

            pbDemoAddLogo.Show();


            pbLogoPreview.Image = Image.FromFile(LogoModels.Path_Logo);
            //pbLogoPreview.Load(LogoModels.Path_Logo);
            var size = LogoModels.ResizeKeepAspect(pbLogoPreview.Image.Size, 50, 50, false);
            finalImg = new Bitmap(pbLogoPreview.Image, size.Width, size.Height);
            pbLogoPreview.SizeMode = PictureBoxSizeMode.AutoSize;
            pbLogoPreview.Image = finalImg;
            pbLogoPreview.Show();
            ShowImages();


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
                        LogoModels.PosX = tbarX.Value = 23;
                        LogoModels.PosY = tbarY.Value = 27;
                        break;
                    case 2:
                        //left_bottom
                        pbLogoOvelay.Location = new Point(23, (345 - pbLogoOvelay.Height));
                        pbLogoOvelay.Refresh();
                        LogoModels.PosX = tbarX.Value = 23;
                        LogoModels.PosY = tbarY.Value = (345 - pbLogoOvelay.Height);
                        break;
                    case 3:
                        //right_top
                        pbLogoOvelay.Location = new Point((504 - pbLogoOvelay.Width), 27);
                        pbLogoOvelay.Refresh();
                        LogoModels.PosX = tbarX.Value = (504 - pbLogoOvelay.Width);
                        LogoModels.PosY = tbarY.Value = 27;
                        break;
                    default:
                        //right_bottom
                        pbLogoOvelay.Location = new Point((504 - pbLogoOvelay.Width), (345 - pbLogoOvelay.Height));
                        pbLogoOvelay.Refresh();
                        LogoModels.PosX = tbarX.Value = (504 - pbLogoOvelay.Width);
                        LogoModels.PosY = tbarY.Value = (345 - pbLogoOvelay.Height);
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
            LogoModels.Path_Logo = txtLogoPath.Text;
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
                LogoModels.Pos_Logo = (PosLogo)checkedButton.TabIndex;

            LogoModels.Scale = (int)NumScale.Value;
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
            pbLogoOvelay.Image = Image.FromFile(LogoModels.Path_Logo);
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
            LogoModels.PosX = tbarX.Value;
            pbLogoOvelay.Refresh();
        }

        private void tbarY_ValueChanged(object sender, EventArgs e)
        {
            pbLogoOvelay.Location = new Point(pbLogoOvelay.Location.X, tbarY.Value);
            LogoModels.PosY = tbarY.Value;
            pbLogoOvelay.Refresh();
        }
       
        
    }
}
