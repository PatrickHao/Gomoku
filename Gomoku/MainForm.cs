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
        private Player player;

        public MainForm(int playerColor) {
            InitializeComponent();
            player = new Player(0, playerColor, board);
        }

        private void board_OnGameEnd(object sender, GameOverEventArgs e) {
            MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK);
        }

        private void btnStartGame_Click(object sender, EventArgs e) {
            player.startGame();
        }

        private void board_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                player.playerAction(e.X, e.Y);
            }
        }
    }
}
