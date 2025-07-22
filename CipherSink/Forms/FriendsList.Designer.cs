namespace CipherSink
{
    partial class FriendsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FriendListLV = new ListView();
            label1 = new Label();
            RecentPlayersLV = new ListView();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            AddFriendBtn = new Button();
            SuspendLayout();
            // 
            // FriendListLV
            // 
            FriendListLV.Location = new Point(229, 197);
            FriendListLV.Name = "FriendListLV";
            FriendListLV.Size = new Size(184, 230);
            FriendListLV.TabIndex = 0;
            FriendListLV.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(242, 169);
            label1.Name = "label1";
            label1.Size = new Size(156, 25);
            label1.TabIndex = 1;
            label1.Text = "Current Friends:";
            // 
            // RecentPlayersLV
            // 
            RecentPlayersLV.Location = new Point(12, 197);
            RecentPlayersLV.Name = "RecentPlayersLV";
            RecentPlayersLV.Size = new Size(190, 230);
            RecentPlayersLV.TabIndex = 2;
            RecentPlayersLV.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(36, 169);
            label2.Name = "label2";
            label2.Size = new Size(145, 25);
            label2.TabIndex = 3;
            label2.Text = "Recent Players:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 33);
            label3.Name = "label3";
            label3.Size = new Size(128, 25);
            label3.TabIndex = 4;
            label3.Text = "Add a friend:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(386, 23);
            textBox1.TabIndex = 5;
            // 
            // AddFriendBtn
            // 
            AddFriendBtn.Location = new Point(292, 90);
            AddFriendBtn.Name = "AddFriendBtn";
            AddFriendBtn.Size = new Size(106, 50);
            AddFriendBtn.TabIndex = 6;
            AddFriendBtn.Text = "Add Friend";
            AddFriendBtn.UseVisualStyleBackColor = true;
            // 
            // FriendsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 450);
            Controls.Add(AddFriendBtn);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(RecentPlayersLV);
            Controls.Add(label1);
            Controls.Add(FriendListLV);
            Name = "FriendsList";
            Text = "Friends List";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView FriendListLV;
        private Label label1;
        private ListView RecentPlayersLV;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Button AddFriendBtn;
    }
}