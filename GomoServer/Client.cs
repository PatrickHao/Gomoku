using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GomoServer {
    class Client {
        private Socket socket;

        private int roomNum;

        public Socket Socket { get => socket; set => socket = value; }
        public int RoomNum { get => roomNum; set => roomNum = value; }

        public Client(int roomNum, Socket socket) {
            this.roomNum = roomNum;
            this.socket = socket;
        }
    }
}