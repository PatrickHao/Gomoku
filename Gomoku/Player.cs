using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public abstract class Player {
        protected Game game;
        protected Board board;
        protected int playerColor; //0->NULL, 1->blackChess, 2->whiteChess;
        protected bool playerMode; // true->player, false->audience
        //是否是玩家回合
        protected bool state = true;
        protected bool isGameOver = false;

        public int PlayerColor { get => playerColor; set => playerColor = value; }

        public Player(int playerColor, bool playerMode, Board board) {
            game = new Game();
            this.PlayerColor = playerColor;
            this.playerMode = playerMode;
            this.board = board;
        }

        public abstract void playerAction(int x, int y);
    }
}
