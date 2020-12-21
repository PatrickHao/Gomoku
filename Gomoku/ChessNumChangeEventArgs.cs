using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class ChessNumChangeEventArgs : EventArgs {
        public int Num { get; set; }
        public int PlayerColor { get; set; }
        public ChessNumChangeEventArgs(int num, int playerColor) {
            this.Num = num;
            this.PlayerColor = playerColor;
        }
    }
}