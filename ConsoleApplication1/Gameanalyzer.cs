using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Gameanalyzer
    {

        string winner;
        Game game;
        List<Card> playerCards = new List<Card>();
        List<Card> AiCards = new List<Card>();
        Resulthand playerhand;
        Resulthand aihand;

        public Gameanalyzer(Game g)
        {
            game = g;
            playerhand = new Resulthand();
            aihand = new Resulthand();

        }
        public string determineWinner()
        {
            winner = "player";
            evaluateHands();
            return winner;
        }

        public void gatherHands()
        {
            playerCards.Clear();
            AiCards.Clear();
            //Add card combination for the player
            playerCards.AddRange(game.getPlayer().getHand());
            playerCards.AddRange(game.getDealer().getFlop());
            playerCards.Add(game.getDealer().getTurn());
            playerCards.Add(game.getDealer().getRiver());

            //Add card combination for the AIplayer
            AiCards.AddRange(game.getAiPlayer().getHand());
            AiCards.AddRange(game.getDealer().getFlop());
            AiCards.Add(game.getDealer().getTurn());
            AiCards.Add(game.getDealer().getRiver());

        }

        public void evaluateHands() {
            gatherHands();

            hasPair("player");
            hasPair("aiplayer");
        }

        public void hasPair(string player)
        {
            //Create tree lists, one which stores all the string values of the players combination of cards,
            //one to store every pair of cards it includes, we will return this list from this method.
            //And one which will be referencing either of the two players Card Lists, so that we can smoothly change
            //the reference according to which player we are evaluating.
            List<string> values = new List<string>();
            List<string> pairs = new List<string>();
            List<Card> cards;
            values.Clear();
            pairs.Clear();

            if (player == "player") 
            {
                cards = playerCards;
            }
            else
            {
                cards = AiCards;
            }
            //Add value of each card in a list so we can match duplicates.
            foreach (Card element in cards)
            {
                Console.WriteLine(element.getValue());
                values.Add(element.getValue().ToString());
            }
            //Check for duplicates
            var paircards = from x in values
                        group x by x into grouped
                        where grouped.Count() > 1
                        select grouped.Key;

            //If there was any duplicates we add each value of the pair into a List (pairs) and we return it from the method.
            if (paircards.Any())
            {

                foreach (var x in paircards) {
                    Console.WriteLine( player + " has pair of " + x + "s");
                    pairs.Add(x);
                }


                if (pairs.ToArray().Length > 1)
                {
                    playerhand.setTwoPair(true);
                }
                else
                {
                    playerhand.setPair(true);
                }

            } else
            {
                Console.WriteLine(player + "has no pair");

            }

        }

        
    }
}
