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
        private PlayerOnline player;

        public MainForm(int roomID, int playerColor) {
            InitializeComponent();
            player = new PlayerOnline(roomID, playerColor, true, board);
            player.OnGameOver += board_OnGameEnd;
            pBoxColor.SizeMode = PictureBoxSizeMode.Zoom;
            pBoxColor.Image = playerColor == 1 ? Gomoku.Properties.Resources.blackChess : Gomoku.Properties.Resources.whiteChess;
            labelRoomID.Text = "房间号:  " + roomID.ToString() + "  你的棋子";
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
