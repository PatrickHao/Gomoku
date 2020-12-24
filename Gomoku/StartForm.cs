using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku {
    public partial class StartForm : Form {
        public StartForm() {
            InitializeComponent();
            refreshList();
            cbPlayerColor.SelectedIndex = 0;
            cbGameMode.SelectedIndex = 0;
            listBoxRoom.SelectedIndex = 0;

        }

        private void refreshList() {
            listBoxRoom.Items.Clear();
            List<string> roomIDList = RedisHelper.getRoomList();
            foreach (string roomID in roomIDList) {
                listBoxRoom.Items.Add(roomID);
            }
        }

        private void btnRoomAdd_Click(object sender, EventArgs e) {
            try {
                RedisHelper.addRoomID(int.Parse(tbRoomID.Text));
            } catch {
                MessageBox.Show("房间号需为数字");
            }
            refreshList();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            int roomID = int.Parse(listBoxRoom.SelectedItem.ToString());
            int playerColor = cbPlayerColor.SelectedIndex + 1;
            if (cbGameMode.SelectedIndex == 0) {
                try {
                    MainForm m = new MainForm(roomID, playerColor, 0);
                    m.FormClosing += show_Form;
                    m.Show();
                    this.Hide();
                } catch (SocketException) {
                    MessageBox.Show("服务器连接拒绝");
                }
            } else {
                MainForm m = new MainForm(0, playerColor, 1);
                m.FormClosing += show_Form;
                m.Show();
                this.Hide();
            }
        }

        private void show_Form(object sender, FormClosingEventArgs e) {
            this.Show();
        }
    }
}
