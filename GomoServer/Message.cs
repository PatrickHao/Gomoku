using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GomoServer {
    public class Message {
        [JsonProperty("playerColor")]
        private int playerColor;
        [JsonProperty("point")]
        private Point point;

        public int PlayerColor { get => playerColor; set => playerColor = value; }
        public Point Point { get => point; set => point = value; }

        public Message(int playerColor, Point p) {
            this.PlayerColor = playerColor;
            this.Point = p;
        }
    }
}
