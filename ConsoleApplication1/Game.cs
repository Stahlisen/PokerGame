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
        bool check = false;
        

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
            gamewindow.determine_button.Visible = false;
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
                gamewindow.determine_button.Visible = true;
                
            }
        }

        public void blindBet()
        {

            if (getSmallBlindTurn() == "ai")
            {
                if (getAiPlayer().getCurrentChips() >= smallBlind & getPlayer().getCurrentChips() >= bigBlind)
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
                    if (getAiPlayer().getCurrentChips() < smallBlind)
                    {
                        gamewindow.showMessage("AIplayer cannot afford smallblind, Player wins the game!");
                        gamewindow.disposeWindow();
                    }
                    else if (getPlayer().getCurrentChips() < bigBlind)
                    {
                        gamewindow.showMessage("Player cannot afford Bigblind, Player wins the game!");
                        gamewindow.disposeWindow();
                    }
                }
                
                

                
            }
            else
            {
                if (getPlayer().getCurrentChips() >= smallBlind & getAiPlayer().getCurrentChips() >= bigBlind)
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
                else
                {
                    if (getAiPlayer().getCurrentChips() < bigBlind)
                    {
                        gamewindow.showMessage("AIplayer cannot afford bigblind, Player wins the game!");
                        gamewindow.disposeWindow();
                    }
                    else if (getPlayer().getCurrentChips() < smallBlind)
                    {
                        gamewindow.showMessage("Player cannot afford smallblind, Player wins the game!");
                        gamewindow.disposeWindow();
                    }

                }
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
                    getAiPlayer().setCurrentChips(getAiPlayer().getCurrentChips() - Convert.ToDouble(gamewindow.bet_amount_ai.Value));
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
                if (currentbet <= getAiPlayer().getCurrentChips())
                {
                    if (getAiPlayer().getCurrentChips() == Convert.ToDouble(currentbet))
                    {
                        gamewindow.aiplayer_bet_amount.Text = Convert.ToString(currentbet);
                        getAiPlayer().setCurrentChips(getAiPlayer().getCurrentChips() - currentbet);
                        gamewindow.changeLabel(gamewindow.aiplayerchips_label, Convert.ToString(getAiPlayer().getCurrentChips()));
                        currentbet = currentbet + currentbet;
                        gatherPot();
                        playersturn = "player";
                        playerOnHold();
                        confront();

                    }
                    else
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
                }
                else
                {
                    gamewindow.showMessage("You don't have enough chips to call the bet");
                }
            }
            else
            {
                if (currentbet <= getPlayer().getCurrentChips())
                {
                    if (getPlayer().getCurrentChips() == Convert.ToDouble(currentbet))
                    {
                        gamewindow.player_bet_amount.Text = Convert.ToString(currentbet);
                        getPlayer().setCurrentChips(getPlayer().getCurrentChips() - currentbet);
                        gamewindow.changeLabel(gamewindow.player1chips_label, Convert.ToString(getPlayer().getCurrentChips()));
                        currentbet = currentbet + currentbet;
                        gatherPot();
                        playersturn = "aiplayer";
                        playerOnHold();
                        confront();
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
                else
                {
                    gamewindow.showMessage("You don't have enough chips to call the bet");
                }
            }
        }

        public void playerDidCheck()
        {
            if (playersturn == "player")
            {
                if (check)
                {
                    gamewindow.showEvent("Player checked");
                    playersturn = "aiplayer";
                    playSession(playersturn);
                    playerOnHold();
                    nextCards();
                    check = false;
                }
                else
                {
                    Console.WriteLine(getPlayer().getCurrentChips());
                    gamewindow.showEvent("Player checked");
                    check = true;
                    playerOnHold();
                    playersturn = "aiplayer";
                    playSession(playersturn);
                }
            }
            else
            {
                if (check)
                {
                    gamewindow.showEvent("AiPlayer checked");
                    playersturn = "player";
                    playSession(playersturn);
                    playerOnHold();
                    nextCards();
                    check = false;
                }
                else
                {
                    gamewindow.showEvent("AiPlayer checked");
                    check = true;
                    playerOnHold();
                    playersturn = "player";
                    playSession(playersturn);
                }
            }


        }

        public void playSession(string playerturn)
        {

            if (playerturn == "player")
            {
                if (currentbet > 0)
                {
                    Console.WriteLine(getPlayer().getCurrentChips());
                    Console.WriteLine(currentbet);
                    if (getPlayer().getCurrentChips() > 0 && getPlayer().getCurrentChips() >= currentbet) {
                    //If the current bet is higher than 0, means that the AIPlayer has betted and the player can only call with the same amount.
                        if (getPlayer().getCurrentChips() == Convert.ToDouble(currentbet))
                        {
                            gamewindow.call_button.Text = "All in " + currentbet;
                            gamewindow.check_button.Enabled = false;
                            gamewindow.fold_button.Enabled = true;
                            gamewindow.bet_button.Enabled = false;
                            gamewindow.call_button.Enabled = true;
                            gamewindow.bet_amount.Maximum = Convert.ToDecimal(getPlayer().getCurrentChips());
                        }
                        else
                        {
                            gamewindow.call_button.Text = "Call " + currentbet;
                            gamewindow.check_button.Enabled = false;
                            gamewindow.fold_button.Enabled = true;
                            gamewindow.bet_button.Enabled = false;
                            gamewindow.call_button.Enabled = true;
                            gamewindow.bet_amount.Maximum = Convert.ToDecimal(getPlayer().getCurrentChips());
                        }
                    }
                    else
                    {
                        confront();
                        
                    }

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
                    if (getAiPlayer().getCurrentChips() > 0 && getAiPlayer().getCurrentChips() >= currentbet)
                    {
                        if (getAiPlayer().getCurrentChips() == Convert.ToDouble(currentbet))
                        {
                            gamewindow.call_button_ai.Text = "All in " + currentbet;
                            gamewindow.check_button_ai.Enabled = false;
                            gamewindow.fold_button_ai.Enabled = true;
                            gamewindow.bet_button_ai.Enabled = false;
                            gamewindow.call_button_ai.Enabled = true;
                            gamewindow.bet_amount_ai.Maximum = Convert.ToDecimal(getAiPlayer().getCurrentChips());
                        }
                        else
                        {
                            gamewindow.call_button_ai.Text = "Call " + currentbet;
                            gamewindow.check_button_ai.Enabled = false;
                            gamewindow.fold_button_ai.Enabled = true;
                            gamewindow.bet_button_ai.Enabled = false;
                            gamewindow.call_button_ai.Enabled = true;
                            gamewindow.bet_amount_ai.Maximum = Convert.ToDecimal(getAiPlayer().getCurrentChips());
                        }
                    }
                    else
                    {
                        confront();
                    }
                    
                }
                else
                {
                    //If the current bet is 0, the aiplayer is starting he can either bet, check or fold. 
                    gamewindow.bet_button_ai.Enabled = true;
                    gamewindow.fold_button_ai.Enabled = true;
                    gamewindow.check_button_ai.Enabled = true;
                    gamewindow.bet_amount_ai.Enabled = true;
                    gamewindow.bet_amount_ai.Maximum = Convert.ToDecimal(getAiPlayer().getCurrentChips());
                }
                //If it's the aiplayer's turn, the Player play-panel is disabled.
                gamewindow.call_button.Text = "Call ";
                gamewindow.check_button.Enabled = false;
                gamewindow.fold_button.Enabled = false;
                gamewindow.call_button.Enabled = false;
                gamewindow.bet_amount.Enabled = false;
                gamewindow.bet_button.Enabled = false;

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
                gamewindow.showMessage("Player folded, AiPlayer wins " + (currentpot + currentbet));
                getAiPlayer().setCurrentChips(getAiPlayer().getCurrentChips() + currentpot + currentbet);
                playersturn = "aiplayer";
                newRound();
            }
            else
            {
                gamewindow.showMessage("AiPlayer folded, Player wins " + (currentpot + currentbet));
                getPlayer().setCurrentChips(getPlayer().getCurrentChips() + currentpot + currentbet);
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

        public void confront()
        {
            gamewindow.determine_button.Visible = true;
            getDealer().flop();
            getDealer().turn();
            getDealer().river();
            
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
