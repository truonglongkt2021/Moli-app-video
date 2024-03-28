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
    public class VideoYoutubeShort
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Duration { get; set; }
    }
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
            string ffmpegPath = Path.Combine(Application.StartupPath, "amazingtech.exe");

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

        public static List<MixVideo> MixVideoUtil(List<VideoShort> listVidShort, List<AudioShort> listAudioShort, int totalNumVidOut, TimeSpan durationEachVidSecs, bool addAudio = true)
        {
            var listMixVideos = new List<MixVideo>();
            TimeSpan durationEachVid = TimeSpan.FromMilliseconds(durationEachVidSecs.TotalMilliseconds);
            Random rnd = new Random(); // Đối tượng Random để xáo trộn danh sách

            // Mặc định, sử dụng mỗi AudioShort cho mỗi MixVideo, thay đổi logic này nếu cần
            for (int i = 0; i < totalNumVidOut && i < listAudioShort.Count; i++)
            {
                var mixVideo = new MixVideo();
                // Nếu addAudio là true, thì mới thêm audio vào mixVideo
                if (addAudio && listAudioShort.Any())
                {
                    // Sử dụng mỗi AudioShort cho mỗi MixVideo
                    mixVideo.audioShort = listAudioShort.OrderBy(x => rnd.Next()).FirstOrDefault();
                }
                TimeSpan currentDuration = TimeSpan.Zero;

                // Xáo trộn danh sách VideoShort trước khi chọn để đảm bảo sự ngẫu nhiên
                var shuffledListVidShort = listVidShort.OrderBy(x => rnd.Next()).ToList();

                foreach (var video in shuffledListVidShort)
                {
                    if (currentDuration + video.Duration <= durationEachVid)
                    {
                        mixVideo.listVideo.Add(video);
                        mixVideo.name = mixVideo.name + "_" + listVidShort.IndexOf(video).ToString();
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
        public static void KillAllFFMPEG()
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
        public static async void MergeVideosWithAudio(MixVideo mixVideo, string outputFilePath, bool isHorizontal, bool isMirror, double speed = 1.0)
        {
            StringBuilder filterComplex = new StringBuilder();
            StringBuilder inputFiles = new StringBuilder();
            var ffpath = Path.Combine(Application.StartupPath, "amazingtech.exe");
            int videoIndex = 0;

            // Xác định tỉ lệ màn hình dựa vào isHorizontal
            string scaleFilter = isHorizontal ? "scale=1920:1080" : "scale=1080:1920"; // Ví dụ về tỉ lệ 16:9 cho ngang và 9:16 cho dọc
            string mirrorFilter = isMirror ? "hflip, " : ""; // Thêm hflip nếu isMirror là true
                                                             // Tính toán các tham số cho bộ lọc setpts và atempo dựa trên tốc độ
            string setptsFilter = $"setpts={1 / speed}*PTS";
            string atempoFilter = speed >= 0.5 && speed <= 2.0 ? $"atempo={speed}" : "";

            foreach (var video in mixVideo.listVideo)
            {
                inputFiles.Append($"-i \"{video.FullPath}\" ");
                // Thêm điều chỉnh tỉ lệ màn hình vào filter_complex
                filterComplex.Append($"[{videoIndex}:v:0] {mirrorFilter}{setptsFilter}, {scaleFilter} [scaled{videoIndex}]; ");
                videoIndex++;
            }

            // Tạo phần concat trong filter_complex
            for (int i = 0; i < videoIndex; i++)
            {
                filterComplex.Append($"[scaled{i}] ");
            }
            filterComplex.Append($"concat=n={videoIndex}:v=1:a=0 [v]; ");


            // Thêm audio vào danh sách input và thiết lập atrim
            //inputFiles.Append($"-i \"{mixVideo.audioShort.FullPath}\" ");
            // Kiểm tra xem có audio không và thêm vào nếu có
            double adjustedSpeed = Math.Max(0.5, Math.Min(speed, 2.0)); // Giữ speed trong khoảng cho phép
            if (mixVideo.audioShort != null && !string.IsNullOrEmpty(mixVideo.audioShort.FullPath))
            {
                inputFiles.Append($"-i \"{mixVideo.audioShort.FullPath}\" ");
                // Sử dụng bộ lọc aloop để lặp audio, lặp vô hạn (loop=-1)
                filterComplex.Append($"[{videoIndex}:a:0] aloop=loop=-1:size=2e+09, atempo={adjustedSpeed}, atrim=0:{TotalVideoDuration(mixVideo)} [aout];");
            }
            else
            {
                // Điều chỉnh tốc độ cho mỗi luồng âm thanh từ video gốc và sau đó ghép chúng lại
                for (int i = 0; i < videoIndex; i++)
                {
                    // Lặp lại bộ lọc atempo nếu cần thiết để đạt được tốc độ mong muốn
                    filterComplex.Append($"[{i}:a:0] atempo={adjustedSpeed} [audio{i}]; ");
                }

                // Ghép các luồng âm thanh đã được điều chỉnh
                for (int i = 0; i < videoIndex; i++)
                {
                    filterComplex.Append($"[audio{i}] ");
                }
                filterComplex.Append($"concat=n={videoIndex}:v=0:a=1 [aout];");
            }

            string ffmpegArgs = $"{inputFiles} -filter_complex \"{filterComplex}\" -map \"[v]\" -map \"[aout]\" \"{outputFilePath}\\{Guid.NewGuid().ToString()}{mixVideo.name}.mp4\"";

            using (var process = new Process())
            {
                process.StartInfo.FileName = ffpath;
                process.StartInfo.Arguments = ffmpegArgs;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string stderr = process.StandardError.ReadToEnd();
               await process.WaitForExitAsync();
            }
        }
        public static async Task ExportAudiosFromVideosAsync(string sourceVideoPathFolder, string outputFolderPath, bool isTreCon, bool isNguoiLon, bool isNormal)
        {
            var videoFiles = Directory.GetFiles(sourceVideoPathFolder, "*.mp4"); // Lấy tất cả file .mp4
            var ffpath = Path.Combine(Application.StartupPath, "amazingtech.exe");
            foreach (var videoFile in videoFiles)
            {
                string outputFileName = Path.GetFileNameWithoutExtension(videoFile) + ".mp3"; // Tên file output
                string outputFilePath = Path.Combine(outputFolderPath, outputFileName);

                // Xác định tần số mẫu dựa vào giọng đọc
                string audioFilter = "";
                if (!isNormal)
                {
                    audioFilter = isTreCon ? "asetrate=44100*1.5,atempo=0.6667" : (isNguoiLon ? "asetrate=44100*0.8,atempo=1.25" : "");
                }

                string ffmpegArgs = $"-i \"{videoFile}\" -vn -af \"{audioFilter}\" \"{outputFilePath}\"";

                using (var process = new Process())
                {
                    process.StartInfo.FileName = ffpath;
                    process.StartInfo.Arguments = ffmpegArgs;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    string stderr = process.StandardError.ReadToEnd();
                    await process.WaitForExitAsync();
                }
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
            listResult.Add(Application.StartupPath + "amazingtech.exe");
            var ffpath = Application.StartupPath + "amazingtech.exe";
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

            listResult.Add(Application.StartupPath + "amazingtech.exe");

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
