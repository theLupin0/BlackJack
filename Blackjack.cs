using BlackJack.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Blackjack : Form
    {
        private BlackjackGameService game;

        public Blackjack()
        {
            InitializeComponent();
            this.Load += Blackjack_Load;
        }

        private void Blackjack_Load(object sender, EventArgs e)
        {
            try
            {
                game = new BlackjackGameService();
                if (game == null)
                {
                    throw new Exception("BlackjackGameService nesnesi oluşturulamadı!");
                }
                game.StartGame();
                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Oyun başlatılırken hata oluştu: {ex.Message}");
            }
        }

        private string SuitToChar(string s)
        {
            return s switch
            {
                "♠" => "S",
                "♥" => "H",
                "♦" => "D",
                "♣" => "C",
                _ => "X"
            };
        }

        private void UpdateUI()
        {
            if (game == null)
            {
                MessageBox.Show("Oyun servisi başlatılmadı!");
                return;
            }

            var playerHand = game.GetPlayerHand() ?? new List<Card>();
            var dealerHand = game.GetDealerHand(game.IsDealerRevealed()) ?? new List<Card>();

            lblPlayerCards.Text = "Oyuncu: " +
                string.Join(" ", playerHand.Select(c => c.Rank + c.Suit)) +
                $" (Toplam: {game.GetHandValue(playerHand)})";

            lblDealerCards.Text = "Krupiyer: " +
                string.Join(" ", dealerHand.Select(c => c.Rank + c.Suit)) +
                (game.IsDealerRevealed() ? $" (Toplam: {game.GetHandValue(dealerHand)})" : "");

            lblDeckRemaining.Text = $"Kalan Kart: {game.RemainingCards()}\nKartlar 10'dan az kalırsa karıştırılır";

            label1.Text = $"Cüzdan: {game.GetWallet()}";

            ShowCards(playerPanel, playerHand);
            ShowCards(dealerPanel, dealerHand, !game.IsDealerRevealed());
        }

        private void ShowCards(FlowLayoutPanel panel, List<Card> cards, bool hideSecondCard = false)
        {
            panel.Controls.Clear();
            if (cards == null)
            {
                return; // Kartlar null ise metodu sonlandır
            }

            for (int i = 0; i < cards.Count; i++)
            {
                PictureBox pic = new PictureBox
                {
                    Width = 90,
                    Height = 150,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                if (i == 1 && hideSecondCard)
                {
                    string backImagePath = Path.Combine(Application.StartupPath, "cards", "back.png");
                    try
                    {
                        pic.Image = Image.FromFile(backImagePath);
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show($"Arka yüz görseli bulunamadı: {backImagePath}\nHata: {ex.Message}");
                        pic.Image = null; // Hata durumunda boş bırak
                    }
                }
                else
                {
                    string cardFileName = $"{cards[i].Rank}{SuitToChar(cards[i].Suit)}.png"; // Örnek: "2H.png"
                    string cardImagePath = Path.Combine(Application.StartupPath, "cards", cardFileName);
                    try
                    {
                        pic.Image = Image.FromFile(cardImagePath);
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show($"Kart görseli bulunamadı: {cardImagePath}\nHata: {ex.Message}");
                        pic.Image = null; // Hata durumunda boş bırak
                    }
                }

                panel.Controls.Add(pic);
            }
        }

        private void StartNewGame()
        {
            if (game == null)
            {
                game = new BlackjackGameService();
            }
            game.StartGame();
            lblResult.Text = "";
            btnHit.Enabled = true;
            btnStand.Enabled = true;
            UpdateUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("Oyun servisi başlatılmadı!");
                return;
            }

            game.PlayerHit();
            UpdateUI();
            if (game.GetHandValue(game.GetPlayerHand()) > 21)
            {
                lblResult.Text = "Patladınız!";
                btnHit.Enabled = false;
                btnStand.Enabled = false;

                game.RevealDealerCards();
                UpdateUI();
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("Oyun servisi başlatılmadı!");
                return;
            }

            if (game.GetHandValue(game.GetPlayerHand()) <= 21)
            {
                game.DealerPlay();
            }
            lblResult.Text = game.GetResult();
            btnHit.Enabled = false;
            btnStand.Enabled = false;
            UpdateUI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void lblPlayerCards_Click(object sender, EventArgs e)
        {

        }
    }
}
