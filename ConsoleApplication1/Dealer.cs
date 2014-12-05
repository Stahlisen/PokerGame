using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    public class Dealer 
    {

       CardDeck deck = new CardDeck();
       Game currentgame;
       List <Card> flopcards = new List<Card>();
       Card turncard;
       Card rivercard;
       string path = @"..\cards\";

        public Dealer(Game _game)
        {
            currentgame = _game;
        }

        public CardDeck getDeck()
        {
            return deck;
        }

       
        public List<List<string>> startHand()
        {
            
            //Shuffle the deck on starthand
            getDeck().shuffleDeck();
            //Pick two cards from the top of the deck and give them to the players
            currentgame.getPlayer().addToHand(getDeck().getTopCard());
            currentgame.getPlayer().addToHand(getDeck().getTopCard());
            currentgame.getAiPlayer().addToHand(getDeck().getTopCard());
            currentgame.getAiPlayer().addToHand(getDeck().getTopCard());
            //Get the two cards from the starthand of the player
            Card playercard1 = currentgame.getPlayer().getHand()[0];
            Card playercard2 = currentgame.getPlayer().getHand()[1];
            Console.WriteLine("Human player cards:");
            Console.WriteLine(playercard1.getValue() + playercard1.getSuit());
            Console.WriteLine(playercard2.getValue() + playercard2.getSuit());
            Card aiplayercard1 = currentgame.getAiPlayer().getHand()[0];
            Card aiplayercard2 = currentgame.getAiPlayer().getHand()[1];
            Console.WriteLine("AI player cards: ");
            Console.WriteLine(aiplayercard1.getValue() + aiplayercard1.getSuit());
            Console.WriteLine(aiplayercard2.getValue() + aiplayercard2.getSuit());
            
            //Add filepath of each card
            string file_playercard1 = playercard1.getValue() + "of" + playercard1.getSuit() + ".png";
            string file_playercard2 = playercard2.getValue() + "of" + playercard2.getSuit() + ".png";
            string path_playercard1 = Path.Combine(path, file_playercard1);
            string path_playercard2 = Path.Combine(path, file_playercard2);
            string file_aiplayercard1 = aiplayercard1.getValue() + "of" + aiplayercard1.getSuit() + ".png";
            string file_aiplayercard2 = aiplayercard2.getValue() + "of" + aiplayercard2.getSuit() + ".png";
            string path_aiplayercard1 = Path.Combine(path, file_aiplayercard1);
            string path_aiplayercard2 = Path.Combine(path, file_aiplayercard2);
            //Add both filepaths to a list of filepaths
            List<string> filepaths_playercards = new List<string> {path_playercard1, path_playercard2};
            List<string> filepaths_aiplayercards = new List <string> {path_aiplayercard1, path_aiplayercard2};
            List<List<string>> filepaths_starthand = new List<List<string>> {filepaths_playercards, filepaths_aiplayercards};

            return filepaths_starthand;
        }

        public List<string> flop()
        {
            //Pick three cards from the top of the deck and put them in the flop List
            flopcards.Add(getDeck().getTopCard());
            flopcards.Add(getDeck().getTopCard());
            flopcards.Add(getDeck().getTopCard());

            //Add filepath of each card
            string file_flop1 = flopcards[0].getValue() + "of" + flopcards[0].getSuit() + ".png";
            string file_flop2 = flopcards[1].getValue() + "of" + flopcards[1].getSuit() + ".png";
            string file_flop3 = flopcards[2].getValue() + "of" + flopcards[2].getSuit() + ".png";
            string filepath_flop1 = Path.Combine(path, file_flop1);
            string filepath_flop2 = Path.Combine(path, file_flop2);
            string filepath_flop3 = Path.Combine(path, file_flop3);
            //Add all filepaths to a list of filepaths
            List<string> filepaths_flop = new List<string> {filepath_flop1, filepath_flop2, filepath_flop3};
            //Return the filepathList
            return filepaths_flop;
        }

        public string turn()
        {
            //Pick a card from the top of the deck and set the turncard as that card so we can access it later.
            turncard = getDeck().getTopCard();
            
            //Add filepath for the card
            string file_turn = turncard.getValue() + "of" + turncard.getSuit() + ".png";
            string filepath_turn = Path.Combine(path, file_turn);
            //Return the filepath
            return filepath_turn;
        }

        public string river()
        {
            //Pick a card from the top of the deck and set rivercard as that card so we can access it later.
            rivercard = getDeck().getTopCard();

            //Add filepath for that card
            string file_river = rivercard.getValue() + "of" + rivercard.getSuit() + ".png";
            string filepath_river = Path.Combine(path, file_river);
            //Return the filepath
            return filepath_river;
        }

        }
    }

