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
        }

        private void button1_Click(object sender, EventArgs e) {
            int playerColor = cbPlayerColor.SelectedIndex + 1;
            MainForm m = new MainForm(playerColor);
            m.Show();
        }
    }
}
