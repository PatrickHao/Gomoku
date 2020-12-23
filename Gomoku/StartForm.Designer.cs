
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
            this.listBoxRoom = new System.Windows.Forms.ListBox();
            this.btnRoomAdd = new System.Windows.Forms.Button();
            this.tbRoomID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(271, 61);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(226, 214);
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
            this.cbPlayerColor.Location = new System.Drawing.Point(102, 58);
            this.cbPlayerColor.Name = "cbPlayerColor";
            this.cbPlayerColor.Size = new System.Drawing.Size(121, 20);
            this.cbPlayerColor.TabIndex = 1;
            this.cbPlayerColor.Text = "黑子";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "房间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "执方";
            // 
            // listBoxRoom
            // 
            this.listBoxRoom.FormattingEnabled = true;
            this.listBoxRoom.ItemHeight = 12;
            this.listBoxRoom.Location = new System.Drawing.Point(102, 113);
            this.listBoxRoom.Name = "listBoxRoom";
            this.listBoxRoom.Size = new System.Drawing.Size(121, 88);
            this.listBoxRoom.TabIndex = 4;
            // 
            // btnRoomAdd
            // 
            this.btnRoomAdd.Location = new System.Drawing.Point(146, 221);
            this.btnRoomAdd.Name = "btnRoomAdd";
            this.btnRoomAdd.Size = new System.Drawing.Size(86, 34);
            this.btnRoomAdd.TabIndex = 5;
            this.btnRoomAdd.Text = "添加房间";
            this.btnRoomAdd.UseVisualStyleBackColor = true;
            this.btnRoomAdd.Click += new System.EventHandler(this.btnRoomAdd_Click);
            // 
            // tbRoomID
            // 
            this.tbRoomID.Location = new System.Drawing.Point(40, 229);
            this.tbRoomID.Name = "tbRoomID";
            this.tbRoomID.Size = new System.Drawing.Size(100, 21);
            this.tbRoomID.TabIndex = 6;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 326);
            this.Controls.Add(this.tbRoomID);
            this.Controls.Add(this.btnRoomAdd);
            this.Controls.Add(this.listBoxRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPlayerColor);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbPlayerColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxRoom;
        private System.Windows.Forms.Button btnRoomAdd;
        private System.Windows.Forms.TextBox tbRoomID;
    }
}