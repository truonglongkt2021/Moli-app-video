using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Moli_app.Common
{
    public class Util
    {
        //public static OpenDialog()
        //{

        //}
        //public string[] allowedVideoExtensions = new[] { ".mp4", ".mov", ".wmv", ".avi", ".flv", ".MPEG-2", ".MKV" };
        public List<string> AddLogo(string VideoPath = "", string LogoPath = "")
        {
            List<string> listResult = new List<string>();
            listResult.Add(Application.StartupPath + "ffmpeg.exe");

            return null;
        }
        public async Task<bool> ReEncodeVideoAsync(List<VideoModels> videoPaths, string firstVideo = "", string lastVideo = "")
        {
            List<string> listResult = new List<string>();
            var tasks = new List<Task>();
            listResult.Add(Application.StartupPath + "ffmpeg.exe");
            var ffpath = Application.StartupPath + "ffmpeg.exe";
            string newFolder = Guid.NewGuid().ToString();
            System.IO.Directory.CreateDirectory(Application.StartupPath + newFolder);
            //create file cmd
            if (File.Exists("list.txt")) // If file does not exists
            {
                File.Delete("list.txt");
            }
            File.Create("list.txt").Close();
            using (StreamWriter sw = File.AppendText("list.txt"))
            {
                string OutputEncodeVideo = Application.StartupPath + newFolder + "\\0.mp4";
                sw.WriteLine("file '" + OutputEncodeVideo + "'");
                string commandl = " -i \"" + firstVideo + "\" -af apad -vf scale=1280:720 -crf 15.0 " +
                        "-vcodec libx264 -acodec aac -ar 48000 -b:a 192k -coder 1 -rc_lookahead 60 -threads 0 -shortest -avoid_negative_ts make_zero -fflags +genpts " + OutputEncodeVideo;
                

                _ = await process(ffpath, commandl);
                foreach (var item in videoPaths)
                {
                    OutputEncodeVideo = Application.StartupPath + newFolder + "\\" + (videoPaths.IndexOf(item)+1).ToString() + ".mp4";
                    sw.WriteLine("file '" + OutputEncodeVideo + "'");
                    commandl = " -i \"" + item.FilePath + "\" -af apad -vf scale=1280:720 -crf 15.0 " +
                        "-vcodec libx264 -acodec aac -ar 48000 -b:a 192k -coder 1 -rc_lookahead 60 -threads 0 -shortest -avoid_negative_ts make_zero -fflags +genpts " + OutputEncodeVideo;
                    _ =await process(ffpath, commandl);

                }

                OutputEncodeVideo = Application.StartupPath + newFolder + "\\b.mp4";
                sw.WriteLine("file '" + OutputEncodeVideo + "'");
                commandl = " -i \"" + lastVideo + "\" -af apad -vf scale=1280:720 -crf 15.0 " +
                        "-vcodec libx264 -acodec aac -ar 48000 -b:a 192k -coder 1 -rc_lookahead 60 -threads 0 -shortest -avoid_negative_ts make_zero -fflags +genpts " + OutputEncodeVideo;
                _ =await process(ffpath, commandl);
            }

            return true;
        }
        public List<string> MergeFiles(List<VideoModels> ListVideoPaths, string FirstPath = "", string LastPath = "", string LogoPath = ""
                                        , string OutputPath = "", string Bitrate = "")
        {
            List<string> listResult = new List<string>();

            listResult.Add(Application.StartupPath + "ffmpeg.exe");

            //Merging two videos               
            string _FirstPath = FirstPath;
            string _LastPath = LastPath;
            //String file = Server.MapPath("~/Videos/input.txt");
            string _OutputPath = OutputPath + Guid.NewGuid() + ".mkv";
            //create file cmd
            if (File.Exists("list.txt")) // If file does not exists
            {
                File.Delete("list.txt");
            }
            File.Create("list.txt").Close();
            using (StreamWriter sw = File.AppendText("list.txt"))
            {
                sw.WriteLine("file '" + FirstPath + "'");
                if (LogoPath != "")
                {
                    sw.WriteLine("file '" + LogoPath + "'");
                }
                if (ListVideoPaths.Any() && ListVideoPaths.Count > 0)
                {
                    foreach (var item in ListVideoPaths)
                    {
                        sw.WriteLine("file '" + item.FilePath + "'");
                    }
                }
                sw.WriteLine("file '" + LastPath + "'");
            }
            string commandl = " -f concat -safe 0 -i list.txt ";
            if (Bitrate != "")
            {
                commandl += " -b " + Bitrate + "k ";
            }
            if (LogoPath != "")
            {
                commandl += "-filter_complex \"[0]scale = 1280:-2[bg]; [bg][1]overlay = main_w - overlay_w - 10:main_h - overlay_h - 10\" ";
            }
            commandl += "-c:v libx264 -preset medium -crf 18 -fflags +genpts -c copy -shortest -pix_fmt yuv720p " + _OutputPath;
            //commandl += "-c:v libx264 -preset medium -crf 18 -fflags +genpts -c copy -shortest -pix_fmt yuv720p " + _OutputPath;
            listResult.Add(commandl);

            return listResult;
        }
        private TaskCompletionSource<bool> eventHandled;
        public async Task<bool> process(string Path_FFMPEG, string strParam)
        {
            eventHandled = new TaskCompletionSource<bool>();
            try
            {
                using (var ffmpeg = new Process())
                {
                    ffmpeg.StartInfo.FileName = Path_FFMPEG;
                    ffmpeg.StartInfo.Arguments = strParam;
                    ffmpeg.StartInfo.UseShellExecute = false;
                    ffmpeg.StartInfo.RedirectStandardError = true;
                    ffmpeg.StartInfo.RedirectStandardOutput = true;
                    ffmpeg.StartInfo.CreateNoWindow = true;
                    ffmpeg.EnableRaisingEvents = true;
                    ffmpeg.EnableRaisingEvents = true;
                    ffmpeg.Exited += new EventHandler(myProcess_Exited);
                    ffmpeg.Start();
                    //string? processOutput = null;
                    //while ((processOutput = ffmpeg.StandardError.ReadLine()) != null)
                    //{
                    //    // do something with processOutput
                    //    this.rtbResultProcess.Text += processOutput;
                    //}
                    await Task.WhenAll(eventHandled.Task);
                    //ffmpeg.WaitForInputIdle();
                    //ffmpeg.WaitForExit();
                    //ffmpeg.Close();
                    //ffmpeg.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {

            }

            return true;
        }
        // Handle Exited event and display process information.
        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            Console.WriteLine(
                $"Exit time    : \n" +
                $"Exit code    : \n" +
                $"Elapsed time :");
            eventHandled.TrySetResult(true);
        }
    }
}
