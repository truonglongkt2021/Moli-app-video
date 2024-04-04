using Moli_app.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            // Đặt vị trí xuất hiện của form ở chính giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
            // Cố định kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Hoặc FixedDialog, Fixed3D
            this.MaximizeBox = false; // Ngăn không cho phóng to Form

            // Cố định kích thước bằng cách đặt giới hạn kích thước tối thiểu và tối đa
            this.MinimumSize = this.Size; // Hoặc thiết lập một giá trị cụ thể
            this.MaximumSize = this.Size; // Giữ giá trị giống nhau để cố định kích thước
            dgvListyoutube.Columns.Clear();

            dgvListyoutube.Columns.Add("Title", "Title");

            var thumbnailColumn = new DataGridViewImageColumn()
            {
                HeaderText = "Thumbnail",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Name = "Thumbnail", // Đặt tên cho cột để có thể tham chiếu đến nó sau này
                Width = 150, // Thiết lập chiều rộng cho cột, bạn có thể thay đổi giá trị này theo yêu cầu
                MinimumWidth = 100 // Đặt chiều rộng tối thiểu cho cột để đảm bảo nó không bị quá nhỏ
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
            DisableAllButtons(this, false);
            var fromdate = "";
            var todate = "";
            try
            {

                if (!String.IsNullOrEmpty(txtFromDate.Text))
                {
                    fromdate = DateTime.ParseExact(txtFromDate.Text, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyyMMdd");
                }
                if (!String.IsNullOrEmpty(txtToDate.Text))
                {
                    todate = DateTime.ParseExact(txtToDate.Text, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyyMMdd");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ngày tháng năm không đúng Định dạng yyyyMMdd (ví dụ 29/03/2024 => 20240329)");
            }
            var isShort = cbShortVideo.Checked;
            string searchKeyword = Util.RemoveDiacritics(txtKeyword.Text); // Lấy từ khóa từ textbox
            string searchchannelName = txtKeyword.Text; // Lấy từ khóa từ textbox
            string countryCode = !string.IsNullOrEmpty(txtCountry.Text) ? $"--geo-bypass-country {txtCountry.Text}" : "";
            string numVideo = string.IsNullOrEmpty(txtNumVideo.Text) ? "10" : txtNumVideo.Text;
            var youtubedl = Path.Combine(Application.StartupPath, "amazing-youtube.exe");

            // Tạo danh sách VideoYoutubeShort để chứa kết quả
            var videosList = new List<VideoYoutubeShort>();

            var youtubeDl = new Process();
            var argsKeyword = cbShortVideo.Checked ? $"\"https://www.youtube.com/results?search_query={searchKeyword}\" --match-filter \"duration <= 60\" --get-id --skip-download --max-downloads {numVideo} --dump-single-json"
                                                   : $"\"https://www.youtube.com/results?search_query={searchKeyword}\" --get-id --skip-download --max-downloads {numVideo} --dump-single-json";


            if (cbISChannelName.Checked)
            {
                argsKeyword = cbShortVideo.Checked ? $"\"https://www.youtube.com/@{searchchannelName}/shorts\" --get-id --skip-download --max-downloads {numVideo} --dump-single-json"
                                                   : $"\"https://www.youtube.com/@{searchchannelName}\" --get-id --skip-download --max-downloads {numVideo} --dump-single-json";
            }
            //if (!string.IsNullOrEmpty(fromdate))
            //{
            //    argsKeyword += $" --dateafter {fromdate}";
            //}

            //if (!string.IsNullOrEmpty(todate))
            //{
            //    argsKeyword += $" --datebefore {todate}";
            //}

            try
            {
                youtubeDl.StartInfo.FileName = youtubedl;
                youtubeDl.StartInfo.Arguments = $"{countryCode} {argsKeyword}";
                youtubeDl.StartInfo.UseShellExecute = false;
                youtubeDl.StartInfo.RedirectStandardOutput = true;
                youtubeDl.StartInfo.CreateNoWindow = true;

                youtubeDl.Start();

                // Đọc dữ liệu JSON từ đầu ra chuẩn
                string output = await youtubeDl.StandardOutput.ReadToEndAsync();
                await youtubeDl.WaitForExitAsync();

                // Loại bỏ dữ liệu không mong muốn ở cuối chuỗi, nếu có
                // Ví dụ: loại bỏ dòng "null" hoặc bất kỳ ký tự không cần thiết nào ở cuối
                string trimmedOutput = output.TrimEnd(new char[] { ' ', '\n', '\r', '\0' });

                // Cố gắng loại bỏ bất kỳ dòng không cần thiết nào ở cuối chuỗi output
                if (trimmedOutput.EndsWith("null"))
                {
                    trimmedOutput = trimmedOutput.Substring(0, trimmedOutput.LastIndexOf("\n")).TrimEnd();
                }
                // Phân tích dữ liệu JSON thành danh sách VideoYoutubeShort
                dynamic videodata = null;
                if (cbISChannelName.Checked)
                {
                    videodata = trimmedOutput.Split("\n");
                    foreach (var item in videodata)
                    {
                        videosList.Add(new VideoYoutubeShort
                        {
                            Name = item,
                            Title = item,
                            ImageUrl = $"https://i.ytimg.com/vi_webp/{item}/1.webp",
                            VideoUrl = cbShortVideo.Checked ? $"https://www.youtube.com/shorts/{item}" : $"https://www.youtube.com/watch?v={item}",
                            Duration = item // Giả sử bạn đã thêm thuộc tính Duration vào lớp VideoYoutubeShort
                        });
                    }
                }
                else
                {
                    videodata = trimmedOutput.Split("\n");
                    foreach (var item in videodata)
                    {
                        videosList.Add(new VideoYoutubeShort
                        {
                            Name = item,
                            Title = item,
                            ImageUrl = $"https://i.ytimg.com/vi_webp/{item}/1.webp",
                            VideoUrl = cbShortVideo.Checked ? $"https://www.youtube.com/shorts/{item}" : $"https://www.youtube.com/watch?v={item}",
                            Duration = item // Giả sử bạn đã thêm thuộc tính Duration vào lớp VideoYoutubeShort
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                DisableAllButtons(this, true);
            }
            finally
            {
                youtubeDl.Close();
                youtubeDl.Dispose();
                DisableAllButtons(this, true);
            }

            listYoutubeShort = videosList;
            DisplayVideosInDataGridView(videosList);
            // Sử dụng videosList tại đây, ví dụ: hiển thị lên giao diện người dùng
        }

        private void btnSelectPathDownload_Click(object sender, EventArgs e)
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
                    txtPathDownload.Text = selectedFolderPath;
                }
            }
        }
        private void DisableAllButtons(Control parent, bool enablebutton = false)
        {
            foreach (Control c in parent.Controls)
            {
                // Nếu control là Button, vô hiệu hóa nó
                if (c is Button)
                {
                    ((Button)c).Enabled = enablebutton;
                }

                // Nếu control chứa các control khác (ví dụ: Panel, GroupBox,...), kiểm tra chúng một cách đệ quy
                if (c.HasChildren)
                {
                    DisableAllButtons(c, enablebutton);
                }
            }
        }
        private async void btnDownload_Click(object sender, EventArgs e)
        {
            DisableAllButtons(this, false);
            rtbResult.Text = "";
            int count = 0;
            btnDownload.Enabled = false;
            var youtubedl = Path.Combine(Application.StartupPath, "amazing-youtube.exe");
            var pathOutPut = txtPathDownload.Text;
            rtbResult.Text = "Đang tải video ....";
            foreach (var video in listYoutubeShort)
            {
                count++;
                try
                {
                    using (Process youtubeDlProcess = new Process())
                    {
                        // Cài đặt Process để gọi youtube-dl
                        youtubeDlProcess.StartInfo.FileName = youtubedl; // Đường dẫn tới youtube-dl
                        youtubeDlProcess.StartInfo.Arguments = $"{video.VideoUrl} -o \"{pathOutPut}\\{txtKeyword.Text}_{Guid.NewGuid().ToString()}.%(ext)s\"";
                        youtubeDlProcess.StartInfo.UseShellExecute = false;
                        youtubeDlProcess.StartInfo.RedirectStandardOutput = true;
                        youtubeDlProcess.StartInfo.RedirectStandardError = true;
                        youtubeDlProcess.StartInfo.CreateNoWindow = true;

                        youtubeDlProcess.Start();
                        string output = youtubeDlProcess.StandardOutput.ReadToEnd();
                        string error = youtubeDlProcess.StandardError.ReadToEnd();

                        await youtubeDlProcess.WaitForExitAsync();

                        // Cập nhật rtbResult từ thread UI
                        this.Invoke(new Action(() =>
                        {
                            if (!string.IsNullOrEmpty(error))
                            {
                                rtbResult.AppendText($"Error downloading video {video.Title}: {error}");
                            }
                            else
                            {
                                rtbResult.AppendText($"Downloaded video {video.Title} successfully.");
                            }
                            // Đảm bảo con trỏ ở cuối văn bản để cuộn đến vị trí đó
                            rtbResult.SelectionStart = rtbResult.Text.Length;
                            rtbResult.ScrollToCaret();
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while downloading video {video.Title}: {ex.Message}");
                }
                //rtbResult.Text = "Đã tải " + count.ToString() + "/" + listYoutubeShort.Count().ToString();
            }
            DisableAllButtons(this, true);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự được nhập có phải là số hoặc phím điều khiển (như Backspace) không
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự đó được nhập vào TextBox
            }
        }

        private void SearchVideoShort_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtbResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
