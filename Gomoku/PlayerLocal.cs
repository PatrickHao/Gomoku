using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class PlayerLocal : Player {

        public PlayerLocal(int playerColor, Board board) : base(playerColor, board) {
            state = playerColor == 1;
        }

        public override void playerAction(int x, int y) {
            if (state && !isGameOver) {
                Point p = new Point(0, 0);
                if (board.getMousePoint(x, y, ref p) && game.isEmpty(p.X, p.Y)) {
                    game.doMove(p.X, p.Y, PlayerColor);
                    board.drawChess(p.X, p.Y, PlayerColor);
                    state = false;
                    if (game.isGameOver(p.X, p.Y, PlayerColor)) {
                        isGameOver = true;
                        gameOver(PlayerColor);
                    }
                }
            } else {
                Point p = AIPlayer.getAIStep(game.Board);
                game.doMove(p.X, p.Y, PlayerColor);
                board.drawChess(p.X, p.Y, PlayerColor);
                state = true;
                if (game.isGameOver(p.X, p.Y, PlayerColor)) {
                    isGameOver = true;
                    gameOver(PlayerColor);
                }
            }
        }

        public override void startGame() {
            game.initBoard();
            board.initBoard();
        }
    }
}