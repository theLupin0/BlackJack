namespace BlackJack
{
    partial class Blackjack
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
            panel1 = new Panel();
            playerPanel = new FlowLayoutPanel();
            dealerPanel = new FlowLayoutPanel();
            button2 = new Button();
            lblDeckRemaining = new Label();
            button1 = new Button();
            btnHit = new Button();
            btnStand = new Button();
            lblDealerCards = new Label();
            lblResult = new Label();
            lblPlayerCards = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(playerPanel);
            panel1.Controls.Add(dealerPanel);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(lblDeckRemaining);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnHit);
            panel1.Controls.Add(btnStand);
            panel1.Controls.Add(lblDealerCards);
            panel1.Controls.Add(lblResult);
            panel1.Controls.Add(lblPlayerCards);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1116, 614);
            panel1.TabIndex = 11;
            // 
            // playerPanel
            // 
            playerPanel.Location = new Point(671, 54);
            playerPanel.Name = "playerPanel";
            playerPanel.Size = new Size(411, 532);
            playerPanel.TabIndex = 9;
            // 
            // dealerPanel
            // 
            dealerPanel.Location = new Point(38, 54);
            dealerPanel.Name = "dealerPanel";
            dealerPanel.Size = new Size(407, 532);
            dealerPanel.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(512, 551);
            button2.Name = "button2";
            button2.Size = new Size(73, 35);
            button2.TabIndex = 7;
            button2.Text = "Çık";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblDeckRemaining
            // 
            lblDeckRemaining.AutoSize = true;
            lblDeckRemaining.Location = new Point(486, 18);
            lblDeckRemaining.Name = "lblDeckRemaining";
            lblDeckRemaining.Size = new Size(66, 15);
            lblDeckRemaining.TabIndex = 6;
            lblDeckRemaining.Text = "Kalan Kart: ";
            // 
            // button1
            // 
            button1.Location = new Point(499, 463);
            button1.Name = "button1";
            button1.Size = new Size(102, 54);
            button1.TabIndex = 5;
            button1.Text = "Yeni Oyun";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnHit
            // 
            btnHit.Location = new Point(499, 146);
            btnHit.Name = "btnHit";
            btnHit.Size = new Size(102, 54);
            btnHit.TabIndex = 4;
            btnHit.Text = "Kart çek (Hit)";
            btnHit.UseVisualStyleBackColor = true;
            btnHit.Click += btnHit_Click;
            // 
            // btnStand
            // 
            btnStand.Location = new Point(499, 70);
            btnStand.Name = "btnStand";
            btnStand.Size = new Size(102, 54);
            btnStand.TabIndex = 3;
            btnStand.Text = "Dur (Stand)";
            btnStand.UseVisualStyleBackColor = true;
            btnStand.Click += btnStand_Click;
            // 
            // lblDealerCards
            // 
            lblDealerCards.AutoSize = true;
            lblDealerCards.Location = new Point(183, 36);
            lblDealerCards.Name = "lblDealerCards";
            lblDealerCards.Size = new Size(90, 15);
            lblDealerCards.TabIndex = 2;
            lblDealerCards.Text = "Kurpiyer kartları";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResult.Location = new Point(486, 355);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(165, 15);
            lblResult.TabIndex = 1;
            lblResult.Text = "Kazanma-kaybetme sonucu";
            // 
            // lblPlayerCards
            // 
            lblPlayerCards.AutoSize = true;
            lblPlayerCards.Location = new Point(835, 36);
            lblPlayerCards.Name = "lblPlayerCards";
            lblPlayerCards.Size = new Size(109, 15);
            lblPlayerCards.TabIndex = 0;
            lblPlayerCards.Text = "Oyuncunun kartları";
            lblPlayerCards.Click += lblPlayerCards_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(486, 252);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 10;
            label1.Text = "Cüzdan: ";
            // 
            // Blackjack
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 644);
            Controls.Add(panel1);
            Name = "Blackjack";
            Text = "Blackjack";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel playerPanel;
        private FlowLayoutPanel dealerPanel;
        private Button button2;
        private Label lblDeckRemaining;
        private Button button1;
        private Button btnHit;
        private Button btnStand;
        private Label lblDealerCards;
        private Label lblResult;
        private Label lblPlayerCards;
        private Label label1;
    }
}