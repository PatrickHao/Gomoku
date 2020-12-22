using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GomoServer {
    class Message {
        private int playerColor;
        private Point point;

        public int PlayerColor { get => playerColor; set => playerColor = value; }
        public Point Point { get => point; set => point = value; }
    }
}
