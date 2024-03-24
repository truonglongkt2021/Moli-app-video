using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MediaInfo;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Moli_app.Common
{
    public class VideoShort
    {
        public VideoShort()
        {
            FileName = string.Empty;
            FullPath = string.Empty;
            Duration = new TimeSpan();
        }
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public TimeSpan Duration { get; set; }
    }
    public class AudioShort
    {
        public AudioShort()
        {
            FileName = string.Empty;
            FullPath = string.Empty;
            Duration = new TimeSpan();

        }
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public TimeSpan Duration { get; set; }

    }
    public class MixVideo
    {
        public MixVideo()
        {
            listVideo = new List<VideoShort>();
            audioShort = new AudioShort();
            name = "";

        }
        public List<VideoShort> listVideo { get; set; }
        public AudioShort audioShort { get; set; }
        public string? name { get; set; }

    }
    public class Util
    {
        //public static OpenDialog()
        //{

        //}
        //public string[] allowedVideoExtensions = new[] { ".mp4", ".mov", ".wmv", ".avi", ".flv", ".MPEG-2", ".MKV" };
        public static TimeSpan GetMediaDurationWithFFmpeg(string filePath)
        {
            // Đường dẫn tới ffmpeg, thay đổi nếu cần
            string ffmpegPath = Path.Combine(Application.StartupPath, "ffmpeg.exe");

            // Tạo và cấu hình ProcessStartInfo
            var processStartInfo = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = $"-i \"{filePath}\"",
                UseShellExecute = false,
                RedirectStandardError = true, // FFmpeg ghi thông tin lỗi và thông tin tệp ra stderr
                CreateNoWindow = true
            };

            // Tạo và bắt đầu process
            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.Start();

                // Đọc thông tin từ stderr
                string output = process.StandardError.ReadToEnd();
                process.WaitForExit();

                // Regex để tìm thời lượng trong đầu ra
                var regex = new Regex(@"Duration: (\d{2}):(\d{2}):(\d{2})\.(\d{2})");
                var match = regex.Match(output);

                if (match.Success)
                {
                    // Chuyển thời lượng tìm được sang TimeSpan
                    int hours = int.Parse(match.Groups[1].Value);
                    int minutes = int.Parse(match.Groups[2].Value);
                    int seconds = int.Parse(match.Groups[3].Value);
                    int milliseconds = int.Parse(match.Groups[4].Value) * 10; // Chuyển 2 số cuối cùng sang milliseconds

                    return new TimeSpan(0, hours, minutes, seconds, milliseconds);
                }
                else
                {
                    throw new Exception("Không thể phân tích thời lượng từ FFmpeg.");
                }
            }
        }

        public static List<MixVideo> MixVideoUtil(List<VideoShort> listVidShort, List<AudioShort> listAudioShort, int totalNumVidOut, TimeSpan durationEachVidSecs)
        {
            var listMixVideos = new List<MixVideo>();
            TimeSpan durationEachVid = TimeSpan.FromMilliseconds(durationEachVidSecs.TotalMilliseconds);
            Random rnd = new Random(); // Đối tượng Random để xáo trộn danh sách

            // Mặc định, sử dụng mỗi AudioShort cho mỗi MixVideo, thay đổi logic này nếu cần
            for (int i = 0; i < totalNumVidOut && i < listAudioShort.Count; i++)
            {
                var mixVideo = new MixVideo();
                mixVideo.audioShort = listAudioShort.OrderBy(x => rnd.Next()).ToList()[i];

                TimeSpan currentDuration = TimeSpan.Zero;

                // Xáo trộn danh sách VideoShort trước khi chọn để đảm bảo sự ngẫu nhiên
                var shuffledListVidShort = listVidShort.OrderBy(x => rnd.Next()).ToList();

                foreach (var video in shuffledListVidShort)
                {
                    if (currentDuration + video.Duration <= durationEachVid)
                    {
                        mixVideo.listVideo.Add(video);
                        mixVideo.name = mixVideo.name+"_"+ listVidShort.IndexOf(video).ToString();
                        currentDuration += video.Duration;
                    }

                    if (currentDuration >= durationEachVid)
                    {
                        break;
                    }
                }

                // Cập nhật lại listVidShort bằng cách loại bỏ các VideoShort đã được sử dụng
                //listVidShort = listVidShort.Except(mixVideo.listVideo).ToList();

                listMixVideos.Add(mixVideo);
            }

            return listMixVideos;
        }

        public static void MergeVideosWithAudio(MixVideo mixVideo, string outputFilePath)
        {
            StringBuilder filterComplex = new StringBuilder();
            StringBuilder inputFiles = new StringBuilder();
            var ffpath = Path.Combine(Application.StartupPath, "ffmpeg.exe");
            int videoIndex = 0;

            // Thêm các video vào danh sách input
            foreach (var video in mixVideo.listVideo)
            {
                inputFiles.Append($"-i \"{video.FullPath}\" ");
                // Chỉ thêm stream video vào filter_complex, bỏ qua stream audio của video
                filterComplex.Append($"[{videoIndex}:v:0] ");
                videoIndex++;
            }

            // Thêm audio vào danh sách input
            inputFiles.Append($"-i \"{mixVideo.audioShort.FullPath}\" ");
            // Sử dụng filter_complex để ghép các video (không có âm thanh) và sau đó thêm audio
            // Cắt audio sao cho bằng với tổng thời gian của video
            filterComplex.Append($"concat=n={videoIndex}:v=1:a=0 [v]; ");
            filterComplex.Append($"[{videoIndex}:a:0] atrim=0:{TotalVideoDuration(mixVideo)} [aout]");

            string ffmpegArgs = $"{inputFiles} -filter_complex \"{filterComplex}\" -map \"[v]\" -map \"[aout]\" \"{outputFilePath}\\{Guid.NewGuid().ToString()}{mixVideo.name}.mp4\"";

            // Khởi chạy FFmpeg với các tham số đã được xây dựng
            using (var process = new Process())
            {
                process.StartInfo.FileName = ffpath;
                process.StartInfo.Arguments = ffmpegArgs;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                // Đọc output để debug nếu cần
                string stderr = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
        }

        // Hàm để tính tổng thời gian của các video
        public static double TotalVideoDuration(MixVideo mixVideo)
        {
            TimeSpan totalDuration = new TimeSpan();
            foreach (var video in mixVideo.listVideo)
            {
                totalDuration += video.Duration;
            }
            return totalDuration.TotalSeconds;
        }

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
                    OutputEncodeVideo = Application.StartupPath + newFolder + "\\" + (videoPaths.IndexOf(item) + 1).ToString() + ".mp4";
                    sw.WriteLine("file '" + OutputEncodeVideo + "'");
                    commandl = " -i \"" + item.FilePath + "\" -af apad -vf scale=1280:720 -crf 15.0 " +
                        "-vcodec libx264 -acodec aac -ar 48000 -b:a 192k -coder 1 -rc_lookahead 60 -threads 0 -shortest -avoid_negative_ts make_zero -fflags +genpts " + OutputEncodeVideo;
                    _ = await process(ffpath, commandl);

                }

                OutputEncodeVideo = Application.StartupPath + newFolder + "\\b.mp4";
                sw.WriteLine("file '" + OutputEncodeVideo + "'");
                commandl = " -i \"" + lastVideo + "\" -af apad -vf scale=1280:720 -crf 15.0 " +
                        "-vcodec libx264 -acodec aac -ar 48000 -b:a 192k -coder 1 -rc_lookahead 60 -threads 0 -shortest -avoid_negative_ts make_zero -fflags +genpts " + OutputEncodeVideo;
                _ = await process(ffpath, commandl);
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
