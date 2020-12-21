using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class Game {
        private const int boardSize = 15;
        private int[,] board;

        public Game() {
            board = new int[boardSize, boardSize];
            initBoard();
        }

        private void initBoard() {
            for (int i = 0; i < boardSize; i++) {
                for (int j = 0; j < boardSize; j++) {
                    board[i, j] = 0;
                }
            }
        }

        public void doMove(int x, int y) {

        }
    }
}
