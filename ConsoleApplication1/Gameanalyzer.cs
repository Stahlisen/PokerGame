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
            checkForHands("player");
            checkForHands("aiplayer");
        }

        public void checkForHands(string player)
        {
            List<string> values = new List<string>();
            List<string> suits = new List<string>();
            List<Card> cards;
            values.Clear();
            suits.Clear();

            if (player == "player")
            {
                cards = playerCards;
            }
            else
            {
                cards = AiCards;
            }

            foreach (Card element in cards)
            {
                values.Add(element.getValue().ToString());
                suits.Add(element.getSuit().ToString());
            }

            hasPair(values, player);
            

        }

        public void hasPair(List<string> values, string player)
        {
            Resulthand hand;
            if (player == "player")
            {
                hand = playerhand;
            }
            else
            {
                hand = aihand;
            }
            List<string> pairs = new List<string>();
            List<int> paircounts = new List<int>();
            var paircards = from x in values
                        group x by x into grouped
                        where grouped.Count() > 1
                        select grouped.Key;

            var paircount = from x in values
                            group x by x into grouped
                            where grouped.Count() > 1
                            select grouped.Count();

            int paircounter = 0;
            int overtwo = 0;

            //If there was any duplicates we add each value of the pair into a List (pairs) and we return it from the method.
            if (paircards.Any())
            {
                foreach (var x in paircount)
                {
                    Console.WriteLine(x);
                    paircounts.Add(x);
                    if (x == 3)
                    {
                        hand.setTriplet(true);
                        Console.WriteLine(player + "has three of a kind");
                    }
                    else if (x == 4)
                    {
                        hand.setFour(true);
                        Console.WriteLine(player + "has four of a kind");
                    }

                    var fullhousecheck = from y in paircounts
                                         where y > 2
                                         orderby y ascending
                                         select y;

                    foreach (var y in fullhousecheck)
                    {
                        overtwo++;
                    }

                    if (overtwo > 0 && paircounts.ToArray().Length > 2)
                    {
                        hand.setFullHouse(true);
                        Console.WriteLine(player + "has a full house");
                    }
                }
                
                foreach (var x in paircards) {
                    
                    Console.WriteLine( player + " has pair of " + x + "s");
                    paircounter++;
                    pairs.Add(x);
                }

                if (paircounter > 1)
                {
                    
                    hand.setTwoPair(true);
                }
                else
                {
                    hand.setPair(true);
                }
            } else
            {
                Console.WriteLine(player + "has no pair");
            }
        }

        public void hasTriplet(string player)
        {
         

        }

        
    }
}
