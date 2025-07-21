using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{

    public class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }

        public Card(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }
        public override string ToString() => $"{Rank}{Suit}";
    }

    public class Deck
    {
        private List<Card> cards;
        private Random rnd = new Random();

        public Deck()
        {
            cards = new List<Card>();
            string[] suits = { "♠", "♥", "♦", "♣" };
            string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K",
                               "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K",
                               "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K",
                               "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"
                             };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card(rank, suit));
                }
            }

            Shuffle();
        }

        public void Shuffle() {
            cards = cards.OrderBy(c => rnd.Next()).ToList();
        }

        public Card DrawCard()
        {
            if(cards.Count == 0)
                throw new InvalidOperationException("Deste Boş!");

            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        public int ReaminingCards => cards.Count;
    }


    public class BlackjackGameService
    {
        private Deck deck = new Deck();
        private List<Card> playerHand;
        private List<Card> dealerHand;
        private bool isDealerRevealed = false;
        private int Wallet = 10000;
        private bool hasBet = false;

        public void StartGame()
        {
            if (deck.ReaminingCards < 10)
            {
                deck = new Deck();
            }
            playerHand = new List<Card>();
            dealerHand = new List<Card>();

            if (Wallet >= 200)
            {
                Wallet -= 200;
                hasBet = true;
            }
            else
            {
                throw new InvalidOperationException("Yetersiz bakiye!");
            }

            playerHand.Add(deck.DrawCard());
            playerHand.Add(deck.DrawCard());

            dealerHand.Add(deck.DrawCard());
            dealerHand.Add(deck.DrawCard());
            isDealerRevealed = false;
        }

        public void PlayerHit()
        {
            playerHand.Add(deck.DrawCard());
        }

        public void DealerPlay()
        {
            isDealerRevealed = true;
            while (GetHandValue(dealerHand) < 17)
            {
                dealerHand.Add(deck.DrawCard());
            }
        }

        public List<Card> GetPlayerHand() => playerHand;
        public List<Card> GetDealerHand(bool reveal = false)
        {
            if (reveal || isDealerRevealed)
                return dealerHand;

            //Hide Second Card of Dealer
            return new List<Card>
            {
                dealerHand[0],
                new Card ("?","?")
            };
        }

        public int GetHandValue(List<Card> hand)
        {
            int total = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                if (int.TryParse(card.Rank, out int val))
                    total += val;
                else if (card.Rank == "A")
                {
                    aceCount++;
                    total += 11;
                }
                else
                    total += 10;
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }

        public string GetResult()
        {
            UserService userService = new UserService();
            var logger = new LogService();

            int playerTotal = GetHandValue(playerHand);
            int dealerTotal = GetHandValue(dealerHand);

            if (!hasBet)
            {
                return "Bahis yapılmadı!";
            }

            if (playerTotal > 21)
            {
                logger.gameBlackjackLog($"Oyuncu Kaybetti: -200TL Oyuncu:{playerTotal} - Kurpiyer:{dealerTotal}");
                hasBet = false;
                return "Patladınız! -200TL";
            }
            if (dealerTotal > 21)
            {
                logger.gameBlackjackLog($"Oyuncu Kazandı: +400TL Oyuncu:{playerTotal} - Kurpiyer:{dealerTotal}");
                Wallet += 400;
                hasBet = false;
                return "Krupiye patladı, kazandınız! +400TL";
            }

            if (playerTotal > dealerTotal)
            {
                logger.gameBlackjackLog($"Oyuncu Kazandı: +400TL Oyuncu:{playerTotal} - Kurpiyer:{dealerTotal}");
                Wallet += 400;
                hasBet = false;
                return "Kazandınız! +400TL";
            }

            if (dealerTotal > playerTotal)
            {
                logger.gameBlackjackLog($"Oyuncu Kaybetti: -200TL Oyuncu:{playerTotal} - Kurpiyer:{dealerTotal}");
                hasBet = false;
                return "Kaybettiniz! -200TL";
            }

            logger.gameBlackjackLog($"Oyun Berabere Oyuncu:{playerTotal} - Kurpiyer:{dealerTotal}");
            Wallet += 200;
            hasBet = false;
            return "Berabere! Bahis iade edildi.";
        }

        public int GetWallet()
        {
            return Wallet;
        }

        public int RemainingCards()
        {
            return deck.ReaminingCards;
        }

        public bool IsDealerRevealed()
        {
            return isDealerRevealed;
        }

        public void RevealDealerCards()
        {
            isDealerRevealed = true;
        }
    }
}
