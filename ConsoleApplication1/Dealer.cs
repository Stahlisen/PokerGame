using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Dealer 
    {

       CardDeck deck = new CardDeck();
       Game game;
       

        public Dealer(Game _game)
        {
            game = _game;
        }

        public CardDeck getDeck()
        {
            return deck;
        }

       
        public void startHand()
        {
            string card1 = getDeck().getTopCard();
            game.getPlayer().addToHand(card1);
            Console.WriteLine("First card:" + card1);
            

            string card2 = getDeck().getTopCard();
            game.getPlayer().addToHand(card2);
            Console.WriteLine("Second card: " + card2);

            Gamewindow game = new Gamewindow();



        }

        }
    }

