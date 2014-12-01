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

        
        
        public Gamewindow()
        {
            InitializeComponent();
            

            //Setting parent for labels
            player1_label.Parent = playerinfo_panel;
            player1chips_label.Parent = playerinfo_panel;
            desc_chips1_label.Parent = playerinfo_panel;
            game.getDealer().getDeck().shuffleDeck();

            
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
            
            
           
            String filename = game.getDealer().getDeck().getTopCard();
            Console.WriteLine(filename);

            player_card1.Image = Image.FromFile("../cards/" + filename + ".png");
            
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        //Getters for acessing pictureboxes.

        public PictureBox getPlayerCard1()
        {

            return player_card1;
        }

        public PictureBox getPlayerCard2()
        {

            return player_card2;
        }

        public PictureBox getAiCard1()
        {

            return ai_card1;
        }

        public PictureBox getAiCard2()
        {

            return ai_card2;
        }

        public PictureBox getFlop1()
        {

            return flop_1;
        }

        public PictureBox getFlop2()
        {

            return flop_2;
        }

        public PictureBox getFlop3()
        {

            return flop_3;
        }

        public PictureBox getTurn()
        {

            return turn;
        }

        public PictureBox getRiver()
        {

            return river;
        }




        
    }
}
