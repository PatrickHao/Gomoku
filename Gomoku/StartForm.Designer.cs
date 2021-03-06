﻿
namespace Gomoku {
    partial class StartForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnStart = new System.Windows.Forms.Button();
            this.cbPlayerColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRoomAdd = new System.Windows.Forms.Button();
            this.tbRoomID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGameMode = new System.Windows.Forms.ComboBox();
            this.listBoxRoom = new System.Windows.Forms.ListBox();
            this.btnRefreshRoom = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(314, 299);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(86, 42);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbPlayerColor
            // 
            this.cbPlayerColor.FormattingEnabled = true;
            this.cbPlayerColor.Items.AddRange(new object[] {
            "黑子",
            "白子",
            "观战"});
            this.cbPlayerColor.Location = new System.Drawing.Point(314, 22);
            this.cbPlayerColor.Name = "cbPlayerColor";
            this.cbPlayerColor.Size = new System.Drawing.Size(121, 20);
            this.cbPlayerColor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "房间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "执方";
            // 
            // btnRoomAdd
            // 
            this.btnRoomAdd.Location = new System.Drawing.Point(282, 238);
            this.btnRoomAdd.Name = "btnRoomAdd";
            this.btnRoomAdd.Size = new System.Drawing.Size(69, 27);
            this.btnRoomAdd.TabIndex = 5;
            this.btnRoomAdd.Text = "添加房间";
            this.btnRoomAdd.UseVisualStyleBackColor = true;
            this.btnRoomAdd.Click += new System.EventHandler(this.btnRoomAdd_Click);
            // 
            // tbRoomID
            // 
            this.tbRoomID.Location = new System.Drawing.Point(314, 206);
            this.tbRoomID.Name = "tbRoomID";
            this.tbRoomID.Size = new System.Drawing.Size(121, 21);
            this.tbRoomID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "模式";
            // 
            // cbGameMode
            // 
            this.cbGameMode.FormattingEnabled = true;
            this.cbGameMode.Items.AddRange(new object[] {
            "人人",
            "人机"});
            this.cbGameMode.Location = new System.Drawing.Point(315, 58);
            this.cbGameMode.Name = "cbGameMode";
            this.cbGameMode.Size = new System.Drawing.Size(121, 20);
            this.cbGameMode.TabIndex = 7;
            // 
            // listBoxRoom
            // 
            this.listBoxRoom.FormattingEnabled = true;
            this.listBoxRoom.ItemHeight = 12;
            this.listBoxRoom.Location = new System.Drawing.Point(314, 97);
            this.listBoxRoom.Name = "listBoxRoom";
            this.listBoxRoom.Size = new System.Drawing.Size(121, 88);
            this.listBoxRoom.TabIndex = 9;
            // 
            // btnRefreshRoom
            // 
            this.btnRefreshRoom.Location = new System.Drawing.Point(366, 238);
            this.btnRefreshRoom.Name = "btnRefreshRoom";
            this.btnRefreshRoom.Size = new System.Drawing.Size(69, 27);
            this.btnRefreshRoom.TabIndex = 10;
            this.btnRefreshRoom.Text = "刷新列表";
            this.btnRefreshRoom.UseVisualStyleBackColor = true;
            this.btnRefreshRoom.Click += new System.EventHandler(this.btnRefreshRoom_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gomoku.Properties.Resources.welcomePage;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 346);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 373);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRefreshRoom);
            this.Controls.Add(this.btnRoomAdd);
            this.Controls.Add(this.cbPlayerColor);
            this.Controls.Add(this.tbRoomID);
            this.Controls.Add(this.listBoxRoom);
            this.Controls.Add(this.cbGameMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartForm";
            this.Text = "StartForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbPlayerColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRoomAdd;
        private System.Windows.Forms.TextBox tbRoomID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGameMode;
        private System.Windows.Forms.ListBox listBoxRoom;
        private System.Windows.Forms.Button btnRefreshRoom;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}