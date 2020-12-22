using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GomoServer {
    public class Message {
        private int playerColor;
        private Point point;
        private bool isGameOver;

        public int PlayerColor { get => playerColor; set => playerColor = value; }
        public Point Point { get => point; set => point = value; }
        public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

        public Message(int playerColor, Point p, bool isGameOver) {
            this.PlayerColor = playerColor;
            this.Point = p;
            this.IsGameOver = isGameOver;
        }
    }
}
