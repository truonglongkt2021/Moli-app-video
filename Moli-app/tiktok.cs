using Moli_app.Common;
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
                    txtDestPath.Text = selectedFolderPath;
                }
            }
        }

        private async void btnSplitScense_ClickAsync(object sender, EventArgs e)
        {
            if(txtSourceVideoPath.Text=="")
            {
                MessageBox.Show("Vui lòng chọn đường dẫn Video");
                return;
            }
            else if(txtDestPath.Text=="")
            {
                MessageBox.Show("Vui lòng chọn đường dẫn tách Video");
                return;
            }    
            btnSplitScense.Enabled = false;
            btnMergeForm.Enabled = false;
            var ffpath = Path.Combine(Application.StartupPath, "amazingtech.exe");
            string videoSourcePath = txtSourceVideoPath.Text;
            //string command = $"-i \"{videoSourcePath}\" -vf blackdetect=d=0.1:pix_th=0.1 -f rawvideo -y NUL";

            bool success = await processV3(ffpath, videoSourcePath);
            if (success)
            {
                btnSplitScense.Enabled = true;
                btnMergeForm.Enabled = true;

            }

        }
        private readonly object writeLock = new object();

        public async Task<bool> processV3(string Path_FFMPEG, string videoSourcePath)
        {
            // Thư mục chứa file kết quả sau khi phân tích
            string outputDir = Path.GetDirectoryName(txtDestPath.Text+"\\Split_"+Guid.NewGuid().ToString());
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
                var ag = $"-i \"{videoSourcePath}\" -filter:v \"mpdecimate,setpts=N/FRAME_RATE/TB,select='gt(scene,0.4)',showinfo -f null -";
                rtxError.AppendText(ag);
                using (var writer = new StreamWriter(outputFileName))
                {
                    var ffmpeg = new Process();
                    try
                    {
                        ffmpeg.StartInfo.FileName = Path_FFMPEG;
                        ffmpeg.StartInfo.Arguments = $"-i \"{videoSourcePath}\" -filter:v \"mpdecimate,setpts=N/FRAME_RATE/TB,select='gt(scene,0.4)',showinfo -f null -";
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
                rtxError.AppendText("done");
                KillAllFFMPEG();
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

        private void btnMergeForm_Click(object sender, EventArgs e)
        {
            LogoModels.Scale = 3;
            // Create an instance of FormABC
            MergeVideo formABC = new MergeVideo();

            // Hide the current form
            this.Hide();

            // Show FormABC
            formABC.Show();

            // Optional: Close the current form when FormABC is closed
            formABC.FormClosed += (s, args) => this.Close();
        }

        private void btnSearchYoutubeShort_Click(object sender, EventArgs e)
        {
            // Create an instance of FormABC
            SearchVideoShort formABC = new SearchVideoShort();

            // Hide the current form
            this.Hide();

            // Show FormABC
            formABC.Show();

            // Optional: Close the current form when FormABC is closed
            formABC.FormClosed += (s, args) => this.Close();
        }
        public LogoModelsV2 logoModelV2 = new LogoModelsV2();
        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (txtSourceVideoPath.Text!="")
            {
                logoModelV2.ImagePath = txtSourceVideoPath.Text;
            }

            AddLogo addLogo = new AddLogo(logoModelV2);
            addLogo.Show();
        }
        public async Task<string> GetPathRandomImagePath(string videoPath)
        {
            Debug.WriteLine("aaaaaa");
            try
            {
                string outputPath = Application.StartupPath + Guid.NewGuid().ToString() + "_Image.png";
                using (var ffmpeg = new Process())
                {
                    ffmpeg.StartInfo.FileName = Application.StartupPath + "amazingtech.exe";
                    ffmpeg.StartInfo.Arguments = rtbResultProcess.Text = " -i \"" + videoPath + "\" -ss 10 -frames:v 1 \"" + outputPath + "\"";
                    ffmpeg.StartInfo.UseShellExecute = false;
                    ffmpeg.StartInfo.RedirectStandardError = true;
                    ffmpeg.StartInfo.RedirectStandardOutput = true;
                    ffmpeg.StartInfo.CreateNoWindow = true;
                    //ffmpeg.OutputDataReceived += (s, e) => Debug.WriteLine($@"data: {e.Data}");
                    //ffmpeg.ErrorDataReceived += (s, e) => Debug.WriteLine($@"Error: {e.Data}");
                    ffmpeg.Start();
                    ffmpeg.BeginOutputReadLine();
                    ffmpeg.BeginErrorReadLine();
                    //string? processOutput = null;
                    //while ((processOutput = ffmpeg.StandardError.ReadLine()) != null)
                    //{
                    //    // do something with processOutput
                    //    this.rtbResultProcess.Text += processOutput;
                    //}
                    //Task.WaitAll();
                    // ffmpeg.WaitForExit();
                    await ffmpeg.WaitForExitAsync().ConfigureAwait(true);
                    //ffmpeg.Close();
                    //ffmpeg.Dispose();
                }
                return outputPath;
            }
            catch (Exception ex)
            {

            }

            return "";
        }
    }
}
