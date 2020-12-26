using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    public class RoomInfo {
        private int roomID;
        private int blackPlayerNum;
        private int whitePlayerNum;
        private int audienceNum;
        private int totalNum;

        public RoomInfo(int roomID, int blackPlayerNum, int whitePlayerNum, int audienceNum) {
            this.RoomID = roomID;
            this.BlackPlayerNum = blackPlayerNum;
            this.WhitePlayerNum = whitePlayerNum;
            this.AudienceNum = audienceNum;
            this.TotalNum = blackPlayerNum + whitePlayerNum + audienceNum;
        }

        public int RoomID { get => roomID; set => roomID = value; }
        public int BlackPlayerNum { get => blackPlayerNum; set => blackPlayerNum = value; }
        public int WhitePlayerNum { get => whitePlayerNum; set => whitePlayerNum = value; }
        public int AudienceNum { get => audienceNum; set => audienceNum = value; }
        public int TotalNum { get => totalNum; set => totalNum = value; }
    }
}
