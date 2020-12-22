using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Gomoku
{
    class ClientControl
    {
        private Socket clientSocket;


        public ClientControl()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string ip, int port)
        {
            clientSocket.Connect(ip, port);
            Console.WriteLine("连接服务器成功");

            Thread threadReceive = new Thread(Receive);
            threadReceive.IsBackground = true;
            threadReceive.Start();

        }
        public void Receive()
        {
            try
            {
                byte[] msg = new byte[1024];
                int msgLen = clientSocket.Receive(msg);
                //Console.WriteLine("服务器说: " + Encoding.UTF8.GetString(msg, 0, msgLen));
                //string pointStr = Encoding.UTF8.GetString(msg, 0,msgLen);

                //MainForm.f.recData.Text += Encoding.UTF8.GetString(msg, 0, msgLen);


                Receive();
            }
            catch
            {
                Console.WriteLine("服务器积极拒绝");
            }
        }

        public void Send(string msg)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(msg));
        }

    }
}
