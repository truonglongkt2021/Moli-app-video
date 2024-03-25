using Moli_app.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Moli_app
{
    public partial class SearchVideoShort : Form
    {
        public static List<VideoYoutubeShort> listYoutubeShort = new List<VideoYoutubeShort>();
        public SearchVideoShort()
        {
            InitializeComponent();
            dgvListyoutube.Columns.Clear();

            dgvListyoutube.Columns.Add("Title", "Title");

            var thumbnailColumn = new DataGridViewImageColumn()
            {
                HeaderText = "Thumbnail",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Name = "Thumbnail" // Đặt tên cho cột để có thể tham chiếu đến nó sau này
            };
            dgvListyoutube.Columns.Add(thumbnailColumn);

            dgvListyoutube.Columns.Add("VideoUrl", "Link");

            dgvListyoutube.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private readonly object writeLock = new object();
        private Image LoadImageFromUrl(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(url);
                    using (var memStream = new MemoryStream(imageData))
                    {
                        return Image.FromStream(memStream);
                    }
                }
            }
            catch
            {
                // Trả về hình ảnh mặc định hoặc null nếu không thể tải hình ảnh
                return null;
            }
        }
        private void DisplayVideosInDataGridView(List<VideoYoutubeShort> videosList)
        {
            dgvListyoutube.Rows.Clear();

            foreach (var video in videosList)
            {
                int rowIndex = dgvListyoutube.Rows.Add();
                var row = dgvListyoutube.Rows[rowIndex];

                row.Cells["Title"].Value = video.Title;
                row.Cells["Thumbnail"].Value = LoadImageFromUrl(video.ImageUrl);
                row.Cells["VideoUrl"].Value = video.VideoUrl;
            }
        }
        private async void btnSearchYoutube_Click(object sender, EventArgs e)
        {
            btnSearchYoutube.Enabled = false;
            string searchKeyword = txtKeyword.Text; // Lấy từ khóa từ textbox
            string countryCode = txtCountry.Text;
            var youtubedl = Path.Combine(Application.StartupPath, "yt-dlp.exe");

            // Tạo danh sách VideoYoutubeShort để chứa kết quả
            var videosList = new List<VideoYoutubeShort>();

            var youtubeDl = new Process();
            //var args = $"ytsearch10:{searchKeyword} --get-id --get-title --get-duration --get-thumbnail --skip-download --dump-single-json -J";
            var args = $"ytsearch10:short{searchKeyword} --match-title \"#shorts\" --geo-bypass-country {countryCode} --skip-download --dump-single-json";

            try
            {
                youtubeDl.StartInfo.FileName = youtubedl; // Đảm bảo yt-dlp có thể được gọi từ dòng lệnh
                youtubeDl.StartInfo.Arguments = args;
                youtubeDl.StartInfo.UseShellExecute = false;
                youtubeDl.StartInfo.RedirectStandardOutput = true;
                youtubeDl.StartInfo.CreateNoWindow = true;

                youtubeDl.Start();

                // Đọc dữ liệu JSON từ đầu ra chuẩn
                string output = await youtubeDl.StandardOutput.ReadToEndAsync();
                youtubeDl.WaitForExit();

                // Phân tích dữ liệu JSON thành danh sách VideoYoutubeShort
                dynamic videoData = JsonConvert.DeserializeObject<dynamic>(output.TrimEnd(new char[] { ' ', '\n', '\r' }).ToString())["entries"];
                foreach (var video in videoData)
                {
                    videosList.Add(new VideoYoutubeShort
                    {
                        Name = video.uploader,
                        Title = video.title,
                        ImageUrl = video.thumbnail,
                        VideoUrl = $"https://www.youtube.com/watch?v={video.id}",
                        Duration = video.duration // Giả sử bạn đã thêm thuộc tính Duration vào lớp VideoYoutubeShort
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                youtubeDl.Close();
                youtubeDl.Dispose();
                btnSearchYoutube.Enabled = true;
            }
            DisplayVideosInDataGridView(videosList);
            // Sử dụng videosList tại đây, ví dụ: hiển thị lên giao diện người dùng
        }

    }
}
