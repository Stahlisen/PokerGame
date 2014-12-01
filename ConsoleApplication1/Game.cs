using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Game
    {

        public double smallBlind, bigBlind;
        public double chips;
        Dealer dealer;
        Player player;
        

        public Game(double Chips, string name)
        {

          
            chips = Chips;
            smallBlind = chips / 10;
            bigBlind = chips / 10 * 2;
            player = new Player();
            player.setName(name);
            player.setCurrentChips(Chips);
            
            Dealer dealer = new Dealer(this);






        }
        //Getters and setters for small/bigblind and chips
        public double getSmallBlind()
        {
            return smallBlind;
        }
        public void setSmallBlind(double smallblind)
        {
            
            smallBlind = smallblind;
        }

        public double getBigBlind()
        {
            return bigBlind;
        }
        public void setBigBlind(double bigblind)
        {
            bigBlind = bigblind;
        }

        public double getChips()
        {
            return chips;
        }
        public void setChips(double chipss)
        {
            chips = chipss;

        }

        public Player getPlayer()
        {
            return player;
        }

        public Dealer getDealer()
        {

            return dealer;
        }
        

        
 
    }
}
