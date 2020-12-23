﻿using Newtonsoft.Json;
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
        public event EventHandler<GameOverEventArgs> OnGameOver;

        public PlayerOnline(int roomID, int playerColor, bool playerMode, Board board) : base(playerColor, playerMode, board) {
            this.client = new ClientControl();
            this.client.Connect("111.229.219.242", 12321);
            if (playerMode) {
                this.client.MessageProcess += message_Process1;
            } else {
                this.client.MessageProcess += message_Process2;
            }
            this.client.Send(roomID.ToString());
            this.state = playerColor == 1;
            this.RoomID = roomID;
        }

        public int RoomID { get => roomID; set => roomID = value; }

        private void message_Process1(object sender, MessageProcessEventArgs e) {
            if (e.Message.IsGameOver) {
                OnGameOver(this, new GameOverEventArgs(3 - playerColor));
                isGameOver = true;
            }
            state = true;
            board.drawChess(e.Message.Point.X, e.Message.Point.Y, 3 - PlayerColor);
        }

        private void message_Process2(object sender, MessageProcessEventArgs e) {
            board.drawChess(e.Message.Point.X, e.Message.Point.Y, e.Message.PlayerColor);
        }

        public override void playerAction(int x, int y) {
            if (state && !isGameOver && playerMode) {
                Point p = new Point(0, 0);
                if (board.getMousePoint(x, y, ref p) && game.isEmpty(p.X, p.Y)) {
                    game.doMove(p.X, p.Y, PlayerColor);
                    board.drawChess(p.X, p.Y, PlayerColor);
                    if (game.isGameOver(p.X, p.Y, PlayerColor)) {
                        isGameOver = true;
                    }
                    Message message = new Message(PlayerColor, p, isGameOver);
                    string messageStr = JsonConvert.SerializeObject(message);
                    client.Send(messageStr);
                    state = false;
                    if (isGameOver) {
                        OnGameOver(this, new GameOverEventArgs(playerColor));
                    }
                }
            }
        }

        public void startGame() {
            game.initBoard();
            board.initBoard();
        }
    }
}
