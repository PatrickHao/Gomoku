using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {
    /// <summary>
    /// 玩家类
    /// </summary>
    public class PlayerOnline : Player {
        private ClientControl client;
        private int roomID;

        public PlayerOnline(int roomID, int playerColor, Board board) : base(playerColor, board) {
            this.client = new ClientControl();
            //连接服务器
            this.client.Connect("111.229.219.242", 12321);
            //this.client.Connect("127.0.0.1", 12321);
            if (playerColor != 3) {
                this.client.MessageProcess += message_Process1;
            } else {
                this.client.MessageProcess += message_Process2;
                state = false;
            }
            this.client.Send(roomID.ToString());
            this.RoomID = roomID;
            RedisHelper.updateRoomInfo(RoomID, PlayerColor, 0);
            startGame();
        }

        public int RoomID { get => roomID; set => roomID = value; }

        private void message_Process1(object sender, MessageProcessEventArgs e) {
            game.doMove(e.Message.Point.X, e.Message.Point.Y, e.Message.PlayerColor);
            board.drawChess(e.Message.Point.X, e.Message.Point.Y, e.Message.PlayerColor);
            //游戏是否结束
            if (e.Message.IsGameOver) {
                gameOver(e.Message.PlayerColor);
                isGameOver = true;
            }
            state = true;
        }

        private void message_Process2(object sender, MessageProcessEventArgs e) {
            game.doMove(e.Message.Point.X, e.Message.Point.Y, e.Message.PlayerColor);
            board.drawChess(e.Message.Point.X, e.Message.Point.Y, e.Message.PlayerColor);
            if (e.Message.IsGameOver) {
                gameOver(e.Message.PlayerColor);
                isGameOver = true;
            }
        }

        public override void playerAction(int x, int y) {
            if (state && !isGameOver) {
                Point p = new Point(0, 0);
                //当前位置为空
                if (board.getMousePoint(x, y, ref p) && game.isEmpty(p.X, p.Y)) {
                    //走棋
                    game.doMove(p.X, p.Y, PlayerColor);
                    board.drawChess(p.X, p.Y, PlayerColor);
                    //判断是否结束
                    if (game.isGameOver(p.X, p.Y, PlayerColor)) {
                        isGameOver = true;
                    }
                    //发送当前数据
                    Message message = new Message(PlayerColor, p, isGameOver);
                    string messageStr = JsonConvert.SerializeObject(message);
                    client.Send(messageStr);
                    //关闭走棋权限
                    state = false;
                    //触发游戏结束方法
                    if (isGameOver) {
                        gameOver(PlayerColor);
                    }
                }
            }
        }

        public override void startGame() {
            game.initBoard();
            board.initBoard();
            state = PlayerColor == 1;
            isGameOver = false;
        }

        public override void leaveRoom() {
            RedisHelper.updateRoomInfo(RoomID, PlayerColor, 1);
        }
    }
}