using MediaInfo;
using Moli_app.Common;
using Nevron.Nov.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using MediaInfoLib = MediaInfo;
namespace Moli_app
{

    public partial class MergeVideo : Form
    {
        public static List<VideoShort> VideoShorts = new List<VideoShort>();
        public static List<AudioShort> AudioShorts = new List<AudioShort>();
        int count = 0;
        public MergeVideo()
        {
            InitializeComponent();
            cbPosition.SelectedIndex = 0;
            Util.KillAllFFMPEG();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Cố định kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Hoặc FixedDialog, Fixed3D
            this.MaximizeBox = false; // Ngăn không cho phóng to Form

            // Cố định kích thước bằng cách đặt giới hạn kích thước tối thiểu và tối đa
            this.MinimumSize = this.Size; // Hoặc thiết lập một giá trị cụ thể
            this.MaximumSize = this.Size; // Giữ giá trị giống nhau để cố định kích thước
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

        private async void btnMergeVideo_Click(object sender, EventArgs e)
        {
            rtbResultMessage.Text = "";
            rtxMessageProcess.Text = "";
            DisableAllButtons(this, false);
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
                // Tính tổng thời lượng của tất cả các video trong tất cả các MixVideo


                TimeSpan totalDuration = listMix
                    .SelectMany(mix => mix.listVideo) // Chuyển đổi listMix thành một sequence của tất cả các VideoShort
                    .Aggregate(TimeSpan.Zero, (total, video) => total + video.Duration); // Tính tổng thời lượng
                var checkSecond = await UpdateSecond(totalDuration.TotalSeconds);
                if (!checkSecond)
                {
                    MessageBox.Show("Bạn không đủ số phút để làm tiếp, vui lòng mua thêm gói");
                    return;
                }


                //dem so video can được tạo
                count = listMix.Count();
                // Giả sử bạn đã định nghĩa SemaphoreSlim ở cấp lớp hoặc cấp phương thức
                SemaphoreSlim semaphore = new SemaphoreSlim((int)numOfPress.Value); // Cho phép tối đa 3 thread đồng thời
                bool intro = false;
                bool outTro = false;
                foreach (var item in listMix)
                {

                    // Chờ một slot trống từ semaphore
                    await semaphore.WaitAsync();

                    Task.Run(async () =>
                    {
                        try
                        {
                            await Util.MergeVideosWithAudio(item, txtOutputPath.Text, isHorizontal, isMirror, UpdateUI,
                                                            DoneProcess, speed, isTreCon, isNguoiLon);
                        }
                        catch (Exception ex)
                        {
                            // Xử lý lỗi ở đây
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            // Đảm bảo luôn giải phóng semaphore, ngay cả khi có lỗi
                            semaphore.Release();
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateUI(string message)
        {
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new Action(() => rtxMessageProcess.AppendText((message + Environment.NewLine))));
            //}
            //else
            //{
            //    rtxMessageProcess.AppendText((message + Environment.NewLine));
            //}
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => rtxMessageProcess.AppendText((Guid.NewGuid().ToString()))));
            }
            else
            {
                rtxMessageProcess.AppendText((Guid.NewGuid().ToString()));
                rtxMessageProcess.SelectionStart = rtxMessageProcess.Text.Length;

                // Cuộn đến caret, đảm bảo văn bản mới thêm được hiển thị
                rtxMessageProcess.ScrollToCaret();
                // Cập nhật UI ở đây, ví dụ:
                //rtb.AppendText(message + Environment.NewLine);
            }
        }
        public void DoneProcess(int i)
        {
            count = count - i;
            rtbResultMessage.AppendText("1 Video đã Hoàn tất" + Environment.NewLine);
            if (count == 0)
            {
                rtbResultMessage.AppendText("Tất cả video đã hoàn tất" + Environment.NewLine);
                DisableAllButtons(this, true);
                rtbResultMessage.SelectionStart = rtbResultMessage.Text.Length;

                // Cuộn đến caret, đảm bảo văn bản mới thêm được hiển thị
                rtbResultMessage.ScrollToCaret();
            }
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

            try
            {

                double totalDuration = GetVideoDuration(txtVideoToAudio.Text); // Tính tổng thời lượng
                var checkSecond = await UpdateSecond(totalDuration);
                if (!checkSecond)
                {
                    MessageBox.Show("Bạn không đủ số phút để làm tiếp, vui lòng mua thêm gói");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong lúc tính tổng thời gian, vui lòng chọn lại danh sách video");
                return;
            }

            var sourceVideoPath = txtVideoToAudio.Text;
            var isTrecon = rbHighAudio.Checked;
            var isNguoilon = rbLowAudio.Checked;
            var isNormal = rbDefaultAudio.Checked;
            //await Util.ExportAudiosFromVideosFolderAsync(sourceVideoPath, txtOutputPath.Text, isTrecon, isNguoilon, isNormal);
            await Util.ExportAudiosFromVideosAsync(sourceVideoPath, txtPathOutputExportAudio.Text, isTrecon, isNguoilon, isNormal);
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
            //using (var fbd = new FolderBrowserDialog())
            //{
            //    // Dialog box description
            //    fbd.Description = "Select a destination folder";

            //    // Show the dialog
            //    DialogResult result = fbd.ShowDialog();

            //    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            //    {
            //        string selectedFolderPath = fbd.SelectedPath;
            //        // Display the selected folder path in a TextBox
            //        txtVideoToAudio.Text = selectedFolderPath;
            //    }
            //}
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

        private void btnPathIntroVideo_Click(object sender, EventArgs e)
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
                    txtPathIntro.Text = selectedFilePath;
                }
            }
        }

        private void btnPathVideoOutTro_Click(object sender, EventArgs e)
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
                    txtPathOuttro.Text = selectedFilePath;
                }
            }
        }

        private async void btnMergeIntroOuttro_Click(object sender, EventArgs e)
        {
            DisableAllButtons(this, false);
            rtbResultMessage.Text = "";
            rtxMessageProcess.Text = "";
            var ListMixVideo = new List<MixVideo>();
            var intro = false;
            var outtro = false;

            if (!string.IsNullOrEmpty(txtOutputPath.Text))
            {
                // Get all video files in the selected folder
                var videoFiles = Directory.EnumerateFiles(txtOutputPath.Text, "*.*", SearchOption.TopDirectoryOnly)
                 .Where(s => s.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase)
                             || s.EndsWith(".avi", StringComparison.OrdinalIgnoreCase)
                             || s.EndsWith(".mov", StringComparison.OrdinalIgnoreCase)
                             || s.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase)).ToList();

                // Prepare the DataGridView to display the files
                // Populate the DataGridView with video files
                foreach (string file in videoFiles)
                {
                    var listVideo = new MixVideo();
                    // Gắn intro nếu có
                    if (!string.IsNullOrEmpty(txtPathIntro.Text))
                    {
                        var introVideo = new VideoShort
                        {
                            FullPath = txtPathIntro.Text,
                            FileName = "_11111_" + Path.GetFileName(txtPathIntro.Text), // Lấy tên file
                            Duration = Util.GetMediaDurationWithFFmpeg(txtPathIntro.Text) // Giả sử bạn có phương thức này để lấy thời lượng
                        };

                        // Chèn introVideo vào đầu danh sách
                        listVideo.listVideo.Add(introVideo);
                        intro = true;
                    }
                    var vid = new VideoShort();
                    string fileName = Path.GetFileName(file); // Get the file name
                    var Dura = Util.GetMediaDurationWithFFmpeg(file);
                    vid.FileName = fileName;
                    vid.FullPath = file;
                    vid.Duration = Dura;
                    VideoShorts.Add(vid);
                    listVideo.listVideo.Add(vid);
                    try
                    {


                        // Gắn outtro nếu có
                        if (!string.IsNullOrEmpty(txtPathOuttro.Text))
                        {
                            var outroVideo = new VideoShort
                            {
                                FullPath = txtPathOuttro.Text,
                                FileName = "_11111_" + Path.GetFileName(txtPathOuttro.Text), // Lấy tên file
                                Duration = Util.GetMediaDurationWithFFmpeg(txtPathOuttro.Text) // Giả sử bạn có phương thức này để lấy thời lượng
                            };

                            // Thêm outroVideo vào cuối danh sách
                            listVideo.listVideo.Add(outroVideo);
                            outtro = true;
                        }
                        ListMixVideo.Add(listVideo);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                TimeSpan totalDuration = ListMixVideo
                    .SelectMany(mix => mix.listVideo) // Chuyển đổi listMix thành một sequence của tất cả các VideoShort
                    .Aggregate(TimeSpan.Zero, (total, video) => total + video.Duration); // Tính tổng thời lượng
                var checkSecond = await UpdateSecond(totalDuration.TotalSeconds);
                if (!checkSecond)
                {
                    MessageBox.Show("Bạn không đủ số phút để làm tiếp, vui lòng mua thêm gói");
                    return;
                }

                //txtOutputPath.Text tạo thư mục OutputWithIntro trong 
                string outputDirectory = Path.Combine(txtOutputPath.Text, "OutputWithIntro");

                // Kiểm tra xem thư mục đã tồn tại hay chưa
                if (!Directory.Exists(outputDirectory))
                {
                    // Tạo thư mục mới nếu nó chưa tồn tại
                    Directory.CreateDirectory(outputDirectory);
                }
                var isHorizontal = false;
                if (rbHorizontal.Checked)
                {
                    isHorizontal = true;
                }
                // Giả sử bạn đã định nghĩa SemaphoreSlim ở cấp lớp hoặc cấp phương thức
                SemaphoreSlim semaphore = new SemaphoreSlim((int)numOfPress.Value); // Cho phép tối đa 3 thread đồng thời
                count = ListMixVideo.Count;

                foreach (var item in ListMixVideo)
                {

                    // Chờ một slot trống từ semaphore
                    await semaphore.WaitAsync();

                    Task.Run(async () =>
                    {
                        try
                        {
                            await Util.MergeVideoIntroOutro(item, outputDirectory, UpdateUI,
                                                            DoneProcess, isHorizontal);
                        }
                        catch (Exception ex)
                        {
                            // Xử lý lỗi ở đây
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            // Đảm bảo luôn giải phóng semaphore, ngay cả khi có lỗi
                            semaphore.Release();
                        }
                    });
                }
            }



        }

        private async void button1_Click(object sender, EventArgs e)
        {
            rtbResultMessage.Text = "";
            rtxMessageProcess.Text = "";
            var ListMixVideo = new List<MixVideo>();
            var intro = false;
            var outtro = false;

            if (!string.IsNullOrEmpty(txtOutputPath.Text))
            {
                // Get all video files in the selected folder
                var videoFiles = Directory.EnumerateFiles(txtOutputPath.Text, "*.*", SearchOption.TopDirectoryOnly)
                 .Where(s => s.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase)
                             || s.EndsWith(".avi", StringComparison.OrdinalIgnoreCase)
                             || s.EndsWith(".mov", StringComparison.OrdinalIgnoreCase)
                             || s.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase)).ToList();

                // Prepare the DataGridView to display the files
                // Populate the DataGridView with video files
                foreach (string file in videoFiles)
                {
                    var listVideo = new MixVideo();
                    // Gắn intro nếu có
                    if (!string.IsNullOrEmpty(txtPathIntro.Text))
                    {
                        var introVideo = new VideoShort
                        {
                            FullPath = txtPathIntro.Text,
                            FileName = "_11111_" + Path.GetFileName(txtPathIntro.Text), // Lấy tên file
                            Duration = Util.GetMediaDurationWithFFmpeg(txtPathIntro.Text) // Giả sử bạn có phương thức này để lấy thời lượng
                        };

                        // Chèn introVideo vào đầu danh sách
                        listVideo.listVideo.Add(introVideo);
                        intro = true;
                    }
                    ListMixVideo.Add(listVideo);
                }
                //txtOutputPath.Text tạo thư mục OutputWithIntro trong 
                string outputDirectory = Path.Combine(txtOutputPath.Text, "OutputWithIntro");

                // Kiểm tra xem thư mục đã tồn tại hay chưa
                if (!Directory.Exists(outputDirectory))
                {
                    // Tạo thư mục mới nếu nó chưa tồn tại
                    Directory.CreateDirectory(outputDirectory);
                }

                // Giả sử bạn đã định nghĩa SemaphoreSlim ở cấp lớp hoặc cấp phương thức
                SemaphoreSlim semaphore = new SemaphoreSlim((int)numOfPress.Value); // Cho phép tối đa 3 thread đồng thời
                foreach (var item in ListMixVideo)
                {

                    // Chờ một slot trống từ semaphore
                    await semaphore.WaitAsync();

                    Task.Run(async () =>
                    {
                        try
                        {
                            await Util.MergeVideoIntroOutro(item, outputDirectory, UpdateUI,
                                                            DoneProcess);
                        }
                        catch (Exception ex)
                        {
                            // Xử lý lỗi ở đây
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            // Đảm bảo luôn giải phóng semaphore, ngay cả khi có lỗi
                            semaphore.Release();
                        }
                    });
                }
            }
        }

        private void btnSelectLogoPath_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                // Thiết lập filter để chỉ hiển thị các file video
                ofd.Filter = "Images Files|*.jpg;*.png;";

                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    string selectedFilePath = ofd.FileName;
                    // Sử dụng đường dẫn file đã chọn ở đây
                    // Ví dụ: Hiển thị đường dẫn file trong một TextBox
                    txtPathLogo.Text = selectedFilePath;

                    // Hiển thị ảnh trên PictureBox
                    pbLogo.Image = System.Drawing.Image.FromFile(selectedFilePath);

                    // Tùy chỉnh PictureBox để phù hợp với kích thước của ảnh hoặc theo ý muốn
                    pbLogo.SizeMode = PictureBoxSizeMode.StretchImage; // Hoặc một giá trị khác như PictureBoxSizeMode.Normal, PictureBoxSizeMode.AutoSize,...
                }
            }
        }

        private void btnPathAddLogo_Click(object sender, EventArgs e)
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
                    txtPathVideoAddLogo.Text = selectedFolderPath;
                }
            }
        }

        private async void btnAddLogo_Click(object sender, EventArgs e)
        {
            DisableAllButtons(this, false);
            if (String.IsNullOrEmpty(txtPathLogo.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn logo");
                return;
            }
            if (String.IsNullOrEmpty(txtPathVideoAddLogo.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn output");
                return;
            }

            string logoPath = txtPathLogo.Text;
            string outputPath = Path.Combine(txtPathVideoAddLogo.Text, "addlogo");

            // Tạo thư mục outputPath nếu nó không tồn tại
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            var trackbarSize = trackSize.Value;
            var trackbarTrans = trackTransparent.Value;
            bool whitecolor = rbWhiteTranparent.Checked;
            var position = cbPosition.SelectedItem.ToString(); // Lấy vị trí được chọn từ ComboBox
            // Tìm tất cả các tệp video trong thư mục pathOutPut
            string[] videoFiles = Directory.GetFiles(txtPathVideoAddLogo.Text, "*.*", SearchOption.TopDirectoryOnly)
                                    .Where(file => file.EndsWith(".mp4") || file.EndsWith(".avi")).ToArray(); // Bổ sung thêm các định dạng video nếu cần
            var ffpath = Path.Combine(System.Windows.Forms.Application.StartupPath, "amazingtech.exe"); // Đảm bảo rằng bạn đã đổi "amazingtech.exe" thành "ffmpeg.exe" hoặc đường dẫn chính xác của ffmpeg
            try
            {

                double totalDuration = GetTotalDurationForList(videoFiles.ToList()); // Tính tổng thời lượng
                var checkSecond = await UpdateSecond(totalDuration);
                if (!checkSecond)
                {
                    MessageBox.Show("Bạn không đủ số phút để làm tiếp, vui lòng mua thêm gói");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong lúc tính tổng thời gian, vui lòng chọn lại danh sách video");
                return;
            }

            foreach (string videoFile in videoFiles)
            {
                //string outputFilePath = Path.Combine(outputPath, Path.GetFileName(videoFile));

                // Xây dựng câu lệnh ffmpeg
                string ffmpegCmd = BuildFfmpegCommand(logoPath, videoFile, outputPath, trackbarSize, trackbarTrans
                                                        , whitecolor, position);

                // Thực thi ffmpeg để gắn logo vào video
                Process ffmpegProcess = new Process();
                ffmpegProcess.StartInfo.FileName = ffpath; // Đảm bảo ffmpeg có thể được gọi từ Command Line
                ffmpegProcess.StartInfo.Arguments = ffmpegCmd;
                ffmpegProcess.StartInfo.UseShellExecute = false;
                ffmpegProcess.StartInfo.RedirectStandardOutput = true;
                ffmpegProcess.StartInfo.RedirectStandardError = true; // Chuyển hướng đầu ra lỗi
                ffmpegProcess.StartInfo.CreateNoWindow = true;

                ffmpegProcess.OutputDataReceived += (s, ev) =>
                {
                    if (!String.IsNullOrEmpty(ev.Data))
                    {
                        //rtbResultMessage.Invoke(new Action(() => rtbResultMessage.AppendText(ev.Data + Environment.NewLine)));
                        rtbResultMessage.Invoke(new Action(() => rtbResultMessage.AppendText(Guid.NewGuid().ToString())));
                    }
                };

                ffmpegProcess.ErrorDataReceived += (s, ev) =>
                {
                    if (!String.IsNullOrEmpty(ev.Data))
                    {
                        rtbResultMessage.Invoke(new Action(() => rtbResultMessage.AppendText("Error: " + Guid.NewGuid().ToString())));
                    }
                };

                ffmpegProcess.Start();
                ffmpegProcess.BeginOutputReadLine();
                ffmpegProcess.BeginErrorReadLine();
                await ffmpegProcess.WaitForExitAsync();
            }

            DisableAllButtons(this, true);
            MessageBox.Show("Hoàn tất gắn logo vào tất cả video.");
        }

        private string BuildFfmpegCommand(string logoPath, string videoPath, string outputPath, int size, int transparency, bool whiteColor, string position)
        {
            // Tính toán tỉ lệ kích thước
            float sizeFactor = size / 100.0f; // Chuyển đổi giá trị phần trăm thành tỉ lệ

            // Tính toán tỉ lệ độ trong suốt
            float alphaFactor = transparency / 100.0f; // Chuyển đổi giá trị phần trăm thành tỉ lệ, 1 là hoàn toàn không trong suốt

            // Xác định vị trí của logo
            string overlayPosition = GetOverlayPosition(position);

            // Chuẩn bị bộ lọc để điều chỉnh kích thước và độ trong suốt của logo
            string logoFilter = $"[1:v]scale=iw*{sizeFactor}:-1,format=rgba";

            // Nếu whiteColor = true, thêm bộ lọc để làm cho logo trở nên trắng
            // Sử dụng 'colorkey' để loại bỏ màu nền và 'colorchannelmixer' để điều chỉnh độ trong suốt
            if (whiteColor)
            {
                logoFilter += $",colorkey=0x000000:0.1:0.1,colorchannelmixer=aa={alphaFactor}";
            }
            else
            {
                logoFilter += $",colorchannelmixer=aa={alphaFactor}";
            }

            // Hoàn thiện chuỗi filter_complex với bộ lọc logo và overlay
            string filterComplex = $"{logoFilter}[logo];[0:v][logo]overlay={overlayPosition}";

            // Trả về câu lệnh ffmpeg
            return $"-i \"{videoPath}\" -i \"{logoPath}\" -filter_complex \"{filterComplex}\" -codec:a copy \"{outputPath}\\logo_{Guid.NewGuid().ToString()}.mp4\"";
        }
        private string GetOverlayPosition(string position)
        {
            switch (position.ToLower())
            {
                case "trên bên trái":
                    return "10:10";
                case "giữa bên trái":
                    return "10:(main_h-overlay_h)/2";
                case "dưới bên trái":
                    return "10:main_h-overlay_h-10";
                case "giữa ở trên":
                    return "(main_w-overlay_w)/2:10";
                case "trung tâm":
                    return "(main_w-overlay_w)/2:(main_h-overlay_h)/2";
                case "dưới ở giữa":
                    return "(main_w-overlay_w)/2:main_h-overlay_h-10";
                case "trên bên phải":
                    return "main_w-overlay_w-10:10";
                case "giữa bên phải":
                    return "main_w-overlay_w-10:(main_h-overlay_h)/2";
                case "dưới bên phải":
                    return "main_w-overlay_w-10:main_h-overlay_h-10";
                default:
                    return "10:10"; // Mặc định là trên bên trái nếu không khớp với lựa chọn nào
            }
        }
        public static double GetTotalDurationForList(List<string> list)
        {
            double totalDuration = 0;

            foreach (string filePath in list)
            {
                // Gọi GetVideoDuration cho mỗi đường dẫn trong list và cộng dồn vào totalDuration
                totalDuration += GetVideoDuration(filePath);
            }

            return totalDuration; // Trả về tổng thời gian tính bằng giây của tất cả các video trong list
        }

        public static double GetVideoDuration(string filePath)
        {
            using (var mediaInfo = new MediaInfoLib.MediaInfo())
            {
                mediaInfo.Open(filePath);

                // Lấy thời lượng video tính bằng milliseconds
                var durationString = mediaInfo.Get(StreamKind.Video, 0, "Duration");

                // Chuyển đổi thời lượng từ string sang double và sau đó sang TimeSpan
                if (double.TryParse(durationString, out double duration))
                {
                    return TimeSpan.FromMilliseconds(duration).TotalSeconds;
                }
            }

            return 0;
        }
        private static async Task<bool> UpdateSecond(double second)
        {
            try
            {

                var obj = await ApiHelper.SecondUsed(second);
                if (obj.IsActive)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

}
