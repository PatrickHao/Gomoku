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
    public class Player {
        private ClientControl client;
        private Game game;
        private Board board;
        private int playerID;
        private int playerColor; //0->NULL, 1->blackChess, 2->whiteChess;
        private bool state = true;

        public event EventHandler<GameOverEventArgs> OnGameOver;

        public Player(int playerID, int playerColor, Board board) {
            this.client = new ClientControl();
            this.client.Connect("127.0.0.1", 12321);
            this.client.MessageProcess += message_Process;
            game = new Game();
            this.board = board;
            this.PlayerID = playerID;
            this.PlayerColor = playerColor;
            //this.client.MessageHandle += board.drawChess;
        }

        public int PlayerID { get => playerID; set => playerID = value; }
        public int PlayerColor { get => playerColor; set => playerColor = value; }

        private void message_Process(object sender, MessageProcessEventArgs e) {
            state = true;
            board.drawChess(e.Message.Point.X, e.Message.Point.Y, PlayerColor);
        }

        public void playerAction(int x, int y) {
            if (true) {
                Point p = new Point(0, 0);
                if (board.getMousePoint(x, y, ref p) && game.isEmpty(p.X, p.Y)) {
                    game.doMove(p.X, p.Y, PlayerColor);
                    board.drawChess(p.X, p.Y, PlayerColor);
                    //if (game.isGameOver(p.X, p.Y, PlayerColor)) {
                    //    //to process--state
                    //    Message message = new Message(PlayerColor, p);
                    //    string messageStr = JsonConvert.SerializeObject(message);
                    //    OnGameOver(this, new GameOverEventArgs(PlayerColor));
                    //} else {
                    //    //to process
                    //}
                    Message message = new Message(PlayerColor, p);
                    string messageStr = JsonConvert.SerializeObject(message);
                    client.Send(messageStr);
                    state = false;
                }
            }
        }

        public void startGame() {
            game.initBoard();
            board.initBoard();
        }
    }
}
