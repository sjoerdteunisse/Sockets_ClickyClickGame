/*
 * Copyright (c) 2019. All rights reserved.
 * Author: Sjoerd Teunisse
 * Contact details: sjoerdteunisse at googleMailDns server dot com
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClickyClickServer
{
    class TCPServerCore
    {
        const int PortNo = 5000;
        const string ServerIp = "127.0.0.1";

        public void Initialize()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, PortNo);
            Console.WriteLine($"Listening on {PortNo} on address {ServerIp}");
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                //Handle separate client request on different thread
                ThreadPool.QueueUserWorkItem(ThreadProc, client);
            }
        }


        /// <summary>
        /// //Handles each request on a different thread.
        /// </summary>
        /// <param name="obj"></param>
        private void ThreadProc(object obj)
        {
            var client = (TcpClient)obj;

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            //---read incoming stream---
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            //---convert the data received into a string---
            string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);


            //Handle whatever comming in.
            if (!string.IsNullOrEmpty(dataReceived))
            {
                byte[] data = Encoding.UTF8.GetBytes(HandleAction(dataReceived));
                nwStream.Write(data, 0, data.Length);
            }

            Console.WriteLine("Server Debug- Received: " + dataReceived + "  from address family: " + client.Client.AddressFamily + " source ip " + client.Client.RemoteEndPoint.ToString() );
        } 

        public string HandleAction(string dataReceived)
        {
            //Highscores
            //if (dataReceived.StartsWith("highscore:"))
            //{
            //    GameRequestEngine.Instance.StoreHighScore(dataReceived);
            //    return null;
            //}

            return GameRequestEngine.Instance.HandleMove(dataReceived);
        }
    }
}
