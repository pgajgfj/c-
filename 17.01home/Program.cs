using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17._01home
{
    class Game
    {
        private List<Player> players;
        private List<Karta> deck;
        private Random random;

        public Game()
        {
            players = new List<Player>();
            deck = new List<Karta>();
            random = new Random();

            // Створення колоди з 36 карток
            string[] suits = { "Піки", "Чирва", "Бубна", "Крести" };
            string[] values = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    deck.Add(new Karta(suit, value));
                }
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void ShuffleDeck()
        {
            
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Karta value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        public void DealCards()
        {
            ShuffleDeck();
            int numPlayers = players.Count;
            int cardsPerPlayer = deck.Count / numPlayers;

            for (int i = 0; i < numPlayers; i++)
            {
                List<Karta> hand = new List<Karta>();
                for (int j = 0; j < cardsPerPlayer; j++)
                {
                    hand.Add(deck[j * numPlayers + i]);
                }
                players[i].SetHand(hand);
            }
        }

        public void Play()
        {
            while (!IsGameOver())
            {
                List<Karta> cardsOnTable = new List<Karta>();
                foreach (Player player in players)
                {
                    if (player.GetHand().Count > 0)
                    {
                        Karta playedCard = player.PlayCard();
                        if (playedCard != null)
                        {
                            cardsOnTable.Add(playedCard);
                        }
                    }
                }

                Player winner = DetermineRoundWinner(cardsOnTable);
                if (winner != null)
                {
                    winner.AddCardsToHand(cardsOnTable);
                }

            }

            Player gameWinner = DetermineGameWinner();
            Console.WriteLine($"Гравець {gameWinner.GetName()} виграв гру!");
        }

        private Player DetermineRoundWinner(List<Karta> cardsOnTable)
        {
            Player roundWinner = null;
            Karta highestCard = null;

            foreach (Karta card in cardsOnTable)
            {
                if (highestCard == null || card.GetValue() > highestCard.GetValue())
                {
                    highestCard = card;
                }
            }

            foreach (Player player in players)
            {
                if (player.HasCard(highestCard))
                {
                    roundWinner = player;
                    break;
                }
            }

            return roundWinner;
        }

        private Player DetermineGameWinner()
        {
            Player gameWinner = players[0];
            foreach (Player player in players)
            {
                if (player.GetHand().Count > gameWinner.GetHand().Count)
                {
                    gameWinner = player;
                }
            }
            return gameWinner;
        }

        private bool IsGameOver()
        {
            foreach (Player player in players)
            {
                if (player.GetHand().Count == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Player
    {
        private string name;
        private List<Karta> hand;

        public Player(string name)
        {
            this.name = name;
            hand = new List<Karta>();
        }

        public void SetHand(List<Karta> cards)
        {
            hand = cards;
        }

        public string GetName()
        {
            return name;
        }

        public List<Karta> GetHand()
        {
            return hand;
        }

        public Karta PlayCard()
        {
            if (hand.Count > 0)
            {
                Karta playedCard = hand[0];
                hand.RemoveAt(0);
                return playedCard;
            }
            else
            {
                return null;
            }
        }

        public bool HasCard(Karta card)
        {
            return hand.Contains(card);
        }

        public void AddCardsToHand(List<Karta> cards)
        {
            hand.AddRange(cards);
        }
    }

    class Karta
    {
        private string suit;
        private string value;

        public Karta(string suit, string value)
        {
            this.suit = suit;
            this.value = value;
        }

        public int GetValue()
        {
            string[] values = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
            for (int i = 0; i < values.Length; i++)
            {
                if (value == values[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Player player1 = new Player("Гравець 1");
            Player player2 = new Player("Гравець 2");
            game.AddPlayer(player1);
            game.AddPlayer(player2);
            game.DealCards();
            game.Play();
        }
    }
}
