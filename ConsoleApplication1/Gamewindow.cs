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
    public partial class Gamewindow : Form
    {

        Game game;
        int counter = 0;
        public Gamewindow(Game Game)
        {
            InitializeComponent();
            game = Game;

            player1_label.Parent = playerinfo_panel;
            player1chips_label.Parent = playerinfo_panel;
            desc_chips1_label.Parent = playerinfo_panel;
            game.getDealer().getDeck().shuffleDeck();

            Console.WriteLine(game.getDealer().getDeck().getTopCard());
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void player1_label_Click(object sender, EventArgs e)
        {

        }

        private void Gamewindow_Load(object sender, EventArgs e)
        {
            player1_label.Text = game.getPlayer().getName();
            player1chips_label.Text = Convert.ToString(game.getPlayer().getCurrentChips());

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine(game.getDealer().getDeck().getTopCard());
            
            Console.WriteLine(counter++);
            
        }
    }
}
