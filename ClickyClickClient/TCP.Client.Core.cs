/*
 * Copyright (c) 2019. All rights reserved.
 * Author: Sjoerd Teunisse
 * Contact details: sjoerdteunisse at googleMailDns server dot com
 */

using System;
using System.Text;
using System.Diagnostics;
using System.Net.Sockets;

namespace ClickyClickClient
{
    public class TCPClient
    {
        private const int PortNo = 5000;
        private const string ServerIp = "127.0.0.1";

        public void TransferKeystroke(string input)
        {
            try
            {
                TcpClient client = new TcpClient(ServerIp, PortNo);

                //ByteArray
                var data = Encoding.UTF8.GetBytes(input);

                //GetStream
                NetworkStream stream = client.GetStream();

                //Write
                stream.Write(data, 0, data.Length);

                Debug.WriteLine("AXR-Network - " + "transferred");

                data = new Byte[256];

                if (client.ReceiveBufferSize > 0)
                {
                    var bytes = new byte[client.ReceiveBufferSize];
                    stream.Read(bytes, 0, client.ReceiveBufferSize);
                    string msg = Encoding.UTF8.GetString(bytes); //the incoming message

                    GameEngine.Instance.OnServerMessageReceived(msg);

                    Debug.WriteLine("Received: {0}", msg);
                }

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(@"ArgumentNullException: {0}", e);
            }
        }
    }
}
