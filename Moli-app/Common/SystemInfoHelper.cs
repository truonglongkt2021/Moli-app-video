using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Management;
using System.Windows.Forms;

namespace Moli_app.Common
{
    public static class SystemInfoHelper
    {
        public static (string MacAddress, string HardDriveSerial, string PcName) GetSystemInfo()
        {
            // Lấy PC Name
            string pcName = Environment.MachineName;

            // Lấy địa chỉ MAC của card mạng đang dùng internet
            string macAddress = NetworkInterface.GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();

            // Lấy Serial Number của ổ cứng
            string hardDriveSerial = GetHardDriveSerialNumber();

            return (macAddress, hardDriveSerial, pcName);
        }

        private static string GetHardDriveSerialNumber(string drive = "C:")
        {
            // Tạo một truy vấn WMI để lấy thông tin ổ đĩa
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            // Lấy Serial Number của ổ đĩa đầu tiên
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // Kiểm tra nếu 'SerialNumber' có tồn tại
                if (wmi_HD["SerialNumber"] != null)
                    return wmi_HD["SerialNumber"].ToString();
            }

            return "Unknown";
        }
        public static string getProductKey()
        {
            string registryPath = @"HKEY_CURRENT_USER\Software\Amazingtech\AVID";
            // Tên của giá trị trong registry
            string valueName = "ProductKey";
            // Giá trị mặc định nếu khóa không tồn tại
            string defaultValue = "XXX-XXX-XXX-XXX";

            try
            {
                // Lấy giá trị từ registry
                string productKey = (string)Microsoft.Win32.Registry.GetValue(registryPath, valueName, defaultValue);

                // Kiểm tra nếu giá trị là mặc định, có thể thông báo cho người dùng
                if (productKey == defaultValue)
                {
                    MessageBox.Show("Default or no product key found.");
                }
                else
                {
                    // Sử dụng giá trị productKey cho mục đích của bạn, ví dụ hiển thị lên TextBox
                    return productKey;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Error reading product key: " + ex.Message);
                return null;
            }
            return null;

        }
    }
}
