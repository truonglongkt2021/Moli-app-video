﻿using Moli_app.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;

namespace Moli_app
{

    public partial class MergeVideo : Form
    {
        public static List<VideoShort> VideoShorts = new List<VideoShort>();
        public static List<AudioShort> AudioShorts = new List<AudioShort>();
        public MergeVideo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            var a = LogoModels.Scale;
            trackbarSpeed.ValueChanged += trackbarSpeed_ValueChanged;
        }

        private void btnSplitVideo_Click(object sender, EventArgs e)
        {
            // Create an instance of FormABC
            tiktok formABC = new tiktok();

            // Hide the current form
            this.Hide();

            // Show FormABC
            formABC.Show();

            // Optional: Close the current form when FormABC is closed
            formABC.FormClosed += (s, args) => this.Close();
        }

        private void btnSelectVideoMerge_Click(object sender, EventArgs e)
        {
            var timers = new TimeSpan();
            var util = new Util();
            using (var fbd = new FolderBrowserDialog())
            {
                // Dialog box description
                fbd.Description = "Select a destination folder";

                // Show the dialog
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string selectedFolderPath = fbd.SelectedPath;
                    // Display the selected folder path in a TextBox
                    txtSourceVideoMerge.Text = selectedFolderPath;

                    // Get all video files in the selected folder
                    var videoFiles = Directory.EnumerateFiles(selectedFolderPath, "*.*", SearchOption.TopDirectoryOnly)
                     .Where(s => s.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase)
                                 || s.EndsWith(".avi", StringComparison.OrdinalIgnoreCase)
                                 || s.EndsWith(".mov", StringComparison.OrdinalIgnoreCase)
                                 || s.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase)).ToList();

                    // Prepare the DataGridView to display the files
                    dgvListOutput.Rows.Clear(); // Clear existing rows
                    dgvListOutput.ColumnCount = 2; // Assuming you want two columns: one for the file name and one for the full path
                    dgvListOutput.Columns[0].Name = "File Name";
                    dgvListOutput.Columns[1].Name = "Full Path";

                    // Populate the DataGridView with video files
                    foreach (string file in videoFiles)
                    {
                        var vid = new VideoShort();
                        string fileName = Path.GetFileName(file); // Get the file name
                        dgvListOutput.Rows.Add(new string[] { fileName, file }); // Add file name and full path as a new row in the DataGridView
                        var Dura = Util.GetMediaDurationWithFFmpeg(file);
                        vid.FileName = fileName;
                        vid.FullPath = file;
                        vid.Duration = Dura;
                        VideoShorts.Add(vid);
                        timers += Dura;
                    }
                    lbTotalVideoSource.Text = videoFiles.Count.ToString();
                    lbtotalDurationVideo.Text = timers.ToString();
                }
            }
        }

        private void btnSelectSourceAudio_Click(object sender, EventArgs e)
        {
            var timers = new TimeSpan();

            using (var fbd = new FolderBrowserDialog())
            {
                // Dialog box description
                fbd.Description = "Select a destination folder";

                // Show the dialog
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string selectedFolderPath = fbd.SelectedPath;
                    // Display the selected folder path in a TextBox
                    txtSourceAudio.Text = selectedFolderPath;

                    // Get all video files in the selected folder
                    var audioFiles = Directory.EnumerateFiles(selectedFolderPath, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => s.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)
                     || s.EndsWith(".wav", StringComparison.OrdinalIgnoreCase)
                     || s.EndsWith(".aac", StringComparison.OrdinalIgnoreCase)
                     || s.EndsWith(".flac", StringComparison.OrdinalIgnoreCase)).ToList();

                    // Prepare the DataGridView to display the files
                    dgvAudioList.Rows.Clear(); // Clear existing rows
                    dgvAudioList.ColumnCount = 2; // Assuming you want two columns: one for the file name and one for the full path
                    dgvAudioList.Columns[0].Name = "File Name";
                    dgvAudioList.Columns[1].Name = "Full Path";

                    // Populate the DataGridView with video files
                    foreach (string file in audioFiles)
                    {
                        var audio = new AudioShort();
                        string fileName = Path.GetFileName(file); // Get the file name
                        dgvAudioList.Rows.Add(new string[] { fileName, file }); // Add file name and full path as a new row in the DataGridView
                        var dura = Util.GetMediaDurationWithFFmpeg(file);
                        audio.FileName = fileName;
                        audio.FullPath = file;
                        audio.Duration = dura;
                        AudioShorts.Add(audio);
                        timers += dura;
                    }
                    lbTotalAudio.Text = audioFiles.Count.ToString();
                    lbTotalDurationAudio.Text = timers.ToString();
                }
            }
        }

        private void btnMergeVideo_Click(object sender, EventArgs e)
        {
            DisableAllButtons(this, false);
            gbMergeVideo.Visible = true;
            gbMergeVideo.Value = 1;
            if (!VideoShorts.Any())
            {
                DisableAllButtons(this, true);

                MessageBox.Show("Vui lòng chọn nguồn phát Videos");
                return;
            }
            else if (!AudioShorts.Any())
            {
                DisableAllButtons(this, true);

                MessageBox.Show("Vui lòng chọn nguồn phát Audio");
                return;
            }
            else if (txtOutputPath.Text == "")
            {
                DisableAllButtons(this, true);

                MessageBox.Show("Vui lòng chọn đường dẫn xuất video");
                return;
            }
            var isHorizontal = false;
            if (rbHorizontal.Checked)
            {
                isHorizontal = true;
            }
            btnMergeVideo.Enabled = false;


            bool isMirror = cbMirror.Checked;

            double speed = 1.0; // Giá trị mặc định
            if (!double.TryParse(txtOutputSpeed.Text.TrimEnd('x'), out speed) || speed <= 0)
            {
                // Hiển thị thông báo lỗi nếu giá trị không hợp lệ và đặt giá trị mặc định
                MessageBox.Show("Giá trị tốc độ không hợp lệ. Sử dụng giá trị mặc định 1.0x.");
                speed = 1.0;
            }


            TimeSpan duration = new TimeSpan();
            try
            {
                bool isTreCon = rbVideoVoiceHigh.Checked;
                bool isNguoiLon = rbVideoVoiceLow.Checked;
                bool isFullDuration = false;
                var totalVideoOut = VideoShorts.Count();
                if (!cbFullInputVideo.Checked)
                {
                    totalVideoOut = int.Parse(txtNumOfVideo.Text);
                    duration = TimeSpan.Parse(txtDurationVideo.Text);
                }
                var isAudio = cbIncludeAudio.Checked;
                var isRandom = !cbFullInputVideo.Checked;
                // Parse thành công, 'duration' giờ chứa giá trị TimeSpan tương ứng
                var listMix = Util.MixVideoUtil(VideoShorts, AudioShorts, totalVideoOut, duration, isAudio, isRandom, speed);
                // Kiểm tra để tránh chia cho 0
                if (listMix.Count() > 0)
                {
                    gbMergeVideo.Step = (int)Math.Round((1 / (double)listMix.Count()) * 100, 0);
                }
                else
                {
                    // Đặt gbMergeVideo.Step tới một giá trị mặc định nếu listMix không có phần tử nào
                    gbMergeVideo.Step = 0; // Hoặc bất kỳ giá trị mặc định nào phù hợp
                }
                foreach (var item in listMix)
                {
                    Util.MergeVideosWithAudio(item, txtOutputPath.Text, isHorizontal, isMirror, UpdateUI, speed, isTreCon, isNguoiLon);
                    gbMergeVideo.PerformStep();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            btnMergeVideo.Enabled = true;
            DisableAllButtons(this, true);
            gbMergeVideo.Visible = false;
            gbMergeVideo.Value = 0;
            gbMergeVideo.Step = 0;
        }
        public void UpdateUI(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => rtxMessageProcess.Text = message.Contains("ffmpeg") ? "" : (message + Environment.NewLine)));
            }
            else
            {
                rtxMessageProcess.Text = message.Contains("ffmpeg") ? "" : (message + Environment.NewLine);
            }

            // Cập nhật UI ở đây, ví dụ:
            //rtb.AppendText(message + Environment.NewLine);
        }
        private void cbFullInputVideo_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái của checkbox
            if (cbFullInputVideo.Checked)
            {
                // Nếu checkbox được chọn, disable textbox
                txtDurationVideo.Enabled = false;
                txtNumOfVideo.Enabled = false;
            }
            else
            {
                // Nếu checkbox không được chọn, enable textbox
                txtDurationVideo.Enabled = true;
                txtNumOfVideo.Enabled = true;
            }
        }
        private void trackbarSpeed_ValueChanged(object sender, EventArgs e)
        {
            int trackValue = trackbarSpeed.Value;
            // Chuyển đổi giá trị TrackBar thành tốc độ phát
            // 9 trên TrackBar tương ứng với 0.9x tốc độ, và 15 tương ứng với 1.5x tốc độ
            double speed = 0.1 * (trackValue - 10) + 1.0;
            // Cập nhật Label với tốc độ mới
            txtOutputSpeed.Text = $"{speed:F1}x";
        }
        private void txtOutputSpeed_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtOutputSpeed.Text.TrimEnd('x'), out double speed))
            {
                int trackValue = ConvertSpeedToTrackbarValue(speed);
                trackbarSpeed.Value = Math.Max(trackbarSpeed.Minimum, Math.Min(trackbarSpeed.Maximum, trackValue));
            }
        }

        private int ConvertSpeedToTrackbarValue(double speed)
        {
            return (int)((speed - 1.0) / 0.1 + 10);
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
        private void btnSelectOutputPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                // Dialog box description
                fbd.Description = "Select a destination folder";

                // Show the dialog
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string selectedFolderPath = fbd.SelectedPath;
                    // Display the selected folder path in a TextBox
                    txtOutputPath.Text = selectedFolderPath;
                }
            }
        }

        private void tìmVideoShortToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void btnExportAudio_Click(object sender, EventArgs e)
        {
            DisableAllButtons(this, false);
            if (txtPathOutputExportAudio.Text == "")
            {
                DisableAllButtons(this, true);

                MessageBox.Show("Vui lòng chọn đường dẫn xuất video");
                return;
            }
            else if (txtVideoToAudio.Text == "")
            {
                DisableAllButtons(this, true);

                MessageBox.Show("Vui lòng chọn đường dẫn video muốn tách âm");
                return;
            }
            var sourceVideoPath = txtVideoToAudio.Text;
            var isTrecon = rbHighAudio.Checked;
            var isNguoilon = rbLowAudio.Checked;
            var isNormal = rbDefaultAudio.Checked;
            await Util.ExportAudiosFromVideosFolderAsync(sourceVideoPath, txtOutputPath.Text, isTrecon, isNguoilon, isNormal);
            DisableAllButtons(this, true);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNumOfVideo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPathVideoToAudio_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                // Thiết lập filter để chỉ hiển thị các file video
                ofd.Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv";

                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    string selectedFilePath = ofd.FileName;
                    // Sử dụng đường dẫn file đã chọn ở đây
                    // Ví dụ: Hiển thị đường dẫn file trong một TextBox
                    txtVideoToAudio.Text = selectedFilePath;
                }
            }
        }

        private void btnExportAudioPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                // Dialog box description
                fbd.Description = "Select a destination folder";

                // Show the dialog
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string selectedFolderPath = fbd.SelectedPath;
                    // Display the selected folder path in a TextBox
                    txtPathOutputExportAudio.Text = selectedFolderPath;
                }
            }
        }
    }

}
