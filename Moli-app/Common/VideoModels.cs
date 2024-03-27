using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moli_app.Common
{
    public class VideoModels
    {
        public int Num { get; set; }
        public string GuId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string TempPath { get; set; }
        public string Commandl { get; set; }
    }
    public static class LogoModels
    {
        
        public static string Path_Logo { get; set; }
        public static int Scale { get; set; }
        public static PosLogo Pos_Logo { get; set; }
        public static int PosY { get; set; }
        public static int PosX { get; set; }
        public static string ImagePath { get; set; }
        public static Size ResizeKeepAspect(this Size src, int maxWidth, int maxHeight, bool enlarge = false)
        {
            maxWidth = enlarge ? maxWidth : Math.Min(maxWidth, src.Width);
            maxHeight = enlarge ? maxHeight : Math.Min(maxHeight, src.Height);

            decimal rnd = Math.Min(maxWidth / (decimal)src.Width, maxHeight / (decimal)src.Height);
            return new Size((int)Math.Round(src.Width * rnd), (int)Math.Round(src.Height * rnd));
        }
    }
    public class LogoModelsV2
    {
        public LogoModelsV2()
        {
            Path_Logo = "";
            Scale= 1;
            PosX= 0;
            PosY= 0;
            ImagePath= Path_Logo;
            Pos_Logo=PosLogo.Right_Top;
        }
        public  string Path_Logo { get; set; }
        public  int Scale { get; set; }
        public  PosLogo Pos_Logo { get; set; }
        public  int PosY { get; set; }
        public  int PosX { get; set; }
        public  string ImagePath { get; set; }
    }
    public enum PosLogo
    {
        Left_Top = 1,
        Left_Bottom = 2,
        Right_Top = 3,
        Right_Bottom=4
    }
}
