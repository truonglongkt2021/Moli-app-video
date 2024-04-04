using Moli_app.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moli_app
{
    internal static class Program
    {
        public static double MinuteRemain = 0;
        public static canvaform MainForm { get; set; }
        public static double MinuteUsed = 0;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.SetHighDpiMode(HighDpiMode.SystemAware);
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);

        //    // Khởi tạo canvaform trước và giữ nó như MainForm

        //    var obj = ApiHelper.CheckActivate().GetAwaiter().GetResult(); ;
        //    if (obj != null)
        //    {
        //        MinuteUsed = obj.NumberMin;
        //        MinuteRemain = obj.NumberMin - obj.NumberUsed;
        //        // Chỉ cần chạy MainForm (canvaform) nếu số phút còn lại > 0
        //    }
        //    Application.Run(new canvaform());
        //}

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi tạo canvaform trước và giữ nó như MainForm

            Application.Run(new AdminForm());
        }
    }
}
