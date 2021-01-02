using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class PlayerLocal : Player {
        AIPlayer aiPlayer;
        public PlayerLocal(int playerColor, Board board) : base(playerColor, board) {
            state = playerColor == 1;
            aiPlayer = new AIPlayer();
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
                    } else {
                        Point p2 = aiPlayer.getAIStep(game.Board);
                        game.doMove(p2.X, p2.Y, 3 - PlayerColor);
                        board.drawChess(p2.X, p2.Y, 3 - PlayerColor);
                        state = true;
                        if (game.isGameOver(p2.X, p2.Y, 3 - PlayerColor)) {
                            isGameOver = true;
                            gameOver(3 - PlayerColor);
                        }
                    }
                }
            }
        }

        public override void startGame() {
            game.initBoard();
            board.initBoard();
            state = playerColor == 1;
            isGameOver = false;
            aiPlayer.startGame();
        }
    }
}