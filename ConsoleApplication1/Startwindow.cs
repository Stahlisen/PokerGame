using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    public partial class Startwindow : Form
    {

        string enteredname;
        double enteredchips;
        

        public Startwindow()
        {
            InitializeComponent();
        }


        private void start_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start game clicked");
            Game game = new Game(enteredchips, enteredname);
            Console.WriteLine("Buy-in: " + game.getChips());
            Console.WriteLine("Small Blind: " + game.getSmallBlind());
            Console.WriteLine("Big Blind: " + game.getBigBlind());
            Console.WriteLine("Player: " + enteredname);
            Console.WriteLine(game.getPlayer().getName());
            Console.WriteLine(game.getPlayer().getCurrentChips());

            this.Hide();
            Gamewindow gamewindow = new Gamewindow(game);
            gamewindow.ShowDialog();






        }

        private void Gamewindow_Load(object sender, EventArgs e)
        {

          

        }


        private void name_textbox_TextChanged(object sender, EventArgs e)
        {
            enteredname = name_textbox.Text;
         
            

        }

        private void chips_textbox_TextChanged(object sender, EventArgs e)
        {
            enteredchips = Double.Parse(chips_textbox.Text);

            start_button.Enabled = !string.IsNullOrWhiteSpace(name_textbox.Text +  chips_textbox.Text);
        }


    

      
    }
}
