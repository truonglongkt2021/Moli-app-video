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
        public static int MinuteRemain = 0;
        public static canvaform MainForm { get; set; }
        public static int MinuteUsed = 0;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi tạo canvaform trước và giữ nó như MainForm

            var obj = await ApiHelper.CheckActivate();
            if (obj != null)
            {
                MinuteUsed = obj.NumberMin;
                MinuteRemain = obj.NumberMin - obj.NumberUsed;
                // Chỉ cần chạy MainForm (canvaform) nếu số phút còn lại > 0
            }
            Application.Run(new canvaform());
        }
    }
}
