using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class RoomIDExistException : ApplicationException {
        private string strMessage;

        public RoomIDExistException() : base() {
            this.strMessage = "当前房间号已存在";
        }

        public override string ToString() {
            return strMessage;
        }
    }
}
