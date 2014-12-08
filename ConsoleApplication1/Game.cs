using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        double currentpot = 0;
        String playersturn = "player";
        double currentbet = 0;
        bool starthand = false;
        bool flop = false;
        bool turn = false;
        bool river = false;
        string path = @"..\cards\";
        Gameanalyzer gameanalyzer = new Gameanalyzer();
        
        

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

        public string getSmallBlindTurn()
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
            currentbet = 0;
            currentpot = 0;
            gamewindow.changeLabel(gamewindow.aiplayerchips_label, Convert.ToString(getAiPlayer().getCurrentChips()));
            gamewindow.changeLabel(gamewindow.player1chips_label, Convert.ToString(getPlayer().getCurrentChips()));
            gamewindow.changeLabel(gamewindow.player_bet_amount, "");
            gamewindow.changeLabel(gamewindow.aiplayer_bet_amount, "");
            gamewindow.changeLabel(gamewindow.currentpot, "");

            resetCards(); 
            roundcounter++;
            Console.WriteLine("Round: " + roundcounter);
            starthand = false;
            flop = false;
            turn = false;
            river = false;
            
            nextCards();
            Console.WriteLine("newRound");
            

        }

        public void resetCards()
        {
            Console.WriteLine("Reset");
            getPlayer().getHand().Clear();
            getAiPlayer().getHand().Clear();
            string backcard = "BackofCard.png";
            string path_backcard = Path.Combine(path, backcard);

            gamewindow.changePictureBox(gamewindow.player_card1, path_backcard);
            gamewindow.changePictureBox(gamewindow.player_card2, path_backcard);
            gamewindow.changePictureBox(gamewindow.ai_card1, path_backcard);
            gamewindow.changePictureBox(gamewindow.ai_card2, path_backcard);
            gamewindow.changePictureBox(gamewindow.flop_1, path_backcard);
            gamewindow.changePictureBox(gamewindow.flop_2, path_backcard);
            gamewindow.changePictureBox(gamewindow.flop_3, path_backcard);
            gamewindow.changePictureBox(gamewindow.turn, path_backcard);
            gamewindow.changePictureBox(gamewindow.river, path_backcard);
        }

        public void nextCards()
        {
            if (!starthand)
            {
                Console.WriteLine("NextCards");
                blindBet();
                starthand = true;
                getDealer().startHand();
                playSession(playersturn);
            }
            else if (starthand & !flop)
            {
                flop = true;
                getDealer().flop();
                playSession(playersturn);

            }
            else if (starthand & flop & !turn)
            {
                turn = true;
                getDealer().turn();
                playSession(playersturn);
            }
            else if (starthand & flop & turn & !river)
            {
                river = true;
                getDealer().river();
                playSession(playersturn);
            }
            else if (starthand & flop & turn & river)
            {
                result();
            }
        }

        public void blindBet()
        {

            if (getSmallBlindTurn() == "ai")
            {
                Console.WriteLine("Ai Player has smallblind");
                //Subtract big blind from humanplayer
                getPlayer().setCurrentChips(getPlayer().getCurrentChips() - bigBlind);
                gamewindow.changeLabel(gamewindow.player1chips_label, Convert.ToString(getPlayer().getCurrentChips()));
                Console.WriteLine(getPlayer().getCurrentChips());
                double playerbet = bigBlind;

                //Subtract small blind from aiplayer
                getAiPlayer().setCurrentChips(getAiPlayer().getCurrentChips() - smallBlind);
                gamewindow.changeLabel(gamewindow.aiplayerchips_label, Convert.ToString(getAiPlayer().getCurrentChips()));
                Console.WriteLine(getAiPlayer().getCurrentChips());
                double aibet = smallBlind;
                currentbet = aibet + playerbet;
                gatherPot();
                currentbet = 0;

                gamewindow.player1chips_label.Refresh();
                gamewindow.aiplayerchips_label.Refresh();
                
                

                
            }
            else
            {
                Console.WriteLine("Player has smallblind");
                //Subtract big blind from humanplayer
                getAiPlayer().setCurrentChips(getAiPlayer().getCurrentChips() - bigBlind);
                gamewindow.changeLabel(gamewindow.aiplayerchips_label, Convert.ToString(getAiPlayer().getCurrentChips()));
                Console.WriteLine(getAiPlayer().getCurrentChips());
                double aibet = bigBlind;

                //Subtract small blind from aiplayer
                getPlayer().setCurrentChips(getPlayer().getCurrentChips() - smallBlind);
                gamewindow.changeLabel(gamewindow.player1chips_label, Convert.ToString(getPlayer().getCurrentChips()));
                Console.WriteLine(getPlayer().getCurrentChips());
                double playerbet = smallBlind;
                currentbet = aibet + playerbet;
                gatherPot();
                

                gamewindow.player1chips_label.Refresh();
                gamewindow.aiplayerchips_label.Refresh(); 
            }

            gamewindow.showEvent("Players made blinds " + smallBlind + "/" + bigBlind);
        }

        public void gatherPot()
        {
            currentpot = currentpot + currentbet;
            gamewindow.currentpot.Text = Convert.ToString(currentpot);
            currentbet = 0;
            gamewindow.changeLabel(gamewindow.player_bet_amount, "");
            gamewindow.changeLabel(gamewindow.aiplayer_bet_amount, "");

        }

        public void playerDidBet()
        {
            if (playersturn == "player")
            {
                if (gamewindow.bet_amount.Value > 0)
                {
                    gamewindow.player_bet_amount.Text = Convert.ToString(gamewindow.bet_amount.Value);
                    gamewindow.showEvent(getPlayersTurn() + " betted " + gamewindow.bet_amount.Value);
                    getPlayer().setCurrentChips(getPlayer().getCurrentChips() - Convert.ToDouble(gamewindow.bet_amount.Value));
                    gamewindow.changeLabel(gamewindow.player1chips_label, Convert.ToString(getPlayer().getCurrentChips()));
                    currentbet = currentbet + Convert.ToDouble(gamewindow.bet_amount.Value);
                    playersturn = "aiplayer";
                    playerOnHold();

                    if (currentbet == Convert.ToDouble(gamewindow.bet_amount.Value))
                    {
                        playSession(playersturn);
                    }
                    else
                    {
                        Console.WriteLine("Player has raised");
                    }
                }
                else
                {
                    gamewindow.showMessage("Bet has to be higher than 0");
                }

                
            }
            else
            {
                if (gamewindow.bet_amount_ai.Value > 0)
                {
                    gamewindow.aiplayer_bet_amount.Text = Convert.ToString(gamewindow.bet_amount_ai.Value);
                    gamewindow.showEvent(getPlayersTurn() + " betted " + gamewindow.bet_amount_ai.Value);
                    getPlayer().setCurrentChips(getAiPlayer().getCurrentChips() - Convert.ToDouble(gamewindow.bet_amount_ai.Value));
                    gamewindow.changeLabel(gamewindow.aiplayerchips_label, Convert.ToString(getAiPlayer().getCurrentChips()));
                    currentbet = Convert.ToDouble(gamewindow.bet_amount_ai.Value);
                    playersturn = "player";
                    playerOnHold();

                    if (currentbet == Convert.ToDouble(gamewindow.bet_amount_ai.Value))
                    {
                        playSession(playersturn);
                    }
                }
                else
                {
                    gamewindow.showMessage("Bet has to be higher than 0");
                }
            }
        }

        public void playerDidCall()
        {
            gamewindow.showEvent(getPlayersTurn() + " called " + currentbet);

            if (playersturn == "aiplayer")
            {
                gamewindow.aiplayer_bet_amount.Text = Convert.ToString(currentbet);
                getAiPlayer().setCurrentChips(getAiPlayer().getCurrentChips() - currentbet);
                gamewindow.changeLabel(gamewindow.aiplayerchips_label, Convert.ToString(getAiPlayer().getCurrentChips()));
                currentbet = currentbet + currentbet;
                gatherPot();
                playersturn = "player";
                playerOnHold();
                nextCards();
            }
            else
            {
                gamewindow.player_bet_amount.Text = Convert.ToString(currentbet);
                getPlayer().setCurrentChips(getPlayer().getCurrentChips() - currentbet);
                gamewindow.changeLabel(gamewindow.player1chips_label, Convert.ToString(getPlayer().getCurrentChips()));
                currentbet = currentbet + currentbet;
                gatherPot();
                playersturn = "aiplayer";
                playerOnHold();
                nextCards();
            }
        }

        public void playSession(string playerturn)
        {

            if (playerturn == "player")
            {
                if (currentbet > 0)
                {
                    //If the current bet is higher than 0, means that the AIPlayer has betted and the player can only call with the same amount.
                    gamewindow.call_button.Text = "Call " + currentbet;
                    gamewindow.check_button.Enabled = false;
                    gamewindow.fold_button.Enabled = true;
                    gamewindow.bet_button.Enabled = false;
                    gamewindow.call_button.Enabled = true;
                    gamewindow.bet_amount.Maximum = Convert.ToDecimal(getPlayer().getCurrentChips());

                }
                else
                {
                    //If the current bet is 0, the player is starting he can either bet, check or fold. 
                    gamewindow.bet_button.Enabled = true;
                    gamewindow.fold_button.Enabled = true;
                    gamewindow.check_button.Enabled = true;
                    gamewindow.bet_amount.Enabled = true;
                    gamewindow.bet_amount.Maximum = Convert.ToDecimal(getPlayer().getCurrentChips());
                }

                //If it's the player's turn, the AIPlayer play-panel is disabled.
                gamewindow.call_button_ai.Text = "Call ";
                gamewindow.check_button_ai.Enabled = false;
                gamewindow.fold_button_ai.Enabled = false;
                gamewindow.call_button_ai.Enabled = false;
                gamewindow.bet_amount_ai.Enabled = false;
                
            }
            if (playerturn == "aiplayer") 
            {
                if (currentbet > 0)
                {
                    //If the current bet is higher than 0, means that the Player has betted and the AIplayer can only call with the same amount.
                    gamewindow.call_button_ai.Text = "Call " + currentbet;
                    gamewindow.check_button_ai.Enabled = false;
                    gamewindow.fold_button_ai.Enabled = true;
                    gamewindow.call_button_ai.Enabled = true;
                    gamewindow.bet_amount_ai.Maximum = Convert.ToDecimal(getAiPlayer().getCurrentChips());
                    
                }
                else
                {
                    //If the current bet is 0, the player is starting he can either bet, check or fold. 
                    gamewindow.bet_button_ai.Enabled = true;
                    gamewindow.fold_button_ai.Enabled = true;
                    gamewindow.check_button_ai.Enabled = true;
                    gamewindow.bet_amount_ai.Enabled = true;
                    gamewindow.bet_amount_ai.Maximum = Convert.ToDecimal(getAiPlayer().getCurrentChips());
                }
                //If it's the player's turn, the Player play-panel is disabled.
                gamewindow.call_button.Text = "Call ";
                gamewindow.check_button.Enabled = false;
                gamewindow.fold_button.Enabled = false;
                gamewindow.call_button.Enabled = false;
                gamewindow.bet_amount.Enabled = false;

            }

        }

        public void playerOnHold()
        {
            if (playersturn != "player")
            {
                gamewindow.bet_button.Enabled = false;
                gamewindow.fold_button.Enabled = false;
                gamewindow.check_button.Enabled = false;
                gamewindow.bet_amount.Enabled = false;
                gamewindow.call_button.Enabled = false;

            }
            else
            {
                gamewindow.bet_button_ai.Enabled = false;
                gamewindow.fold_button_ai.Enabled = false;
                gamewindow.check_button_ai.Enabled = false;
                gamewindow.bet_amount_ai.Enabled = false;
                gamewindow.call_button_ai.Enabled = false;

            }
        }

        public void fold()
        {
            if (playersturn == "player")
            {
                getAiPlayer().setCurrentChips(getAiPlayer().getCurrentChips() + currentpot);
                playersturn = "aiplayer";
                newRound();
            }
            else
            {
                getPlayer().setCurrentChips(getPlayer().getCurrentChips() + currentpot);
                playersturn = "player";
                newRound();
            }
        }

        public void result()
        {
            string winner = gameanalyzer.determineWinner();
            if (winner == "player")
            {
                gamewindow.showMessage("Player winns!");
                getPlayer().setCurrentChips(getPlayer().getCurrentChips() + currentpot);
                newRound();
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

        public Gamewindow getGameWindow()
        {
            return gamewindow;
        }

        public string getPlayersTurn()
        {
            return playersturn;
        }

        public double getCurrentBet()
        {
            return currentbet;
        }

        public void setCurrentBet(double bet)
        {
            currentbet = bet;
        }

    }
}
