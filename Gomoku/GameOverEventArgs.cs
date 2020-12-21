using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class GameOverEventArgs : EventArgs {
        public int PlayerColor { get; set; }
        public string Message { get; set; }

        public GameOverEventArgs(int playerColor) {
            this.PlayerColor = PlayerColor;
            this.Message = (PlayerColor == 1 ? "黑棋" : "白棋") + "赢了";
        }
    }
}