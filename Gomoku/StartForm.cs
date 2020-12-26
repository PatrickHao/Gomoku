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
        }

        private void refreshList() {
            listBoxRoom.Items.Clear();
            List<RoomInfo> roomInfoList = RedisHelper.getRoomList();
            foreach (RoomInfo roomInfo in roomInfoList) {
                //string elem = roomInfo.RoomID.ToString();
                //elem += ", 可选棋子： ";
                //elem += roomInfo.BlackPlayerNum == 0 ? "黑" : " ";
                //elem += roomInfo.WhitePlayerNum == 0 ? "白" : " ";
                listBoxRoom.Items.Add(roomInfo.RoomID.ToString());
            }
        }

        private void btnRoomAdd_Click(object sender, EventArgs e) {
            try {
                RoomInfo roomInfo = new RoomInfo(int.Parse(tbRoomID.Text), 0, 0, 0);
                RedisHelper.addRoomInfo(roomInfo);
            } catch {
                MessageBox.Show("房间号需为数字");
            }
            refreshList();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            try {
                int roomID = int.Parse(listBoxRoom.SelectedItem.ToString());
                int playerColor = cbPlayerColor.SelectedIndex + 1;
                if (!RedisHelper.judge(roomID, playerColor)) {
                    throw new PlayerNumberException();
                }
                MainForm m = new MainForm(roomID, playerColor, 0);
                m.FormClosing += show_Form;
                m.Show();
                this.Hide();
            } catch (NullReferenceException) {
                MessageBox.Show("请选择或创建房间");
            } catch (SocketException) {
                MessageBox.Show("服务器拒接连接");
            } catch (PlayerNumberException err) {
                MessageBox.Show(err.ToString());
            }
            //人机窗口--待开发
            //MainForm m = new MainForm(0, playerColor, 1);
        }

        private void show_Form(object sender, FormClosingEventArgs e) {
            this.Show();
            refreshList();
        }

        private void btnRefreshRoom_Click(object sender, EventArgs e) {
            refreshList();
        }
    }
}
