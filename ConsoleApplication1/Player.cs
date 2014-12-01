using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Player
    {

        string name;
        double currentchips;

        public Player ()
        {

            
        }

        public string getName()
        {
            return name;
        }
        public void setName(string Name)
        {
            name = Name;
        }

        public double getCurrentChips()
        {
            return currentchips;
        }
        public void setCurrentChips(double Chips)
        {
            currentchips = Chips;
        }


    }
}
