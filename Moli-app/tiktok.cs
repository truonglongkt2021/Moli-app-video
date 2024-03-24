using Nevron.Nov.UI;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Moli_app
{
    public partial class tiktok : Form
    {
        public tiktok()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    txtSourceVideoPath.Text = selectedFilePath;
                }
            }
        }

        private void btnSelectDestPath_Click(object sender, EventArgs e)
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
                    txtDestPath.Text = selectedFilePath;
                }
            }
        }

        private async void btnSplitScense_ClickAsync(object sender, EventArgs e)
        {
            var ffpath = Path.Combine(Application.StartupPath, "ffmpeg.exe");
            string videoSourcePath = txtSourceVideoPath.Text;
            //string command = $"-i \"{videoSourcePath}\" -vf blackdetect=d=0.1:pix_th=0.1 -f rawvideo -y NUL";

            bool success = await processV3(ffpath, videoSourcePath);
            if (success)
            {
                // Tiếp tục xử lý sau khi ffmpeg hoàn thành
            }

        }
        private readonly object writeLock = new object();

        public async Task<bool> processV3(string Path_FFMPEG, string videoSourcePath)
        {
            // Thư mục chứa file kết quả sau khi phân tích
            string outputDir = Path.Combine(Path.GetDirectoryName(videoSourcePath), "Scenes");
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
                using (var writer = new StreamWriter(outputFileName))
                {
                    var ffmpeg = new Process();
                    try
                    {
                        ffmpeg.StartInfo.FileName = Path_FFMPEG;
                        ffmpeg.StartInfo.Arguments = $"-i \"{videoSourcePath}\" -filter:v \"select='gt(scene,0.4)',showinfo\" -f null -";
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
                foreach (var scene in sceneChanges)
                {
                    if (scene.end - scene.start <= TimeSpan.Zero)
                    {
                        continue;
                    }    
                    string cutCommand = $" -ss {scene.start} -to {scene.end} -i \"{videoSourcePath}\" -c copy {outputDir}\\output_" +
                        $"{Guid.NewGuid().ToString()}.mp4";
                   rtbResultProcess.AppendText("\n");
                   rtbResultProcess.AppendText(cutCommand);
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
                    cutProcess.WaitForExit();
                }
                rtxError.Text = "done";
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        int count = 0;
        // Handle Exited event and display process information.
        private void myProcess_Exited(object sender, DataReceivedEventArgs e)
        {
            //var text = e.Data;
            rtbResultProcess.Text = e.Data;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    txtBitrateMergeVideo.Text = $"{text.Split("bitrate=")[1].ToString().Split("kbits/s")[0].ToString()}";
            //}
            //if (e.Data != null)
            //    Dispatcher.BeginInvoke(new Action(() => txtOut.Text += (Environment.NewLine + e.Data)));
        }
        private void KillAllFFMPEG()
        {
            Process killFfmpeg = new Process();
            ProcessStartInfo taskkillStartInfo = new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = "/F /IM ffmpeg.exe",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            killFfmpeg.StartInfo = taskkillStartInfo;
            killFfmpeg.Start();
        }

    }
}
