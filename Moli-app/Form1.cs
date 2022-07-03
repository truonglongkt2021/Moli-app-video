using Moli_app.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moli_app
{
    public partial class Form1 : Form
    {
        public List<VideoModels> listVideo = new List<VideoModels>();

        public Form1()
        {
            InitializeComponent();
            //DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            //checkColumn.Name = "select";
            //checkColumn.HeaderText = "Chọn";
            //checkColumn.Width = 50;
            //checkColumn.ReadOnly = false;
            //checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
            //dataGridView1.Columns.Add(checkColumn);
        }

        private void btnAddFolderVideo_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtFolderVideo.Text = fbd.SelectedPath;
                    string[] allowedVideoExtensions = new[] { ".mp4", ".mov", ".wmv", ".avi", ".flv", ".mpeg-2", ".mkv" };
                    FileInfo[] collection = (from fi in new DirectoryInfo(fbd.SelectedPath).GetFiles()
                                             where allowedVideoExtensions.Contains(fi.Extension.ToLower())
                                             select fi)
                         .ToArray();
                    //show number of video read
                    txtTotalVideoEachVideo_1.Text = collection.Length.ToString();
                    //string[] files = (string[])Directory.GetFiles(fbd.SelectedPath).Where(file => allowedVideoExtensions.Any(file.ToLower().EndsWith));
                    foreach (var file in collection)
                    {
                        // var filePath = fbd.SelectedPath +"\\" + file;
                        listVideo.Add(new VideoModels { Num = collection.ToList().IndexOf(file) + 1, FileName = Path.GetFileName(file.Name), FilePath = file.FullName });
                    }
                    dataGridView1.DataSource = listVideo;
                }
            }
        }

        private void btnAddFirstVideo_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (!fbd.SelectedPath.EndsWith("\\"))
                    {
                        fbd.SelectedPath += "\\";
                    }
                    txtAddFirstVideo.Text = fbd.SelectedPath;
                    string[] allowedVideoExtensions = new[] { ".mp4", ".mov", ".wmv", ".avi", ".flv", ".mpeg-2", ".mkv" };
                    FileInfo[] collection = (from fi in new DirectoryInfo(fbd.SelectedPath).GetFiles()
                                             where allowedVideoExtensions.Contains(fi.Extension.ToLower())
                                             select fi)
                         .ToArray();
                    cbSelectVideoFirst.Enabled = true;
                    cbSelectVideoFirst.Items.AddRange(collection.Select(o => o.Name).ToArray());
                }
            }
        }

        private void btnAddLastVideo_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (!fbd.SelectedPath.EndsWith("\\"))
                    {
                        fbd.SelectedPath += "\\";
                    }
                    txtAddLastVideo.Text = fbd.SelectedPath;
                    string[] allowedVideoExtensions = new[] { ".mp4", ".mov", ".wmv", ".avi", ".flv", ".mpeg-2", ".mkv" };
                    FileInfo[] collection = (from fi in new DirectoryInfo(fbd.SelectedPath).GetFiles()
                                             where allowedVideoExtensions.Contains(fi.Extension.ToLower())
                                             select fi)
                         .ToArray();
                    cbSelectVideoLast.Enabled = true;
                    cbSelectVideoLast.Items.AddRange(collection.Select(o => o.Name).ToArray());
                }
            }
        }

        private void btnVideoOutput_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (!fbd.SelectedPath.EndsWith("\\"))
                    {
                        fbd.SelectedPath += "\\";
                    }
                    txtVideoOutput.Text = fbd.SelectedPath;

                }
            }
        }

        private void btnAddLogo_Click(object sender, EventArgs e)
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
        }

        private void btnProcess1_Click(object sender, EventArgs e)
        {
            btnProcess1.Enabled = false;
            var firstPath = txtAddFirstVideo.Text + cbSelectVideoFirst.SelectedItem;
            var lastPath = txtAddLastVideo.Text + cbSelectVideoLast.SelectedItem;
            var outputPath = txtVideoOutput.Text;
            var logoPath = txtLogoPath.Text;
            var mergef = new Util();
            var result = mergef.MergeFiles(listVideo, firstPath, lastPath, logoPath, outputPath);
            rtbCommandProcess.Text = result[1];
            process(result[0], result[1]);
            btnProcess1.Enabled = true;

        }
        public void ProgressMessage(string message)
        {
            this.rtbResultProcess.Text = message;
        }
       
        public void process(string Path_FFMPEG, string strParam)
        {
            try
            {
                Process ffmpeg = new Process
                {

                    StartInfo = new ProcessStartInfo
                    {
                        FileName = Path_FFMPEG,
                        Arguments = strParam,
                        UseShellExecute = false,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                    },
                    EnableRaisingEvents = true
                };
                ffmpeg.Start();
                //string? processOutput = null;
                //while ((processOutput = ffmpeg.StandardError.ReadLine()) != null)
                //{
                //    // do something with processOutput
                //    this.rtbResultProcess.Text += processOutput;
                //}
                ffmpeg.WaitForExit(3000);
                //ffmpeg.WaitForExit();
                ffmpeg.Close();
                ffmpeg.Dispose();
                ffmpeg = null;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
