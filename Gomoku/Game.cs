using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    /// <summary>
    /// 五子棋游戏规则类
    /// </summary>
    public class Game {
        private const int boardSize = 15;
        private int[,] board = new int[boardSize, boardSize];

        public int[,] Board { get => board; }

        public Game() {
            initBoard();
        }

        public void initBoard() {
            for (int i = 0; i < boardSize; i++) {
                for (int j = 0; j < boardSize; j++) {
                    Board[i, j] = 0;
                }
            }
        }

        public bool isEmpty(int x, int y) {
            return Board[x, y] == 0;
        }

        public bool isGameOver(int x, int y, int playerColor) {
            //棋子计数
            int hSum, vSum, lSum, rSum;
            hSum = vSum = lSum = rSum = 1;
            int i, j;
            i = x - 1;
            j = y - 1;
            while (i >= 0 && j >= 0) {
                if (Board[i, j] == playerColor) {
                    lSum++;
                } else {
                    break;
                }
                i--;
                j--;
            }
            j = y - 1;
            while (j >= 0) {
                if (Board[x, j] == playerColor) {
                    hSum++;
                } else {
                    break;
                }
                j--;
            }
            i = x + 1;
            j = y - 1;
            while (i < boardSize && j >= 0) {
                if (Board[i, j] == playerColor) {
                    rSum++;
                } else {
                    break;
                }
                i++;
                j--;
            }
            i = x - 1;
            while (i >= 0) {
                if (Board[i, y] == playerColor) {
                    vSum++;
                } else {
                    break;
                }
                i--;
            }
            i = x + 1;
            while (i < boardSize) {
                if (Board[i, y] == playerColor) {
                    vSum++;
                } else {
                    break;
                }
                i++;
            }
            i = x - 1;
            j = y + 1;
            while (i >= 0 && j < boardSize) {
                if (Board[i, j] == playerColor) {
                    rSum++;
                } else {
                    break;
                }
                i--;
                j++;
            }
            j = y + 1;
            while (j < boardSize) {
                if (Board[x, j] == playerColor) {
                    hSum++;
                } else {
                    break;
                }
                j++;
            }
            i = x + 1;
            j = y + 1;
            while (i < boardSize && j < boardSize) {
                if (Board[i, j] == playerColor) {
                    lSum++;
                } else {
                    break;
                }
                i++;
                j++;
            }
            return hSum >= 5 || vSum >= 5 || lSum >= 5 || rSum >= 5;
        }

        public void doMove(int x, int y, int playerColor) {
            Board[x, y] = playerColor;
            //if (isGameOver(x, y, playerColor)) {
            //    // to Process
            //}
        }
    }
}