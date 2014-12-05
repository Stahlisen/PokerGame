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
        Humanplayer player;
        AIplayer aiplayer;
        public int roundcounter = 0;
        List<string> smallblinds = new List<string>();
        Gamewindow gamewindow;
        
        

        public Game(double Chips, string name)
        {
            chips = Chips;
            smallBlind = chips / 10;
            bigBlind = chips / 10 * 2;
            player = new Humanplayer();
            player.setName(name);
            player.setCurrentChips(Chips);
            aiplayer = new AIplayer();
            aiplayer.setCurrentChips(Chips);

            dealer = new Dealer(this);
            
        }

        public void initiateGameWindow(Gamewindow gw) {

            gamewindow = gw;
        }

        public string getBlindTurn()
        {
            if (roundcounter % 2 == 0)
            {
                return "player";
            }
            else
            {
                return "ai";
            }
        }
        public void newRound()
        {
            roundcounter++;
            Console.WriteLine("Round: " + roundcounter);
            blindBet();

            
        }

        public void blindBet()
        {

            if (getBlindTurn() == "ai")
            {
                Console.WriteLine("Helooo");
                //Subtract big blind from humanplayer
                getPlayer().setCurrentChips(getPlayer().getCurrentChips() - bigBlind);
                gamewindow.player1chips_label.Text = Convert.ToString(getPlayer().getCurrentChips());
                Console.WriteLine(getPlayer().getCurrentChips());

                //Subtract small blind from aiplayer
                getAiPlayer().setCurrentChips(getAiPlayer().getCurrentChips() - smallBlind);
                gamewindow.aiplayerchips_label.Text = Convert.ToString(getAiPlayer().getCurrentChips());
                Console.WriteLine(getAiPlayer().getCurrentChips());

                gamewindow.player1chips_label.Refresh();
                gamewindow.aiplayerchips_label.Refresh();

                
            }
            else
            {
                Console.WriteLine("Aiplayers smallblind");
            }
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

        public Humanplayer getPlayer()
        {
            return player;
        }

        public AIplayer getAiPlayer()
        {
            return aiplayer;
        }

        public Dealer getDealer()
        {

            return dealer;
        }

    }
}
