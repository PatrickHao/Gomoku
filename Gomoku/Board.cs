using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku {
    public class Board : Panel {
        private enum gameMode {
            personVSPerson,
            personVSComputer
        }

        private static Bitmap blackChess = Gomoku.Properties.Resources.blackChess;
        private static Bitmap whiteChess = Gomoku.Properties.Resources.whiteChess;
        //棋盘数据
        private const int boardSize = 15;
        private const int blockSize = 30;
        private const int delta = 42;
        private const int chessSize = 24;
        private const int controllerSize = (boardSize - 1) * blockSize + delta * 2;
        private bool isStart = false;
        //0->NULL, 1->blackChess, 2->whiteChess
        private int playerColor = 1;
        private int[,] board = new int[boardSize, boardSize];
        //棋子计数
        private int hSum;
        private int vSum;
        private int lSum;
        private int rSum;

        public event EventHandler<ChessNumChangeEventArgs> OnChessNumChange;
        public event EventHandler<GameOverEventArgs> OnGameOver;

        public Board() {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //双缓冲
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Size = new Size(controllerSize, controllerSize);
            drawBackground();
        }

        private Point indexToReal(int x, int y) {
            return new Point(x * blockSize + delta, y * blockSize + delta);
        }

        private Point realToIndex(int x, int y) {
            int px = ((x - delta) + blockSize / 2) / blockSize;
            int py = ((y - delta) + blockSize / 2) / blockSize;
            return new Point(px, py);
        }

        private void drawBackground() {
            Bitmap bm = new Bitmap(controllerSize, controllerSize);
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(Brushes.BurlyWood, new Rectangle(0, 0, controllerSize, controllerSize));
            Pen pen = new Pen(Color.Black, 1);
            for (int i = 0; i < boardSize; i++) {
                Point hPointStart = indexToReal(0, i);
                Point hPointEnd = indexToReal(boardSize - 1, i);
                Point vPointStart = indexToReal(i, 0);
                Point vPointEnd = indexToReal(i, boardSize - 1);
                g.DrawLine(pen, hPointStart, hPointEnd);
                g.DrawLine(pen, vPointStart, vPointEnd);
            }
            g.Dispose();
            this.BackgroundImage = bm;
        }

        private void drawChess(Point p, int playerColor) {
            Bitmap bm = playerColor == 1 ? blackChess : whiteChess;
            Graphics g = Graphics.FromImage(this.BackgroundImage);
            p.X -= chessSize / 2;
            p.Y -= chessSize / 2;
            g.DrawImage(bm, p.X, p.Y, chessSize, chessSize);
            g.Dispose();
            this.Invalidate();
        }

        private bool isPointLegal(int x, int y, ref Point p) {
            int leftBorder = delta - blockSize / 2;
            int rightBoder = delta + (boardSize - 1) * blockSize + blockSize / 2;
            if (x < leftBorder || x > rightBoder || y < leftBorder || y > rightBoder) {
                return false;
            }
            p = realToIndex(x, y);
            return board[p.X, p.Y] == 0;
        }

        private bool isGameOver(int x, int y, int playerColor) {
            int i, j;
            i = x - 1;
            j = y - 1;
            hSum = vSum = lSum = rSum = 1;
            while (i >= 0 && j >= 0) {
                if (board[i, j] == playerColor) {
                    lSum++;
                } else {
                    break;
                }
                i--;
                j--;
            }
            j = y - 1;
            while (j >= 0) {
                if (board[x, j] == playerColor) {
                    hSum++;
                } else {
                    break;
                }
                j--;
            }
            i = x + 1;
            j = y - 1;
            while (i < boardSize && j >= 0) {
                if (board[i, j] == playerColor) {
                    rSum++;
                } else {
                    break;
                }
                i++;
                j--;
            }
            i = x - 1;
            while (i >= 0) {
                if (board[i, y] == playerColor) {
                    vSum++;
                } else {
                    break;
                }
                i--;
            }
            i = x + 1;
            while (i < boardSize) {
                if (board[i, y] == playerColor) {
                    vSum++;
                } else {
                    break;
                }
                i++;
            }
            i = x - 1;
            j = y + 1;
            while (i >= 0 && j < boardSize) {
                if (board[i, j] == playerColor) {
                    rSum++;
                } else {
                    break;
                }
                i--;
                j++;
            }
            j = y + 1;
            while (j < boardSize) {
                if (board[x, j] == playerColor) {
                    hSum++;
                } else {
                    break;
                }
                j++;
            }
            i = x + 1;
            j = y + 1;
            while (i < boardSize && j < boardSize) {
                if (board[i, j] == playerColor) {
                    lSum++;
                } else {
                    break;
                }
                i++;
                j++;
            }
            return hSum >= 5 || vSum >= 5 || lSum >= 5 || rSum >= 5;
        }

        protected override void OnMouseClick(MouseEventArgs e) {
            if (isStart) {
                if (e.Button == MouseButtons.Left) {
                    Point p = new Point(0, 0);
                    if (isPointLegal(e.X, e.Y, ref p)) {
                        board[p.X, p.Y] = playerColor;
                        drawChess(indexToReal(p.X, p.Y), playerColor);
                        if (isGameOver(p.X, p.Y, playerColor)) {
                            OnGameOver(this, new GameOverEventArgs(playerColor));
                            isStart = false;
                        } else {
                            //切换玩家
                            playerColor = 3 - playerColor;
                        }
                    }
                }
            }
            base.OnMouseClick(e);
        }

        public void startGame() {
            drawBackground();
            board = new int[boardSize, boardSize];
            isStart = true;
        }
    }
}