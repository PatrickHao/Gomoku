using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku {
    public partial class MainForm : Form {
        private Board board;

        public MainForm() {
            InitializeComponent();
            initGameBoard();
        }

        private void initGameBoard() {
            board = new Board();
            board.OnGameOver += board_OnGameEnd;
            this.Controls.Add(board);
            int x = (this.ClientRectangle.Width - board.Width) / 2;
            int y = (this.ClientRectangle.Height - board.Height) / 2;
            board.Left = x;
            board.Top = y;
        }

        private void board_OnGameEnd(object sender, GameOverEventArgs e) {
            MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK);
        }

        private void btnStartGame_Click(object sender, EventArgs e) {
            board.startGame();
        }
    }
}
