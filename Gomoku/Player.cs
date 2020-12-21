using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    /// <summary>
    /// 玩家类
    /// </summary>
    public class Player {
        private Game game;
        private Board board;
        private int playerID;
        private int playerColor; //0->NULL, 1->blackChess, 2->whiteChess;
        private bool state = true;

        public event EventHandler<GameOverEventArgs> OnGameOver;

        public Player(int playerID, int playerColor, Board board) {
            game = new Game();
            this.board = board;
            this.PlayerID = playerID;
            this.PlayerColor = playerColor;
        }

        public int PlayerID { get => playerID; set => playerID = value; }
        public int PlayerColor { get => playerColor; set => playerColor = value; }

        public void playerAction(int x, int y) {
            if (state) {
                Point p = new Point(0, 0);
                if (board.getMousePoint(x, y, ref p) && game.isIndexEmpty(p.X, p.Y)) {
                    game.doMove(p.X, p.Y, PlayerColor);
                    board.drawChess(p.X, p.Y, PlayerColor);
                    if (game.isGameOver(p.X, p.Y, PlayerColor)) {
                        //to process--state
                        OnGameOver(this, new GameOverEventArgs(PlayerColor));
                    } else {
                        //to process
                    }
                }
            }
        }

        public void startGame() {
            game.initBoard();
            board.initBoard();
        }
    }
}
