using Moli_app.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Moli_app
{
    public partial class SearchVideoShort : Form
    {
        public static List<VideoYoutubeShort> listYoutubeShort = new List<VideoYoutubeShort>();
        public SearchVideoShort()
        {
            InitializeComponent();
            dgvListyoutube.Columns.Clear();

            dgvListyoutube.Columns.Add("Title", "Title");

            var thumbnailColumn = new DataGridViewImageColumn()
            {
                HeaderText = "Thumbnail",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Name = "Thumbnail" // Đặt tên cho cột để có thể tham chiếu đến nó sau này
            };
            dgvListyoutube.Columns.Add(thumbnailColumn);

            dgvListyoutube.Columns.Add("VideoUrl", "Link");

            dgvListyoutube.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private readonly object writeLock = new object();
        private Image LoadImageFromUrl(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(url);
                    using (var memStream = new MemoryStream(imageData))
                    {
                        return Image.FromStream(memStream);
                    }
                }
            }
            catch
            {
                // Trả về hình ảnh mặc định hoặc null nếu không thể tải hình ảnh
                return null;
            }
        }
        private void DisplayVideosInDataGridView(List<VideoYoutubeShort> videosList)
        {
            dgvListyoutube.Rows.Clear();

            foreach (var video in videosList)
            {
                int rowIndex = dgvListyoutube.Rows.Add();
                var row = dgvListyoutube.Rows[rowIndex];

                row.Cells["Title"].Value = video.Title;
                row.Cells["Thumbnail"].Value = LoadImageFromUrl(video.ImageUrl);
                row.Cells["VideoUrl"].Value = video.VideoUrl;
            }
        }
        private async void btnSearchYoutube_Click(object sender, EventArgs e)
        {
            btnSearchYoutube.Enabled = false;
            string searchKeyword = txtKeyword.Text; // Lấy từ khóa từ textbox
            string searchchannelName = txtChannelName.Text; // Lấy từ khóa từ textbox
            string countryCode = txtCountry.Text;
            string numVideo = txtNumVideo.Text;
            var youtubedl = Path.Combine(Application.StartupPath, "yt-dlp.exe");

            // Tạo danh sách VideoYoutubeShort để chứa kết quả
            var videosList = new List<VideoYoutubeShort>();

            var youtubeDl = new Process();
            //var args = $" 'https://www.youtube.com/@YoutubeNetFlex/shorts' --get-id --get-title --skip-download --dump-single-json";
            var argsKeyword = $"ytsearch{numVideo}:{searchKeyword} --match-title \"#shorts\" --geo-bypass-country {countryCode} --skip-download --max-downloads {numVideo}  --dump-single-json";
            if (searchchannelName != "")
            {
                argsKeyword = $"\"https://www.youtube.com/@{searchchannelName}/shorts\" --get-id --skip-download  --max-downloads {numVideo}  --dump-single-json";
            }
            try
            {
                youtubeDl.StartInfo.FileName = youtubedl; // Đảm bảo yt-dlp có thể được gọi từ dòng lệnh
                youtubeDl.StartInfo.Arguments = argsKeyword;
                youtubeDl.StartInfo.UseShellExecute = false;
                youtubeDl.StartInfo.RedirectStandardOutput = true;
                youtubeDl.StartInfo.CreateNoWindow = true;

                youtubeDl.Start();

                // Đọc dữ liệu JSON từ đầu ra chuẩn
                string output = await youtubeDl.StandardOutput.ReadToEndAsync();
                await youtubeDl.WaitForExitAsync();
                // Loại bỏ dữ liệu không mong muốn ở cuối chuỗi, nếu có
                // Ví dụ: loại bỏ dòng "null" hoặc bất kỳ ký tự không cần thiết nào ở cuối
                string trimmedOutput = output.TrimEnd(new char[] { ' ', '\n', '\r', '\0' });

                // Cố gắng loại bỏ bất kỳ dòng không cần thiết nào ở cuối chuỗi output
                if (trimmedOutput.EndsWith("null"))
                {
                    trimmedOutput = trimmedOutput.Substring(0, trimmedOutput.LastIndexOf("\n")).TrimEnd();
                }
                // Phân tích dữ liệu JSON thành danh sách VideoYoutubeShort
                dynamic videodata = null;
                if (txtChannelName.Text != "")
                {
                    videodata = trimmedOutput.Split("\n");
                    foreach (var item in videodata)
                    {
                        videosList.Add(new VideoYoutubeShort
                        {
                            Name = item,
                            Title = item,
                            ImageUrl = $"https://i.ytimg.com/vi_webp/{item}/1.webp",
                            VideoUrl = $"https://www.youtube.com/shorts/{item}",
                            Duration = item // Giả sử bạn đã thêm thuộc tính Duration vào lớp VideoYoutubeShort
                        });
                    }
                }
                else
                {
                    videodata = JsonConvert.DeserializeObject<dynamic>(trimmedOutput)["entries"];
                foreach (var video in videodata)
                {
                    videosList.Add(new VideoYoutubeShort
                    {
                        Name = video.uploader,
                        Title = video.title,
                        ImageUrl = video.thumbnail,
                        VideoUrl = $"https://www.youtube.com/shorts/{video.id}",
                        Duration = video.duration // Giả sử bạn đã thêm thuộc tính Duration vào lớp VideoYoutubeShort
                    });
                }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                youtubeDl.Close();
                youtubeDl.Dispose();
                btnSearchYoutube.Enabled = true;
            }
            listYoutubeShort = videosList;
            DisplayVideosInDataGridView(videosList);
            // Sử dụng videosList tại đây, ví dụ: hiển thị lên giao diện người dùng
        }

        private void btnSelectPathDownload_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                // Optionally set a description that appears above the tree view control in the dialog box
                fbd.Description = "Select a destination folder";

                // Optionally set the root folder where the browsing starts from
                // fbd.RootFolder = Environment.SpecialFolder.MyComputer;

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string selectedFolderPath = fbd.SelectedPath;
                    // Use the selected folder path here
                    // For example: Display the folder path in a TextBox
                    txtPathDownload.Text = selectedFolderPath;
                }
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            rtbResult.Text = "";
            int count = 0;
            btnDownload.Enabled = false;
            var youtubedl = Path.Combine(Application.StartupPath, "yt-dlp.exe");
            var pathOutPut = txtPathDownload.Text;
            foreach (var video in listYoutubeShort)
            {
                count++;
                try
                {
                    using (Process youtubeDlProcess = new Process())
                    {
                        // Thiết lập Process để gọi yt-dlp
                        youtubeDlProcess.StartInfo.FileName = youtubedl; // Hoặc đường dẫn đầy đủ tới yt-dlp nếu không có trong PATH
                        youtubeDlProcess.StartInfo.Arguments = $"{video.VideoUrl} -o \"{pathOutPut}\\{txtChannelName.Text}_{Guid.NewGuid().ToString()}.%(ext)s\""; // Định dạng tên file được lưu
                        youtubeDlProcess.StartInfo.UseShellExecute = false;
                        youtubeDlProcess.StartInfo.RedirectStandardOutput = true;
                        youtubeDlProcess.StartInfo.RedirectStandardError = true;
                        youtubeDlProcess.StartInfo.CreateNoWindow = true;

                        // Bắt đầu quá trình và đọc output (nếu cần)
                        youtubeDlProcess.Start();
                        string output = youtubeDlProcess.StandardOutput.ReadToEnd();
                        string error = youtubeDlProcess.StandardError.ReadToEnd();

                        await youtubeDlProcess.WaitForExitAsync();

                        if (!string.IsNullOrEmpty(error))
                        {
                            Console.WriteLine($"Error downloading video {video.Title}: {error}");
                        }
                        else
                        {
                            Console.WriteLine($"Downloaded video {video.Title} successfully.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while downloading video {video.Title}: {ex.Message}");
                }
                rtbResult.Text = "Đã tải " + count.ToString() + "/" + listYoutubeShort.Count().ToString();
            }
            btnDownload.Enabled = true;

        }

        private async void btnSplitVideoYoutube_Click(object sender, EventArgs e)
        {
            if (txtPathDownload.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đường dẫn Video");
                return;
            }
            else if (txtPathSplit.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đường dẫn tách Video");
                return;
            }
            rtbResult.Text = "";
            var ffpath = Path.Combine(Application.StartupPath, "amazingtech.exe");
            string videoSourcePath = txtPathDownload.Text;
            // Danh sách để lưu trữ đường dẫn của tất cả các file video
            List<string> videoPaths = new List<string>();

            // Định nghĩa các phần mở rộng file video bạn muốn tìm kiếm
            string[] videoExtensions = { "*.mp4", "*.avi", "*.mov", "*.mkv" };

            // Duyệt qua mỗi phần mở rộng và thêm các file tìm thấy vào danh sách
            foreach (string extension in videoExtensions)
            {
                // Lấy tất cả các file video với phần mở rộng hiện tại trong thư mục
                string[] files = Directory.GetFiles(videoSourcePath, extension, SearchOption.AllDirectories);

                // Thêm các đường dẫn file vào danh sách
                videoPaths.AddRange(files);
            }

            //string command = $"-i \"{videoSourcePath}\" -vf blackdetect=d=0.1:pix_th=0.1 -f rawvideo -y NUL";
            foreach (var item in videoPaths)
            {
                bool success = await processV3(ffpath, item);

            }
            rtbResult.AppendText("Done");
        }
        public async Task<bool> processV3(string Path_FFMPEG, string videoSourcePath)
        {
            btnSplitVideoYoutube.Enabled = false;
            // Thư mục chứa file kết quả sau khi phân tích
            string outputDir = Path.GetDirectoryName(txtPathSplit.Text + "\\Split_" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(outputDir); // Tạo thư mục nếu chưa tồn tại

            // File lưu kết quả phân tích chuyển cảnh
            string outputFileName = Path.Combine(outputDir, Guid.NewGuid().ToString() + "scene_changes.txt");

            // Kiểm tra xem file đã tồn tại hay chưa
            if (!File.Exists(outputFileName))
            {
                // Tạo file mới nếu nó chưa tồn tại
                using (var stream = File.Create(outputFileName))
                {
                    // Không cần làm gì thêm ở đây, FileStream sẽ tự động đóng khi ra khỏi block using
                }
            }
            try
            {
                //var agrument = $"-i \"{videoSourcePath}\" -filter:v \"select='gt(scene,0.4)',showinfo\" -f null -";
                var agrument = $"-i \"{videoSourcePath}\" -vf \"mpdecimate,setpts=N/FRAME_RATE/TB,select='gt(scene,0.4)',showinfo\" -f null -";
                using (var writer = new StreamWriter(outputFileName))
                {
                    var ffmpeg = new Process();
                    try
                    {
                        ffmpeg.StartInfo.FileName = Path_FFMPEG;
                        ffmpeg.StartInfo.Arguments = agrument;
                        ffmpeg.StartInfo.UseShellExecute = false;
                        ffmpeg.StartInfo.RedirectStandardError = true;
                        ffmpeg.StartInfo.CreateNoWindow = true;

                        ffmpeg.ErrorDataReceived += async (sender, e) =>
                        {
                            if (!string.IsNullOrEmpty(e.Data))
                            {
                                lock (writeLock)
                                {
                                    // Vì đây không phải là một phương thức bất đồng bộ, bạn không cần sử dụng await ở đây
                                    writer.WriteLine(e.Data); // Sử dụng WriteLine thay vì WriteLineAsync
                                }
                            }
                        };

                        ffmpeg.Start();
                        ffmpeg.BeginErrorReadLine();

                        await ffmpeg.WaitForExitAsync();
                    }
                    catch (Exception ex)
                    {
                        ffmpeg.Close();
                        ffmpeg.Dispose();
                        throw;
                    }
                }
                // Giả sử bạn đã thu thập và ghi thông tin chuyển cảnh vào file log
                List<(TimeSpan start, TimeSpan end)> sceneChanges = new List<(TimeSpan, TimeSpan)>();
                string[] lines = File.ReadAllLines(outputFileName);
                string pattern = @"pts_time:(\d+\.\d+)"; // Pattern Regex để tìm kiếm pts_time
                double previousPtsTime = 0.0; // Giữ lại pts_time của frame trước
                foreach (var line in lines)
                {
                    if (line.Contains("showinfo"))
                    {
                        var matches = Regex.Matches(line, pattern);

                        foreach (Match match in matches)
                        {
                            if (match.Success)
                            {
                                if (double.TryParse(match.Groups[1].Value, out double ptsTime))
                                {
                                    // Nếu đây không phải là frame đầu tiên, cập nhật kết thúc của đoạn trước
                                    if (previousPtsTime != 0.0)
                                    {
                                        // Cập nhật kết thúc của đoạn trước với pts_time hiện tại
                                        var lastScene = sceneChanges.Last();
                                        sceneChanges[sceneChanges.Count - 1] = (lastScene.start, TimeSpan.FromSeconds(ptsTime));
                                    }

                                    // Thêm đoạn mới với pts_time hiện tại làm bắt đầu
                                    // Kết thúc sẽ được cập nhật khi tìm thấy frame tiếp theo
                                    sceneChanges.Add((TimeSpan.FromSeconds(ptsTime), TimeSpan.FromSeconds(ptsTime)));

                                    // Cập nhật previousPtsTime
                                    previousPtsTime = ptsTime;
                                }
                            }
                        }
                    }
                }

                // Sử dụng thông tin từ sceneChanges để cắt video
                var hflip = "";
                if (cbMirror.Checked)
                {
                    hflip = "hflip,";
                }
                foreach (var scene in sceneChanges)
                {
                    if (scene.end - scene.start <= TimeSpan.FromMilliseconds(1500))
                    {
                        continue;
                    }
                    string cutCommand = $" -ss {scene.start} -to {scene.end} -i \"{videoSourcePath}\" -vf " +
                        $"\"{hflip}eq=brightness=0.06:contrast=1.5\" -an \"{outputDir}\\output_{Guid.NewGuid().ToString()}.mp4\"";
                    rtbResult.AppendText("\n");
                    rtbResult.AppendText(cutCommand);
                    Process cutProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = Path_FFMPEG,
                            Arguments = cutCommand,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };

                    cutProcess.Start();
                    await cutProcess.WaitForExitAsync();
                }
                btnSplitVideoYoutube.Enabled = true;

                //KillAllFFMPEG();
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        private void KillAllFFMPEG()
        {
            Process killFfmpeg = new Process();
            ProcessStartInfo taskkillStartInfo = new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = "/F /IM amazingtech.exe",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            killFfmpeg.StartInfo = taskkillStartInfo;
            killFfmpeg.Start();
        }
        private void SearchVideoShort_Load(object sender, EventArgs e)
        {

        }

        private void btnPathSplitOutput_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                // Optionally set a description that appears above the tree view control in the dialog box
                fbd.Description = "Select a destination folder";

                // Optionally set the root folder where the browsing starts from
                // fbd.RootFolder = Environment.SpecialFolder.MyComputer;

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string selectedFolderPath = fbd.SelectedPath;
                    // Use the selected folder path here
                    // For example: Display the folder path in a TextBox
                    txtPathSplit.Text = selectedFolderPath;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnBack_Click(object sender, EventArgs e)
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

        private void rtbResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
