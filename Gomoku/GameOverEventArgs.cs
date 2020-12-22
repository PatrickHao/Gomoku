using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class GameOverEventArgs : EventArgs {
        private int playerColor;
        private string message;

        public GameOverEventArgs(int playerColor) {
            this.PlayerColor = playerColor;
            this.Message = (PlayerColor == 1 ? "黑棋" : "白棋") + "赢了";
        }

        public int PlayerColor { get => playerColor; set => playerColor = value; }
        public string Message { get => message; set => message = value; }
    }
}