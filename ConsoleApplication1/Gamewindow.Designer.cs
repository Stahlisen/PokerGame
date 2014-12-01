﻿namespace ConsoleApplication1
{
    partial class Gamewindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1_label = new System.Windows.Forms.Label();
            this.player1chips_label = new System.Windows.Forms.Label();
            this.desc_chips1_label = new System.Windows.Forms.Label();
            this.playerinfo_panel = new System.Windows.Forms.Panel();
            this.player_card1 = new System.Windows.Forms.PictureBox();
            this.pokerTable_box = new System.Windows.Forms.PictureBox();
            this.flop_1 = new System.Windows.Forms.PictureBox();
            this.flop_3 = new System.Windows.Forms.PictureBox();
            this.flop_2 = new System.Windows.Forms.PictureBox();
            this.player_card2 = new System.Windows.Forms.PictureBox();
            this.ai_card1 = new System.Windows.Forms.PictureBox();
            this.ai_card2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.turn = new System.Windows.Forms.PictureBox();
            this.river = new System.Windows.Forms.PictureBox();
            this.playerinfo_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player_card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokerTable_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ai_card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ai_card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.river)).BeginInit();
            this.SuspendLayout();
            // 
            // player1_label
            // 
            this.player1_label.AutoSize = true;
            this.player1_label.BackColor = System.Drawing.Color.Transparent;
            this.player1_label.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.player1_label.Location = new System.Drawing.Point(3, 0);
            this.player1_label.Name = "player1_label";
            this.player1_label.Size = new System.Drawing.Size(109, 22);
            this.player1_label.TabIndex = 0;
            this.player1_label.Text = "player1_label";
            this.player1_label.Click += new System.EventHandler(this.player1_label_Click);
            // 
            // player1chips_label
            // 
            this.player1chips_label.AutoSize = true;
            this.player1chips_label.BackColor = System.Drawing.Color.Transparent;
            this.player1chips_label.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1chips_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.player1chips_label.Location = new System.Drawing.Point(58, 45);
            this.player1chips_label.Name = "player1chips_label";
            this.player1chips_label.Size = new System.Drawing.Size(54, 22);
            this.player1chips_label.TabIndex = 2;
            this.player1chips_label.Text = "label1";
            // 
            // desc_chips1_label
            // 
            this.desc_chips1_label.AutoSize = true;
            this.desc_chips1_label.BackColor = System.Drawing.Color.Transparent;
            this.desc_chips1_label.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_chips1_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.desc_chips1_label.Location = new System.Drawing.Point(3, 45);
            this.desc_chips1_label.Name = "desc_chips1_label";
            this.desc_chips1_label.Size = new System.Drawing.Size(56, 22);
            this.desc_chips1_label.TabIndex = 3;
            this.desc_chips1_label.Text = "Chips:";
            // 
            // playerinfo_panel
            // 
            this.playerinfo_panel.Controls.Add(this.player1_label);
            this.playerinfo_panel.Controls.Add(this.player1chips_label);
            this.playerinfo_panel.Controls.Add(this.desc_chips1_label);
            this.playerinfo_panel.Location = new System.Drawing.Point(779, 522);
            this.playerinfo_panel.Name = "playerinfo_panel";
            this.playerinfo_panel.Size = new System.Drawing.Size(180, 105);
            this.playerinfo_panel.TabIndex = 5;
            // 
            // player_card1
            // 
            this.player_card1.Location = new System.Drawing.Point(399, 450);
            this.player_card1.Name = "player_card1";
            this.player_card1.Size = new System.Drawing.Size(83, 128);
            this.player_card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player_card1.TabIndex = 6;
            this.player_card1.TabStop = false;
            // 
            // pokerTable_box
            // 
            this.pokerTable_box.Image = global::ConsoleApplication1.Properties.Resources.poker_table_environment;
            this.pokerTable_box.Location = new System.Drawing.Point(1, 2);
            this.pokerTable_box.Name = "pokerTable_box";
            this.pokerTable_box.Size = new System.Drawing.Size(958, 625);
            this.pokerTable_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pokerTable_box.TabIndex = 4;
            this.pokerTable_box.TabStop = false;
            this.pokerTable_box.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // flop_1
            // 
            this.flop_1.Image = global::ConsoleApplication1.Properties.Resources.CARD_BACK;
            this.flop_1.Location = new System.Drawing.Point(309, 230);
            this.flop_1.Name = "flop_1";
            this.flop_1.Size = new System.Drawing.Size(62, 94);
            this.flop_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flop_1.TabIndex = 11;
            this.flop_1.TabStop = false;
            this.flop_1.Click += new System.EventHandler(this.pictureBox1_Click_2);
            // 
            // flop_3
            // 
            this.flop_3.Image = global::ConsoleApplication1.Properties.Resources.CARD_BACK;
            this.flop_3.Location = new System.Drawing.Point(445, 230);
            this.flop_3.Name = "flop_3";
            this.flop_3.Size = new System.Drawing.Size(62, 94);
            this.flop_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flop_3.TabIndex = 12;
            this.flop_3.TabStop = false;
            this.flop_3.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // flop_2
            // 
            this.flop_2.Image = global::ConsoleApplication1.Properties.Resources.CARD_BACK;
            this.flop_2.Location = new System.Drawing.Point(377, 230);
            this.flop_2.Name = "flop_2";
            this.flop_2.Size = new System.Drawing.Size(62, 94);
            this.flop_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flop_2.TabIndex = 13;
            this.flop_2.TabStop = false;
            this.flop_2.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // player_card2
            // 
            this.player_card2.Location = new System.Drawing.Point(500, 450);
            this.player_card2.Name = "player_card2";
            this.player_card2.Size = new System.Drawing.Size(83, 128);
            this.player_card2.TabIndex = 14;
            this.player_card2.TabStop = false;
            // 
            // ai_card1
            // 
            this.ai_card1.Image = global::ConsoleApplication1.Properties.Resources.CARD_BACK;
            this.ai_card1.Location = new System.Drawing.Point(399, 2);
            this.ai_card1.Name = "ai_card1";
            this.ai_card1.Size = new System.Drawing.Size(83, 128);
            this.ai_card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ai_card1.TabIndex = 15;
            this.ai_card1.TabStop = false;
            // 
            // ai_card2
            // 
            this.ai_card2.Image = global::ConsoleApplication1.Properties.Resources.CARD_BACK;
            this.ai_card2.Location = new System.Drawing.Point(500, 2);
            this.ai_card2.Name = "ai_card2";
            this.ai_card2.Size = new System.Drawing.Size(83, 128);
            this.ai_card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ai_card2.TabIndex = 16;
            this.ai_card2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(762, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Next card";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // turn
            // 
            this.turn.Image = global::ConsoleApplication1.Properties.Resources.CARD_BACK;
            this.turn.Location = new System.Drawing.Point(546, 230);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(62, 94);
            this.turn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.turn.TabIndex = 18;
            this.turn.TabStop = false;
            // 
            // river
            // 
            this.river.Image = global::ConsoleApplication1.Properties.Resources.CARD_BACK;
            this.river.Location = new System.Drawing.Point(614, 230);
            this.river.Name = "river";
            this.river.Size = new System.Drawing.Size(62, 94);
            this.river.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.river.TabIndex = 19;
            this.river.TabStop = false;
            // 
            // Gamewindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 628);
            this.Controls.Add(this.river);
            this.Controls.Add(this.turn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ai_card2);
            this.Controls.Add(this.ai_card1);
            this.Controls.Add(this.player_card2);
            this.Controls.Add(this.flop_2);
            this.Controls.Add(this.flop_3);
            this.Controls.Add(this.flop_1);
            this.Controls.Add(this.player_card1);
            this.Controls.Add(this.playerinfo_panel);
            this.Controls.Add(this.pokerTable_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Gamewindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gamewindow";
            this.Load += new System.EventHandler(this.Gamewindow_Load);
            this.playerinfo_panel.ResumeLayout(false);
            this.playerinfo_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player_card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokerTable_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player_card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ai_card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ai_card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.river)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label player1_label;
        private System.Windows.Forms.Label player1chips_label;
        private System.Windows.Forms.Label desc_chips1_label;
        private System.Windows.Forms.PictureBox pokerTable_box;
        private System.Windows.Forms.Panel playerinfo_panel;
        private System.Windows.Forms.PictureBox player_card1;
        private System.Windows.Forms.PictureBox flop_1;
        private System.Windows.Forms.PictureBox flop_3;
        private System.Windows.Forms.PictureBox flop_2;
        private System.Windows.Forms.PictureBox player_card2;
        private System.Windows.Forms.PictureBox ai_card1;
        private System.Windows.Forms.PictureBox ai_card2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox turn;
        private System.Windows.Forms.PictureBox river;


    }
}