using System;

namespace BoRAT.Core.Recovery.Browsers
{
    public class RecoveredAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public string Application { get; set; }

        public override string ToString()
        {
            return String.Format("{1}{0}{2}{0}{3}{0}", 
                Environment.NewLine, URL, Username, Password);
        }
    }
}
