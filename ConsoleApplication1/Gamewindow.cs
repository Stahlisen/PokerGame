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
            currentpot.Parent = pokerTable_box;
            eventtext_label.Parent = pokerTable_box;
            player_bet_amount.Parent = pokerTable_box;
            aiplayer_bet_amount.Parent = pokerTable_box;
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

        public void showMessage(string text)
        {
            MessageBox.Show(text);
        }

        public void showEvent(string text)
        {

            eventtext_label.Text = text;

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void changePictureBox(PictureBox box, string filepath)
        {
            box.Image = Image.FromFile(filepath);

        }

        public void changeLabel(Label label, string text)
        {

            label.Text = text;
        }

        private void bet_button_Click(object sender, EventArgs e)
        {
            currentgame.playerDidBet();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void call_button_ai_Click(object sender, EventArgs e)
        {
            currentgame.playerDidCall();
        }

        private void fold_button_Click(object sender, EventArgs e)
        {
            currentgame.fold();

        }

        private void fold_button_ai_Click(object sender, EventArgs e)
        {
            currentgame.fold();
        }

        private void bet_button_ai_Click(object sender, EventArgs e)
        {
            currentgame.playerDidBet();
        }

        private void call_button_Click(object sender, EventArgs e)
        {
            currentgame.playerDidCall();
        }
    }
}
