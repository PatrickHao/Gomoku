using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class AIPlayer {
        Game game;
        const int boardSize = 15;
        //棋型估值
        //活一
        private const int ONE = 10;
        //活二
        private const int TWO = 100;
        //活三
        private const int THREE = 1000;
        //活四
        private const int FOUR = 10000;
        //连五
        private const int FIVE = 10000000;
        //死一
        private const int BLOCKED_ONE = 1;
        //死二
        private const int BLOCKED_TWO = 10;
        //死三
        private const int BLOCKED_THREE = 100;
        //死四
        private const int BLOCKED_FOUR = 10000;

        public enum situationType {
            One,
            Two,
            Three,
            Four,
            Five,
            BlockedOne,
            BlockedTwo,
            BlockedThree,
            BlockedFour
        }

        public AIPlayer(Game game) {
            this.game = game;
        }

        //是否越界
        private bool isInBoard(int x, int y) {
            return x >= 0 && x < boardSize && y >= 0 && y < boardSize;
        }

        //判断某个点是否有棋子
        private bool isEmpty(int x, int y) {
            return isInBoard(x, y) && game.Board[x, y] == 0;
        }

        //各种棋型的判断
        public situationType getSituationType(int x, int y, int playerColor) {
            // 八个方向
            // a b c
            // d 0 e
            // f g h
            // lTag1 vTag1 rTag1
            //
            // hTag1   0   hTag2
            //
            // rTag2 vTag2 lTag2
            int hSum, vSum, lSum, rSum, i, j;
            bool hTag1, hTag2, vTag1, vTag2, lTag1, lTag2, rTag1, rTag2;
            hTag1 = hTag2 = vTag1 = vTag2 = lTag1 = lTag2 = rTag1 = rTag2 = false;
            i = x - 1;
            j = y - 1;
            hSum = vSum = lSum = rSum = 1;
            //a
            while (i >= 0 && j >= 0) {
                if (game.Board[i, j] == playerColor) {
                    lSum++;
                } else if (game.Board[i, j] == 0) {
                    lTag1 = true;
                    break;
                } else {
                    break;
                }
                i--;
                j--;
            }
            //b
            j = y - 1;
            while (j >= 0) {
                if (game.Board[x, j] == playerColor) {
                    hSum++;
                } else if (game.Board[i, j] == 0) {
                    vTag1 = true;
                    break;
                } else {
                    break;
                }
                j--;
            }
            //c
            i = x + 1;
            j = y - 1;
            while (i < boardSize && j >= 0) {
                if (game.Board[i, j] == playerColor) {
                    rSum++;
                } else if (game.Board[i, j] == 0) {
                    rTag1 = true;
                    break;
                } else {
                    break;
                }
                i++;
                j--;
            }
            //d
            i = x - 1;
            while (i >= 0) {
                if (game.Board[i, y] == playerColor) {
                    vSum++;
                } else if (game.Board[i, j] == 0) {
                    hTag1 = true;
                    break;
                } else {
                    break;
                }
                i--;
            }
            //e
            i = x + 1;
            while (i < boardSize) {
                if (game.Board[i, y] == playerColor) {
                    vSum++;
                } else if (game.Board[i, j] == 0) {
                    hTag2 = true;
                    break;
                } else {
                    break;
                }
                i++;
            }
            //f
            i = x - 1;
            j = y + 1;
            while (i >= 0 && j < boardSize) {
                if (game.Board[i, j] == playerColor) {
                    rSum++;
                } else if (game.Board[i, j] == 0) {
                    rTag2 = true;
                    break;
                } else {
                    break;
                }
                i--;
                j++;
            }
            //g
            j = y + 1;
            while (j < boardSize) {
                if (game.Board[x, j] == playerColor) {
                    hSum++;
                } else if (game.Board[i, j] == 0) {
                    vTag2 = true;
                    break;
                } else {
                    break;
                }
                j++;
            }
            //h
            i = x + 1;
            j = y + 1;
            while (i < boardSize && j < boardSize) {
                if (game.Board[i, j] == playerColor) {
                    lSum++;
                } else if (game.Board[i, j] == 0) {
                    lTag2 = true;
                    break;
                } else {
                    break;
                }
                i++;
                j++;
            }
            return situationType.BlockedFour;
        }


    }
}