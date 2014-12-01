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

        public Dealer()
        {

        }

        public CardDeck getDeck()
        {
            return deck;
        }



    }
}
