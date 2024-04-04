using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // Sử dụng Json.NET để serialize dữ liệu
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Moli_app.Common
{
    public static class ApiHelper
    {
        private static string _APIURL = "https://api-avid.amazingtech.vn/api";
        private static string _PRIVATEKEY = "881e4380-299e-4165-9bc9-4409f52b676f";
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
            var url = _APIURL + "/subvid/getsub"; // Thay đổi url phù hợp với API endpoint của bạn

            var data = new
            {
                ProductKey = productKey,
                PCName = pcName,
                MacAddress = macAddress,
                HardDriveSerial = hardDriveSerial
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, _PRIVATEKEY);

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
                            Program.MinuteUsed = (int)activationResponse.NumberUsed;
                            Program.MinuteRemain = (int)(activationResponse.NumberMin - activationResponse.NumberUsed);
                            return activationResponse; // Trả về đối tượng đã được parse
                        }
                        else
                        {
                            Program.MinuteUsed = 0;
                            Program.MinuteRemain = 0;
                            return new ActivationResponse { IsActive = false };
                        }
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

        public static async Task<ModResponse> GetMod(string Pincode)
        {
            var url = _APIURL + "/Mods/getbyPayingCode"; // Thay đổi url phù hợp với API endpoint của bạn

            var data = new
            {
                pinCode = Pincode
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, _PRIVATEKEY);

            using (var client = new HttpClient())
            {
                json = JsonConvert.SerializeObject(new
                {
                    data = data,
                    Hash = hashMac
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var activationResponse = JsonConvert.DeserializeObject<ModResponse>(responseString);
                        if (activationResponse != null)
                        {
                            activationResponse.IsActive = true;
                            return activationResponse; // Trả về đối tượng đã được parse
                        }
                        else
                        {
                            return new ModResponse { IsActive = false };
                        }
                    }
                    else
                    {
                        // Xử lý trường hợp response không thành công
                        return new ModResponse { IsActive = false };
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    return new ModResponse { IsActive = false }; // Hoặc bạn có thể thêm thông tin lỗi vào model nếu cần
                }
            }
        }

        public static async Task<InfoResponse> CheckInfoByEmailorProductKey(string Key, string email = "", string productKey = "")
        {
            var url = _APIURL + "/binh-minh/checkInfo"; // Thay đổi url phù hợp với API endpoint của bạn

            var data = new
            {
                Key = Key,
                ProductKey = productKey,
                email = email,
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, _PRIVATEKEY);

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
                        var activationResponse = JsonConvert.DeserializeObject<InfoResponse>(responseString);
                        if (activationResponse != null)
                        {
                            return activationResponse; // Trả về đối tượng đã được parse
                        }
                        else
                        {
                            return new InfoResponse { IsActive = false };
                        }
                    }
                    else
                    {
                        // Xử lý trường hợp response không thành công
                        return new InfoResponse { IsActive = false };
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    return new InfoResponse { IsActive = false }; // Hoặc bạn có thể thêm thông tin lỗi vào model nếu cần
                }
            }
        }
        public static async Task<IncomeModel> CheckIncome(string pinCode)
        {
            var url = _APIURL + "/binh-minh/totalIncome"; // Thay đổi url phù hợp với API endpoint của bạn

            var data = new
            {
                pinCode = pinCode
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, _PRIVATEKEY);

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
                        var activationResponse = JsonConvert.DeserializeObject<IncomeModel>(responseString);
                        if (activationResponse != null)
                        {
                            activationResponse.IsActive = true;
                            return activationResponse; // Trả về đối tượng đã được parse
                        }
                        else
                        {
                            return new IncomeModel();
                        }
                    }
                    else
                    {
                        // Xử lý trường hợp response không thành công
                        return new IncomeModel();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    return new IncomeModel(); // Hoặc bạn có thể thêm thông tin lỗi vào model nếu cần
                }
            }
        }
        public static async Task<bool> Addtrans(string key = "", string email = "", double price = 0, string transid = "")
        {
            var url = _APIURL + "/binh-minh/addtrans"; // Thay đổi url phù hợp với API endpoint của bạn

            var data = new
            {
                Key = key,
                email = email,
                price = int.Parse(price.ToString()),
                transid = transid
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, _PRIVATEKEY);

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
                        return true;
                    }
                    else
                    {
                        // Xử lý trường hợp response không thành công
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    return false; // Hoặc bạn có thể thêm thông tin lỗi vào model nếu cần
                }
            }
        }
        public static async Task<ActivationResponse> ConfirmPayment(string message,string email)
        {
            var productKey = SystemInfoHelper.getProductKey(); // Giả sử bạn đã có hàm GetProductKey()
            var url = _APIURL + "/subvid/confirmPayment"; // Thay đổi url phù hợp với API endpoint của bạn

            var data = new
            {
                ProductKey = productKey,
                MessagePayment = message,
                email=email
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, _PRIVATEKEY);

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
                        return new ActivationResponse { IsActive = true };
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
        public static async Task<ActivationResponse> CreateUser(string FullName, string PhoneNumber, string email)
        {
            var (macAddress, hardDriveSerial, pcName) = SystemInfoHelper.GetSystemInfo();
            var url = _APIURL + "/subvid"; // Thay đổi url phù hợp với API endpoint của bạn

            var data = new
            {
                FullName = FullName,
                PhoneNumber = PhoneNumber,
                email = email,
                PCName = pcName,
                MacAddress = macAddress,
                HardDriveSerial = hardDriveSerial
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, _PRIVATEKEY);

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
        public static async Task<ActivationResponse> ReCreateProductKey(string email)
        {
            var (macAddress, hardDriveSerial, pcName) = SystemInfoHelper.GetSystemInfo();
            var url = _APIURL + "/subvid/reproductkey"; // Thay đổi url phù hợp với API endpoint của bạn
            DateTimeOffset now = DateTimeOffset.Now;
            long unixTimestamp = now.ToUnixTimeSeconds();
            var data = new
            {
                email = email,
                PCName = pcName,
                MacAddress = macAddress,
                HardDriveSerial = hardDriveSerial,
                TimeStamp = unixTimestamp.ToString()
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, _PRIVATEKEY);

            using (var client = new HttpClient())
            {
                json = JsonConvert.SerializeObject(new { data = data, Hash = hashMac });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, content);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var activationResponse = JsonConvert.DeserializeObject<ActivationResponse>(responseString);
                        return new ActivationResponse { IsActive = true }; ; // Trả về đối tượng đã được parse
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
        public static async Task<ActivationResponse> SecondUsed(double secondUsed)
        {
            var (macAddress, hardDriveSerial, pcName) = SystemInfoHelper.GetSystemInfo();
            var url = _APIURL + "/subvid/minuteUsed";  //Thay đổi url phù hợp với API endpoint của bạn
            DateTimeOffset now = DateTimeOffset.Now;
            var productKey = SystemInfoHelper.getProductKey(); // Giả sử bạn đã có hàm GetProductKey()

            var data = new
            {
                ProductKey = productKey,
                SecondUsed = secondUsed,
                PCName = pcName,
                MacAddress = macAddress,
                HardDriveSerial = hardDriveSerial,
            };

            var json = JsonConvert.SerializeObject(data);
            var hashMac = CreateHmacSha256Signature(json, _PRIVATEKEY);

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
                        Program.MinuteUsed = activationResponse.NumberUsed;
                        Program.MinuteRemain = activationResponse.NumberMin - activationResponse.NumberUsed;
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
            Message = string.Empty;
        }
        public bool IsActive { get; set; }
        public double NumberMin { get; set; }
        public double NumberUsed { get; set; }
        public string Message { get; set; }
    }

    public class ModResponse
    {
        public ModResponse()
        {
            IsActive = false;
            email = string.Empty;
            fullname= string.Empty;
            tenNganHang= string.Empty;
            tenTaiKhoan= string.Empty;
            soTaiKhoan=string.Empty;
            codePaying= string.Empty;
            soDienThoai= string.Empty;
        }
        public bool IsActive { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string tenNganHang { get; set; }
        public string tenTaiKhoan { get; set; }
        public string soTaiKhoan { get; set; }
        public string codePaying { get; set; }
        public string soDienThoai { get; set; }
    }

    public class InfoResponse
    {
        public InfoResponse()
        {
            IsActive = false;
            ProductKey = Email = Message = "";
            NumberMin = NumberUsed = 0;
        }
        public bool IsActive { get; set; }
        public string ProductKey { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public double NumberMin { get; set; }
        public double NumberUsed { get; set; }
    }
    public class IncomeModel
    {
        public IncomeModel()
        {
            IsActive = false;
            totalIncome = 0;
            fullName = soDienThoai = "";
        }
        public bool IsActive { get; set; }
        public double totalIncome { get; set; }
        public string fullName { get; set; }
        public string soDienThoai { get; set; }
    }
}
