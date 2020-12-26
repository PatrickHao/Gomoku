using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public abstract class Player {
        protected Game game;
        protected Board board;
        protected int playerColor; //0->NULL, 1->blackChess, 2->whiteChess, 3->audience
        //是否是玩家回合
        protected bool state = true;
        protected bool isGameOver = false;

        public event EventHandler<GameOverEventArgs> OnGameOver;

        public int PlayerColor { get => playerColor; set => playerColor = value; }

        public Player(int playerColor, Board board) {
            game = new Game();
            this.PlayerColor = playerColor;
            this.board = board;
        }

        protected void gameOver(int playerColor) {
            OnGameOver(this, new GameOverEventArgs(playerColor));
        }

        public abstract void playerAction(int x, int y);

        public abstract void startGame();

        public virtual void leaveRoom(){}
    }
}
