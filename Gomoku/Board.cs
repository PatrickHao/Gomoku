using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku {
    /// <summary>
    /// 棋盘以及棋子绘制相关类
    /// </summary>
    public class Board : Panel {

        private static Bitmap blackChess = Gomoku.Properties.Resources.blackChess;
        private static Bitmap whiteChess = Gomoku.Properties.Resources.whiteChess;
        //棋盘数据
        private const int boardSize = 15;
        private const int blockSize = 30;
        private const int delta = 42;
        private const int chessSize = 24;
        private const int controllerSize = (boardSize - 1) * blockSize + delta * 2;

        public Board() {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //双缓冲
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Size = new Size(controllerSize, controllerSize);
            drawBackground();
        }

        public void initBoard() {
            drawBackground();
        }

        private Point indexToReal(int x, int y) {
            int px = x * blockSize + delta;
            int py = y * blockSize + delta;
            return new Point(px, py);
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
            //根据棋盘尺寸画出相应数量的直线
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

        public void drawChess(int x, int y, int playerColor) {
            Point boardPoint = indexToReal(x, y);
            Bitmap bm = playerColor == 1 ? blackChess : whiteChess;
            Graphics g = Graphics.FromImage(this.BackgroundImage);
            //计算出棋子实际绘制位置
            boardPoint.X -= chessSize / 2;
            boardPoint.Y -= chessSize / 2;
            g.DrawImage(bm, boardPoint.X, boardPoint.Y, chessSize, chessSize);
            g.Dispose();
            this.Invalidate();
        }

        public bool getMousePoint(int x, int y, ref Point p) {
            int leftBorder = delta - blockSize / 2;
            int rightBoder = delta + (boardSize - 1) * blockSize + blockSize / 2;
            if (x < leftBorder || x > rightBoder || y < leftBorder || y > rightBoder) {
                return false;
            } else {
                p = realToIndex(x, y);
                return true;
            }
        }
    }
}