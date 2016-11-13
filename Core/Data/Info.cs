using System;
using System.Collections.Generic;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace BoRAT.Core.Data
{
    class Info
    {
        public static string Hwid { get; set; }
        public static string Version { get; } = "1";
        public static string Username { get; set; }
        public static string Windows { get; set; }
        public static string Bits { get; set; }

        static string info { get; set; } = "";

        public static string Get()
        {
            if(info.Length > 0)
                return info;

            Hwid = GetHwid();
            Username = Environment.UserName;
            Windows = GetWindows();
            Bits = Marshal.SizeOf(typeof(IntPtr)) == 4 ? "32" : "64";

            info = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}&&", "|", Hwid, Version, Username, Windows, Bits);
            return info;
        }

        private static string GetWindows()
        {
            switch(Environment.OSVersion.Version.Major)
            {
                case 5:
                    if (Environment.OSVersion.Version.Minor == 0) Windows = "Windows 2000";
                    else if (Environment.OSVersion.Version.Minor == 1 || Environment.OSVersion.Version.Minor == 2) Windows = "Windows XP";
                    break;
                case 6:
                    if (Environment.OSVersion.Version.Minor == 0) Windows = "Windows Vista";
                    else if (Environment.OSVersion.Version.Minor == 1) Windows = "Windows 7";
                    else if (Environment.OSVersion.Version.Minor == 2) Windows = "Windows 8";
                    break;
                case 10:
                    Windows = "Windows 10";
                    break;
                default:
                    Windows = "Udefined";
                    break;
            }
            return Windows;
        }

        private static string GetHwid()
        {
            string ProcessorId = "", VolumeSerNum = "", BaseBoardSerNum = "";

            // ProcessorId
            foreach (ManagementObject mo in new ManagementObjectSearcher("Select ProcessorId From Win32_processor").Get())
                ProcessorId = mo["ProcessorId"].ToString();

            // Volume Serial Number
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            dsk.Get();
            VolumeSerNum = dsk["VolumeSerialNumber"].ToString();

            // Base Board Serial Number
            foreach (ManagementObject mo in new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard").Get())
                BaseBoardSerNum = (string)mo["SerialNumber"];

            return MD5(ProcessorId + VolumeSerNum + BaseBoardSerNum);
        }

        private static string MD5(string data)
        {
            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(data);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
               // without dashes
               .Replace("-", string.Empty)
               // make lowercase
               .ToLower();

            return encoded;
        }


    }
}
