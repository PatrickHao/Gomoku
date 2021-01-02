using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class PlayerLocal : Player {
        private AIPlayer aiPlayer;
        public PlayerLocal(int playerColor, Board board) : base(playerColor, board) {
            state = playerColor == 1;
            aiPlayer = new AIPlayer();
        }

        public override void playerAction(int x, int y) {
            if (state && !isGameOver) {
                Point p = new Point(0, 0);
                //当前位置为空
                if (board.getMousePoint(x, y, ref p) && game.isEmpty(p.X, p.Y)) {
                    //走棋
                    game.doMove(p.X, p.Y, PlayerColor);
                    board.drawChess(p.X, p.Y, PlayerColor);
                    //关闭走棋权限
                    state = false;
                    //判断是否结束
                    if (game.isGameOver(p.X, p.Y, PlayerColor)) {
                        isGameOver = true;
                        gameOver(PlayerColor);
                    } else {
                        //得到AI的落子
                        Point p2 = aiPlayer.getAIStep(game.Board);
                        game.doMove(p2.X, p2.Y, 3 - PlayerColor);
                        board.drawChess(p2.X, p2.Y, 3 - PlayerColor);
                        state = true;
                        //判断是否结束
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