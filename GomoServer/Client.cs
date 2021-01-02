using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GomoServer {
    class Client {
        private Socket socket;

        private int roomID;

        public Socket Socket { get => socket; set => socket = value; }
        public int RoomID { get => roomID; set => roomID = value; }

        public Client(int roomID, Socket socket) {
            this.roomID = roomID;
            this.socket = socket;
        }
    }
}