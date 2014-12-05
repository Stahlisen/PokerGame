using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class AIplayer : Player
    {

        public AIplayer()
        {
            this.name = "AI-Player";
        }

        public string getName()
        {
            return name;
        }

        public double getCurrentChips()
        {
            return currentchips;
        }
        public void setCurrentChips(double Chips)
        {
            currentchips = Chips;
        }

        public List<Card> getHand()
        {
            return hand;
        }

        public void addToHand(Card card)
        {
            hand.Add(card);



        }

    }
}
