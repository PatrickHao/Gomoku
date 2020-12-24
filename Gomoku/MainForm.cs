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
            btnStartGame.Enabled = false;
            player = new PlayerOnline(roomID, playerColor, board);
            player.OnGameOver += board_OnGameEnd;
            pBoxColor.SizeMode = PictureBoxSizeMode.Zoom;
            labelRoomID.Text = "房间号:  " + roomID.ToString() + "  你的棋子";
            if (playerColor == 1) {
                pBoxColor.Image = Gomoku.Properties.Resources.blackChess;
            } else if (playerColor == 2){
                pBoxColor.Image = Gomoku.Properties.Resources.whiteChess;
            } else {
                labelRoomID.Text = "房间号:  " + roomID.ToString() + "  你是观众";
            }
            
        }

        private void board_OnGameEnd(object sender, GameOverEventArgs e) {
            MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK);
            btnStartGame.Enabled = true;
        }

        private void btnStartGame_Click(object sender, EventArgs e) {
            player.startGame();
            btnStartGame.Enabled = false;
        }

        private void board_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                player.playerAction(e.X, e.Y);
            }
        }
    }
}
