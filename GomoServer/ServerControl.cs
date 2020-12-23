using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GomoServer {
    class ServerControl {
        private Socket serverSocket;

        private List<Client> clientList;


        public ServerControl() {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientList = new List<Client>();
        }

        public void Start() {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 12321));
            serverSocket.Listen(10);
            Console.WriteLine("Server Started Successful");

            Thread threadAccpt = new Thread(Accept);
            threadAccpt.IsBackground = true;
            threadAccpt.Start();

        }

        private void Accept() {
            Socket clientSocket = serverSocket.Accept();
            IPEndPoint point = clientSocket.RemoteEndPoint as IPEndPoint;
            Console.WriteLine(point.Address + "[" + point.Port + "] connected");

            Client client = new Client(-1, clientSocket);

            clientList.Add(client);
            Thread threadReceive = new Thread(ReceiveRoomNum);
            threadReceive.IsBackground = true;
            threadReceive.Start(client);
            Accept();

        }

        private void ReceiveRoomNum(Object obj) {
            Client client = obj as Client;
            IPEndPoint point = client.Socket.RemoteEndPoint as IPEndPoint;
            try {
                byte[] msg = new byte[1024];
                int msgLen = client.Socket.Receive(msg);
                string msgStr = Encoding.UTF8.GetString(msg, 0, msgLen);
                //Console.WriteLine(point.Address + "[" + point.Port + "]:" + msgStr);
                //设置roomNum
                client.RoomNum = Convert.ToInt32(msgStr);

                Receive(client);
            } catch {
                Console.WriteLine(point.Address + "[" + point.Port + "]  disconnected");
                clientList.Remove(client);
            }

        }

        private void Receive(Object obj) {
            Client client = obj as Client;
            IPEndPoint point = client.Socket.RemoteEndPoint as IPEndPoint;
            try {
                byte[] msg = new byte[1024];
                int msgLen = client.Socket.Receive(msg);
                string msgStr = Encoding.UTF8.GetString(msg, 0, msgLen);
                Console.WriteLine(point.Address + "[" + point.Port + "]:" + msgStr);
                //广播给另一个player
                Broadcast(client, msgStr);
                Receive(client);
            } catch {
                Console.WriteLine(point.Address + "[" + point.Port + "]  disconnected");
                clientList.Remove(client);
            }

        }

        private void Broadcast(Client clientOther, string msg) {
            foreach (var client in clientList) {
                if (client == clientOther || client.RoomNum != clientOther.RoomNum) {

                } else {
                    client.Socket.Send(Encoding.UTF8.GetBytes(msg));
                }
                //client.Send(Encoding.UTF8.GetBytes(msg));
            }

        }
    }
}