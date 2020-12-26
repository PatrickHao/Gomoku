using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Gomoku {
    class ClientControl {
        private Socket clientSocket;

        public ClientControl() {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        //public delegate void MessageHandler(int param1, int param2, int param3); //声明关于事件的委托
        //public event MessageHandler MessageHandle; //声明事件
        public event EventHandler<MessageProcessEventArgs> MessageProcess;

        public void Connect(string ip, int port) {
            //try {
            //    clientSocket.Connect(ip, port);
            //    Thread threadReceive = new Thread(Receive);
            //    threadReceive.IsBackground = true;
            //    threadReceive.Start();
            //} catch {
            //    MessageBox.Show("无法连接服务器");
            //}
            clientSocket.Connect(ip, port);
            Thread threadReceive = new Thread(Receive);
            threadReceive.IsBackground = true;
            threadReceive.Start();

        }
        public void Receive() {
            try {
                byte[] msg = new byte[1024];
                int msgLen = clientSocket.Receive(msg);
                //process
                string messageStr = Encoding.UTF8.GetString(msg, 0, msgLen);
                Message message = (Message)JsonConvert.DeserializeObject(messageStr, typeof(Message));
                MessageProcess(this, new MessageProcessEventArgs(message));
                Receive();
            } catch {
                MessageBox.Show("服务器连接拒绝");
            }
        }

        public void Send(string msg) {
            clientSocket.Send(Encoding.UTF8.GetBytes(msg));
        }
    }
}
