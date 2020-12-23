﻿using StackExchange.Redis;
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
    public partial class StartForm : Form {
        public StartForm() {
            InitializeComponent();
            refreshList();
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
            MainForm m = new MainForm(roomID, playerColor);
            m.Show();
        }
    }
}
