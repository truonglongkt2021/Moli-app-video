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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moli_app
{
    public partial class Form1 : Form
    {
        public List<VideoModels> listVideo = new List<VideoModels>();
        private string Processlog = "";

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
            listVideo.Clear();
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
                        listVideo.Add(new VideoModels { Num = collection.ToList().IndexOf(file) + 1, GuId = Guid.NewGuid().ToString(), FileName = Path.GetFileName(file.Name), FilePath = file.FullName });
                    }
                    dataGridView1.DataSource = listVideo.Select(p => new { p.Num, p.FilePath, p.FileName, p.TempPath, p.Commandl }).ToList();
                    dataGridView1.Refresh();
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
            LogoModels.Path_Logo = txtLogoPath.Text;
        }

        private async void btnProcess1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                count = 0;
                btnProcess1.Enabled = false;
                List<VideoModels> ListTemp = new List<VideoModels>();
                var fistNameVideo = cbSelectVideoFirst.SelectedItem.ToString();
                var firstPath = txtAddFirstVideo.Text + fistNameVideo;
                ListTemp.Add(new VideoModels { FileName = fistNameVideo, FilePath = firstPath, GuId = Guid.NewGuid().ToString() });
                ListTemp.AddRange(listVideo);
                var lastNameVideo = cbSelectVideoLast.SelectedItem.ToString();
                var lastPath = txtAddLastVideo.Text + lastNameVideo;
                ListTemp.Add(new VideoModels { FileName = lastNameVideo, FilePath = firstPath, GuId = Guid.NewGuid().ToString() });
                listVideo = ListTemp;

                var outputPath = txtVideoOutput.Text;
                var logoPath = txtLogoPath.Text;

                var mergef = new Util();
                var ffpath = Application.StartupPath + "ffmpeg.exe";
                string newFolder = Guid.NewGuid().ToString();
                //create file cmd
                if (File.Exists("list.txt")) // If file does not exists
                {
                    File.Delete("list.txt");
                }
                File.Create("list.txt").Close();
                using (StreamWriter sw = File.AppendText("list.txt"))
                {
                    foreach (var item in listVideo)
                    {
                        var OutputEncodeVideo = Guid.NewGuid().ToString() + ".mkv";
                        sw.WriteLine("file '" + OutputEncodeVideo + "'");
                        var result = from r in listVideo where r.GuId == item.GuId select r;
                        result.First().TempPath = OutputEncodeVideo;
                        var commandl = " -i \"" + item.FilePath + "\" -r 25 -af apad -vf scale=1280:720 -crf 15.0 -vcodec libx264 -acodec aac -ar 48000 -b:a 192k -coder 1 -rc_lookahead 60 -threads 0 -shortest -avoid_negative_ts make_zero -fflags +genpts \"" + OutputEncodeVideo + "\"";
                        result.First().Commandl = commandl;
                        result.First().Num = listVideo.IndexOf(item) + 1;
                        //_ = await processV2(ffpath, commandl);
                        //this.rtbCommandProcess.Text = commandl;
                    }
                }
                dataGridView1.DataSource = listVideo.Select(p => new { p.Num, p.FilePath, p.FileName, p.TempPath, p.Commandl }).OrderBy(p => p.Num).ToList();
                dataGridView1.Refresh();

                foreach (var item in listVideo)
                {
                    this.rtbCommandProcess.Text = item.Commandl;
                    eventHandled = new TaskCompletionSource<bool>();
                    await processV3(ffpath, item.Commandl);
                }
                string commandMerge = " -f concat -safe 0 -i \"" + Application.StartupPath + "list.txt\" -c copy " + outputPath + Guid.NewGuid().ToString() + "_output.mp4";
                this.rtbCommandProcess.Text = commandMerge;
                await processV3(ffpath, commandMerge);
                RemoveVideoTemp();
            }

            //rtbCommandProcess.Text = result[1];
            //process(result[0], result[1]);
            btnProcess1.Enabled = true;

        }
        private void Timer1_Tick(object Sender, EventArgs e)
        {
            // Set the caption to the current time.  
            //this.rtbResultProcess.Text = DateTime.Now.Second.ToString();

        }
        public bool ValidateInput()
        {
            string message = "Vui lòng chọn :";
            string title = "Thông Báo";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = DialogResult.No;
            if (txtFolderVideo.Text == "")
            {
                result = MessageBox.Show(message + "Danh sách Video", title, buttons);
            }
            else if (cbSelectVideoFirst.SelectedItem == null)
            {
                result = MessageBox.Show(message + "Video Ghép Đầu Tiên", title, buttons);
            }
            else if (cbSelectVideoLast.SelectedItem == null)
            {
                result = MessageBox.Show(message + "Video Ghép Cuối", title, buttons);
            }
            else if (txtVideoOutput.Text == "")
            {
                result = MessageBox.Show(message + "Nơi xuất Video", title, buttons);
            }
            if (result == DialogResult.OK)
            {
                btnProcess1.Enabled = true;
                return false;
            }
            else
            {
                return true;
            }

        }
        private TaskCompletionSource<bool> eventHandled;
        private void RemoveVideoTemp()
        {
            foreach (string sFile in System.IO.Directory.GetFiles(Application.StartupPath, "*.mkv"))
            {
                this.rtbCommandProcess.Text = "Xóa file tạm " + sFile;
                System.IO.File.Delete(sFile);
            }


            //foreach (var item in listVideo)
            //{
            //    this.rtbCommandProcess.Text = "Xóa file tạm " + item.TempPath;
            //    //if (File.Exists(Path.Combine(Application.StartupPath, item.TempPath)))
            //    //{
            //    //    this.rtbCommandProcess.Text = "Xóa file tạm " + item.TempPath;
            //    //    //If file found, delete it
            //    //    File.Delete(Path.Combine(Application.StartupPath, item.TempPath));
            //    //    Thread.Sleep(3000);
            //    //    Console.WriteLine("File deleted.");
            //    //}
            //}
        }
        
        public async Task<bool> processV3(string Path_FFMPEG, string strParam)
        {
            Debug.WriteLine("aaaaaa");
            try
            {
                var ffmpeg = new Process();
                ffmpeg.StartInfo.FileName = Path_FFMPEG;
                ffmpeg.StartInfo.Arguments = strParam;
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.RedirectStandardError = true;
                ffmpeg.StartInfo.RedirectStandardOutput = true;
                ffmpeg.StartInfo.CreateNoWindow = true;
                ffmpeg.OutputDataReceived += myProcess_Exited;
                ffmpeg.ErrorDataReceived += myProcess_Exited;
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
                //ffmpeg.WaitForExit();
                await ffmpeg.WaitForExitAsync().ConfigureAwait(true);
                ffmpeg.Close();
                ffmpeg.Dispose();
                return true;
            }
            catch (Exception ex)
            {

            }

            return true;
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

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            KillAllFFMPEG();
        }

        private async void btnProcess2_Click(object sender, EventArgs e)
        {
            if (listVideo.FirstOrDefault() != null)
            {
                LogoModels.ImagePath = await GetPathRandomImagePath(listVideo.FirstOrDefault().FilePath);
            }

            AddLogo addLogo = new AddLogo();
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
                    ffmpeg.StartInfo.FileName = Application.StartupPath + "ffmpeg.exe"; 
                    ffmpeg.StartInfo.Arguments = rtbCommandProcess.Text = " -i \"" + videoPath + "\" -ss 10 -frames:v 1 \"" + outputPath+"\"";
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
