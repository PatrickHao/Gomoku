﻿
namespace Gomoku {
    partial class MainForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStartGame = new System.Windows.Forms.Button();
            this.pBoxColor = new System.Windows.Forms.PictureBox();
            this.labelRoomID = new System.Windows.Forms.Label();
            this.board = new Gomoku.Board();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxColor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(12, 12);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(80, 32);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "新游戏";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // pBoxColor
            // 
            this.pBoxColor.Location = new System.Drawing.Point(506, 12);
            this.pBoxColor.Name = "pBoxColor";
            this.pBoxColor.Size = new System.Drawing.Size(33, 33);
            this.pBoxColor.TabIndex = 2;
            this.pBoxColor.TabStop = false;
            // 
            // labelRoomID
            // 
            this.labelRoomID.AutoSize = true;
            this.labelRoomID.Location = new System.Drawing.Point(369, 22);
            this.labelRoomID.Name = "labelRoomID";
            this.labelRoomID.Size = new System.Drawing.Size(29, 12);
            this.labelRoomID.TabIndex = 3;
            this.labelRoomID.Text = "NULL";
            // 
            // board
            // 
            this.board.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("board.BackgroundImage")));
            this.board.Location = new System.Drawing.Point(35, 66);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(504, 504);
            this.board.TabIndex = 1;
            this.board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.board_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 611);
            this.Controls.Add(this.labelRoomID);
            this.Controls.Add(this.pBoxColor);
            this.Controls.Add(this.board);
            this.Controls.Add(this.btnStartGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartGame;
        private Board board;
        private System.Windows.Forms.PictureBox pBoxColor;
        private System.Windows.Forms.Label labelRoomID;
    }
}

