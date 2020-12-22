using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class MessageProcessEventArgs : EventArgs {
        private Message message;

        public MessageProcessEventArgs(Message message) {
            this.Message = message;
        }

        public Message Message { get => message; set => message = value; }
    }
}
