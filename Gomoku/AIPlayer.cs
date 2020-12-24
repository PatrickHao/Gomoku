using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public static class AIPlayer {
        private const int boardSize = 15;
        private static int[,,] gradeMap = new int[3, boardSize, boardSize];
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

        //test function
        public static Point getAIStep(int[,] board) {
            const int INF = 1000000000;
            int max1, max2, x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            max1 = max2 = -INF;
            for (int i = 0; i < boardSize; i++) {
                for (int j = 0; j < boardSize; j++) {
                    if (board[i, j] == 0) {
                        int temp1, temp2;
                        temp1 = getPointScore(i, j, 1, board);
                        temp2 = getPointScore(i, j, 2, board);
                        if (temp1 > max1) {
                            max1 = temp1;
                            x1 = i;
                            y1 = j;
                        }
                        if (temp2 > max2) {
                            max2 = temp2;
                            x2 = i;
                            y2 = j;
                        }
                    }
                }
            }
            if (max1 != max2) {
                return max1 > max2 ? new Point(x1, y1) : new Point(x2, y2);
            } else {
                return new Point(x1, y2);
            }
        }

        private static int getPointScore(int x, int y, int playerColor, int[,] board) {
            int ans = 0, num, num1, num2, block, emptyIndex;
            // -
            num = 1;
            num1 = num2 = block = 0;
            emptyIndex = -1;
            for (int i = y + 1; true; i++) {
                if (i >= boardSize) {
                    block++;
                    break;
                }
                int temp = board[x, i];
                if (temp == 0) {
                    if (emptyIndex == -1 && i < boardSize - 1 && board[x, i + 1] == playerColor) {
                        emptyIndex = num1;
                        continue;
                    } else {
                        break;
                    }
                }
                if (temp == playerColor) {
                    num1++;
                    continue;
                } else {
                    block++;
                    break;
                }
            }
            for (int i = y - 1; true; i--) {
                if (i < 0) {
                    block++;
                    break;
                }
                int temp = board[x, i];
                if (temp == 0) {
                    if (emptyIndex == -1 && i < boardSize - 1 && board[x, i - 1] == playerColor) {
                        emptyIndex = 0;
                        continue;
                    } else {
                        break;
                    }
                }
                if (temp == playerColor) {
                    num2++;
                    if (emptyIndex != -1) {
                        emptyIndex++;
                    }
                    continue;
                } else {
                    block++;
                    break;
                }
            }
            num = num1 + num2;
            gradeMap[playerColor, x, y] += numToScore(num, block, emptyIndex);
            ans += gradeMap[playerColor, x, y];
            // |
            num = 1;
            num1 = num2 = block = 0;
            emptyIndex = -1;
            for (int i = x + 1; true; i++) {
                if (i >= boardSize) {
                    block++;
                    break;
                }
                int temp = board[i, y];
                if (temp == 0) {
                    if (emptyIndex == -1 && i < boardSize - 1 && board[i + 1, y] == playerColor) {
                        emptyIndex = num1;
                        continue;
                    } else {
                        break;
                    }
                }
                if (temp == playerColor) {
                    num1++;
                    continue;
                } else {
                    block++;
                    break;
                }
            }

            for (int i = x - 1; true; i--) {
                if (i < 0) {
                    block++;
                    break;
                }
                int temp = board[i, y];
                if (temp == 0) {
                    if (emptyIndex == -1 && i < boardSize - 1 && board[i - 1, y] == playerColor) {
                        emptyIndex = 0;
                        continue;
                    } else {
                        break;
                    }
                }
                if (temp == playerColor) {
                    num2++;
                    if (emptyIndex != -1) {
                        emptyIndex++;
                    }
                    continue;
                } else {
                    block++;
                    break;
                }
            }
            num = num1 + num2;
            gradeMap[playerColor, x, y] += numToScore(num, block, emptyIndex);
            ans += gradeMap[playerColor, x, y];
            // \
            num = 1;
            num1 = num2 = block = 0;
            emptyIndex = -1;
            for (int delta = 1; true; delta++) {
                int i = x + delta, j = y + delta;
                if (i >= boardSize || j >= boardSize) {
                    block++;
                    break;
                }
                int temp = board[i, j];
                if (temp == 0) {
                    if (emptyIndex == -1 && (i < boardSize - 1 && j < boardSize - 1) && board[i + 1, j + 1] == playerColor) {
                        emptyIndex = num1;
                        continue;
                    } else {
                        break;
                    }
                }
                if (temp == playerColor) {
                    num1++;
                    continue;
                } else {
                    block++;
                    break;
                }
            }
            for (int delta = 1; true; delta++) {
                int i = x - delta, j = y - delta;
                if (i < 0 || j < 0) {
                    block++;
                    break;
                }
                int temp = board[i, j];
                if (temp == 0) {
                    if (emptyIndex == -1 && (i > 0 && j > 0) && board[i - 1, j - 1] == playerColor) {
                        emptyIndex = 0;
                        continue;
                    } else {
                        break;
                    }
                }
                if (temp == playerColor) {
                    num2++;
                    if (emptyIndex != -1) {
                        emptyIndex++;
                    }
                    continue;
                } else {
                    block++;
                    break;
                }
            }
            num = num1 + num2;
            gradeMap[playerColor, x, y] += numToScore(num, block, emptyIndex);
            ans += gradeMap[playerColor, x, y];
            // /
            num = 1;
            num1 = num2 = block = 0;
            emptyIndex = -1;
            for (int delta = 1; true; delta++) {
                int i = x + delta, j = y - delta;
                if (i < 0 || j < 0 || x >= boardSize || y >= boardSize) {
                    block++;
                    break;
                }
                int temp = board[i, j];
                if (temp == 0) {
                    if (emptyIndex == -1 && (i < boardSize - 1 && j > 0) && board[i + 1, j - 1] == playerColor) {
                        emptyIndex = num1;
                        continue;
                    } else {
                        break;
                    }
                }
                if (temp == playerColor) {
                    num1++;
                    continue;
                } else {
                    block++;
                    break;
                }
            }
            for (int delta = 1; true; delta++) {
                int i = x - delta, j = y + delta;
                if (i < 0 || j < 0 || x >= boardSize || y >= boardSize) {
                    block++;
                    break;
                }
                int temp = board[i, j];
                if (temp == 0) {
                    if (emptyIndex == -1 && (i > 0 && j < boardSize - 1) && board[i - 1, j + 1] == playerColor) {
                        emptyIndex = 0;
                        continue;
                    } else {
                        break;
                    }
                }
                if (temp == playerColor) {
                    num2++;
                    if (emptyIndex != -1) {
                        emptyIndex++;
                    }
                    continue;
                } else {
                    block++;
                    break;
                }
            }
            num = num1 + num2;
            gradeMap[playerColor, x, y] += numToScore(num, block, emptyIndex);
            ans += gradeMap[playerColor, x, y];

            return ans;
        }

        private static int numToScore(int num, int block, int emptyIndex) {
            if (emptyIndex <= 0) {
                if (num >= 5) {
                    return FIVE;
                }
                if (block == 0) {
                    switch (num) {
                        case 1:
                            return ONE;
                        case 2:
                            return TWO;
                        case 3:
                            return THREE;
                        case 4:
                            return FOUR;
                        default:
                            break;
                    }
                }
                if (block == 1) {
                    switch (num) {
                        case 1:
                            return BLOCKED_ONE;
                        case 2:
                            return BLOCKED_TWO;
                        case 3:
                            return BLOCKED_THREE;
                        case 4:
                            return BLOCKED_FOUR;
                        default:
                            break;
                    }
                }
            } else if (emptyIndex == 1 || emptyIndex == num - 1) {
                if (num >= 6) {
                    return FIVE;
                }
                if (block == 0) {
                    switch (num) {
                        case 2:
                            return TWO / 2;
                        case 3:
                            return THREE;
                        case 4:
                            return BLOCKED_FOUR;
                        case 5:
                            return FOUR;
                        default:
                            break;
                    }
                }
                if (block == 1) {
                    switch (num) {
                        case 2:
                            return BLOCKED_TWO;
                        case 3:
                            return BLOCKED_THREE;
                        case 4:
                            return BLOCKED_FOUR;
                        case 5:
                            return BLOCKED_FOUR;
                        default:
                            break;
                    }
                }
            } else if (emptyIndex == 2 || emptyIndex == num - 2) {
                if (num >= 7) {
                    return FIVE;
                }
                if (block == 0) {
                    switch (num) {
                        case 3:
                            return THREE;
                        case 5:
                            return BLOCKED_FOUR;
                        case 6:
                            return FOUR;
                        default:
                            break;
                    }
                }
                if (block == 1) {
                    switch (num) {
                        case 3:
                            return BLOCKED_THREE;
                        case 4:
                            return BLOCKED_FOUR;
                        case 5:
                            return BLOCKED_FOUR;
                        case 6:
                            return FOUR;
                        default:
                            break;
                    }
                }
                if (block == 2) {
                    switch (num) {
                        case 6:
                            return BLOCKED_FOUR;
                        default:
                            break;
                    }
                }
            } else if (emptyIndex == 3 || emptyIndex == num - 3) {
                if (num >= 8) {
                    return FIVE;
                }
                if (block == 0) {
                    switch (num) {
                        case 5:
                            return THREE;
                        case 6:
                            return BLOCKED_FOUR;
                        case 7:
                            return FOUR;
                        default:
                            break;
                    }
                }
                if (block == 1) {
                    switch (num) {
                        case 6:
                            return BLOCKED_FOUR;
                        case 7:
                            return FOUR;
                        default:
                            break;
                    }
                }
                if (block == 2) {
                    switch (num) {
                        case 7:
                            return BLOCKED_FOUR;
                        default:
                            break;
                    }
                }
            } else if (emptyIndex == 4 || emptyIndex == num - 4) {
                if (num >= 9) {
                    return FIVE;
                }
                if (block == 0) {
                    switch (num) {
                        case 8:
                            return FOUR;
                        default:
                            break;
                    }
                }
                if (block == 1) {
                    switch (num) {
                        case 7:
                            return BLOCKED_FOUR;
                        case 8:
                            return FOUR;
                        default:
                            break;
                    }
                }
                if (block == 2) {
                    switch (num) {
                        case 8:
                            return BLOCKED_FOUR;
                        default:
                            break;
                    }
                }
            } else if (emptyIndex == 5 || emptyIndex == num - 5) {
                return FIVE;
            }
            return 0;
        }
    }
}
