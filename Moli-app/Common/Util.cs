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
        public List<string> AddLogo(string VideoPath="",string LogoPath="")
        {
            List<string> listResult = new List<string>();
            listResult.Add(Application.StartupPath + "ffmpeg.exe");

            return null;
        }
        public List<string> MergeFiles(List<VideoModels> ListVideoPaths, string FirstPath = "", string LastPath = "", string LogoPath = ""
                                        , string OutputPath = "", string Bitrate = "")
        {
            List<string> listResult = new List<string>();


            //Merging two videos               
            String _FirstPath = FirstPath;
            String _LastPath = LastPath;
            //String file = Server.MapPath("~/Videos/input.txt");
            String _OutputPath = OutputPath + Guid.NewGuid() + ".mp4";
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
            commandl += "-fflags +genpts -c copy " + _OutputPath;
                listResult.Add(commandl);

            return listResult;
        }


    }
}
