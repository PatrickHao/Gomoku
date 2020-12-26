using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class PlayerNumberException : ApplicationException {
        private string strMessage;

        public PlayerNumberException() : base() {
            this.strMessage = "请选择其它颜色棋子或观众";
        }

        public override string ToString() {
            return strMessage;
        }
    }
}
