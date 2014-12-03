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
       List <string> flopcards = new List<string>();
       string turncard;
       string rivercard;
       string path = @"..\cards\";

        public Dealer(Game _game)
        {
            currentgame = _game;
        }

        public CardDeck getDeck()
        {
            return deck;
        }

       
        public List<string> startHand()
        {
            //Shuffle the deck on starthand
            getDeck().shuffleDeck();
            //Pick two cards from the top of the deck and give them to the player
            currentgame.getPlayer().addToHand(getDeck().getTopCard());
            currentgame.getPlayer().addToHand(getDeck().getTopCard());
            //Define strings for each card to pass on filepath for image
            string playercard1 = currentgame.getPlayer().getHand().getCards()[0];
            Console.WriteLine(playercard1);
            string playercard2 = currentgame.getPlayer().getHand().getCards()[1];
            Console.WriteLine(playercard2);
            
            //Add filepath of each card
            string file_card1 = playercard1 + ".png";
            string file_card2 = playercard2 + ".png";
            string path_card1 = Path.Combine(path, file_card1);
            string path_card2 = Path.Combine(path, file_card2);
            Console.WriteLine(path_card1);
            Console.WriteLine(path_card2);
            //Add both filepaths to a list of filepaths
            List<string> filepaths_starthand = new List<string> { path_card1, path_card2 };

            return filepaths_starthand;
        }

        public List<string> flop()
        {
            //Pick three cards from the top of the deck and put them in the flop List
            flopcards.Add(getDeck().getTopCard());
            flopcards.Add(getDeck().getTopCard());
            flopcards.Add(getDeck().getTopCard());

            //Add filepath of each card
            string file_flop1 = flopcards[0] + ".png";
            string file_flop2 = flopcards[1] + ".png";
            string file_flop3 = flopcards[2] + ".png";
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
            //Pick a card from the top of the deck and set the turncard String as that card.
            turncard = getDeck().getTopCard();
            
            //Add filepath for the card
            string file_turn = turncard + ".png";
            string filepath_turn = Path.Combine(path, file_turn);
            //Return the filepath
            return filepath_turn;
        }

        public string river()
        {
            rivercard = getDeck().getTopCard();

            string file_river = rivercard + ".png";
            string filepath_river = Path.Combine(path, file_river);

            return filepath_river;
        }

        }
    }

