using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class PlayerLocal : Player {
        public event EventHandler<GameOverEventArgs> OnGameOver;

        public PlayerLocal(int playerColor, bool playerMode, Board board) : base(playerColor, playerMode, board) { }

        public override void playerAction(int x, int y) {
            if (state) {
                
            }
        }
    }
}