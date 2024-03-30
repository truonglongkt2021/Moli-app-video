using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Sử dụng Json.NET để serialize dữ liệu

namespace Moli_app.Common
{
    public static class ApiHelper
    {
        public static async Task<string> PostDataAsync(string url, string productKey)
        {
            var (macAddress, hardDriveSerial, pcName) = SystemInfoHelper.GetSystemInfo();
            using (var client = new HttpClient())
            {
                // Tạo đối tượng dữ liệu để gửi
                var data = new
                {
                    ProductKey = productKey,
                    PCName = pcName,
                    MacAddress = macAddress,
                    HardDriveSerial = hardDriveSerial
                };

                // Serialize đối tượng dữ liệu thành chuỗi JSON
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Thực hiện gọi POST
                    var response = await client.PostAsync(url, content);

                    // Đọc và trả về kết quả
                    return await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    return $"Error: {ex.Message}";
                }
            }
        }
        public static async Task<ActivationResponse> CheckActivate()
        {
            var (macAddress, hardDriveSerial, pcName) = SystemInfoHelper.GetSystemInfo();
            var productKey = SystemInfoHelper.getProductKey(); // Giả sử bạn đã có hàm GetProductKey()
            var url = "http://your-api-url/check"; // Thay đổi url phù hợp với API endpoint của bạn
            var privateKey = "881e4380-299e-4165-9bc9-4409f52b676f";

            var data = new
            {
                ProductKey = productKey,
                PCName = pcName,
                MacAddress = macAddress,
                HardDriveSerial = hardDriveSerial
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, privateKey);

            using (var client = new HttpClient())
            {
                json = JsonConvert.SerializeObject(new { data = data, Hash = hashMac });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var activationResponse = JsonConvert.DeserializeObject<ActivationResponse>(responseString);
                        return activationResponse; // Trả về đối tượng đã được parse
                    }
                    else
                    {
                        // Xử lý trường hợp response không thành công
                        return new ActivationResponse { IsActive = false };
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    return new ActivationResponse { IsActive = false }; // Hoặc bạn có thể thêm thông tin lỗi vào model nếu cần
                }
            }
        }
        public static async Task<ActivationResponse> UsedMinute(int minuteUsed)
        {
            var (macAddress, hardDriveSerial, pcName) = SystemInfoHelper.GetSystemInfo();
            var productKey = SystemInfoHelper.getProductKey(); // Giả sử bạn đã có hàm GetProductKey()
            var url = "http://your-api-url/check"; // Thay đổi url phù hợp với API endpoint của bạn
            var privateKey = "881e4380-299e-4165-9bc9-4409f52b676f";

            var data = new
            {
                ProductKey = productKey,
                PCName = pcName,
                MacAddress = macAddress,
                HardDriveSerial = hardDriveSerial,
                MinuteUsed = minuteUsed,
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, privateKey);

            using (var client = new HttpClient())
            {
                json = JsonConvert.SerializeObject(new { data = data, Hash = hashMac });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var activationResponse = JsonConvert.DeserializeObject<ActivationResponse>(responseString);
                        if (activationResponse != null)
                        {
                            Program.MinuteUsed = activationResponse.NumberUsed;
                            Program.MinuteRemain = activationResponse.NumberMin - activationResponse.NumberUsed;
                        }
                        return activationResponse; // Trả về đối tượng đã được parse
                    }
                    else
                    {
                        // Xử lý trường hợp response không thành công
                        return new ActivationResponse { IsActive = false };
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    return new ActivationResponse { IsActive = false }; // Hoặc bạn có thể thêm thông tin lỗi vào model nếu cần
                }
            }
        }
        public static string CreateHmacSha256Signature(string data, string key)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hash);
            }
        }
    }
    public class ActivationResponse
    {
        public ActivationResponse()
        {
            IsActive = false;
            NumberMin = 0;
            NumberUsed = 0;
        }
        public bool IsActive { get; set; }
        public int NumberMin { get; set; }
        public int NumberUsed { get; set; }
    }
}
