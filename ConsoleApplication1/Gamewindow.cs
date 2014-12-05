using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConsoleApplication1
{
    public partial class Gamewindow : Form
    {

        Game currentgame;
        
        public Gamewindow(Game game)
        {
            InitializeComponent();

            //Setting parent for labels
            player1_label.Parent = playerinfo_panel;
            player1chips_label.Parent = playerinfo_panel;
            desc_chips1_label.Parent = playerinfo_panel;
            desc_pot.Parent = pokerTable_box;
            
            currentgame = game;
        }

 
        private void Gamewindow_Load(object sender, EventArgs e)
        {
            player1_label.Text = currentgame.getPlayer().getName();
            player1chips_label.Text = Convert.ToString(currentgame.getPlayer().getCurrentChips());
            ai_label.Text = currentgame.getAiPlayer().getName();
            aiplayerchips_label.Text = Convert.ToString(currentgame.getAiPlayer().getCurrentChips());
            currentgame.initiateGameWindow(this);
            currentgame.newRound();

        }

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

        private void starthand_button_Click(object sender, EventArgs e)
        {
            //Load the images of player hand cards
            player_card1.Image = Image.FromFile(currentgame.getDealer().startHand()[0][0]);
            player_card2.Image = Image.FromFile(currentgame.getDealer().startHand()[0][1]);
            ai_card1.Image = Image.FromFile(currentgame.getDealer().startHand()[1][0]);
            ai_card2.Image = Image.FromFile(currentgame.getDealer().startHand()[1][1]);
            //Disable starthandbutton
            starthand_button.Enabled = false;
        }

        private void flop_button_Click(object sender, EventArgs e)
        {
            flop_1.Image = Image.FromFile(currentgame.getDealer().flop()[0]);
            flop_2.Image = Image.FromFile(currentgame.getDealer().flop()[1]);
            flop_3.Image = Image.FromFile(currentgame.getDealer().flop()[2]);

            flop_button.Enabled = false;

        }

        private void turn_button_Click(object sender, EventArgs e)
        {
            turn.Image = Image.FromFile(currentgame.getDealer().turn());

            turn_button.Enabled = false;
        }

        private void river_button_Click(object sender, EventArgs e)
        {
            river.Image = Image.FromFile(currentgame.getDealer().river());

            river_button.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
