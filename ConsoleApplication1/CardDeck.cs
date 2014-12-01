using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class CardDeck
    {

        private Card[] deck;
        private int currentCard;
        private Random rand;
        private const int maxcards = 52;


        public CardDeck()
        {
            string[] values = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            deck = new Card[maxcards];
            rand = new Random();

            for (int i = 0; i < deck.Length; i++)
                deck[i] = new Card(values[i % 13], suits[i / 13]);

        }

        public int countCards()
        {

            return deck.Length;

        }

        public void shuffleDeck()
        {
            


        }
    }
}
