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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            var a = LogoModels.Scale;
            a = a + 1;
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
            DisableAllButtons(this,false);
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
            var totalVideoOut = int.Parse(txtNumOfVideo.Text);
            TimeSpan duration;
            try
            {
                duration = TimeSpan.Parse(txtDurationVideo.Text);
                // Parse thành công, 'duration' giờ chứa giá trị TimeSpan tương ứng
                var listMix = Util.MixVideoUtil(VideoShorts, AudioShorts, totalVideoOut, duration);
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
                    Util.MergeVideosWithAudio(item, txtOutputPath.Text, isHorizontal);
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
        private void DisableAllButtons(Control parent,bool enablebutton=false)
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
                    DisableAllButtons(c);
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
    }

}
