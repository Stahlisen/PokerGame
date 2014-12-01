namespace ConsoleApplication1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playerinfo_panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.playerinfo_panel.SuspendLayout();
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConsoleApplication1.Properties.Resources.poker_table_environment;
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(743, 434);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // playerinfo_panel
            // 
            this.playerinfo_panel.Controls.Add(this.player1_label);
            this.playerinfo_panel.Controls.Add(this.player1chips_label);
            this.playerinfo_panel.Controls.Add(this.desc_chips1_label);
            this.playerinfo_panel.Location = new System.Drawing.Point(576, 361);
            this.playerinfo_panel.Name = "playerinfo_panel";
            this.playerinfo_panel.Size = new System.Drawing.Size(168, 75);
            this.playerinfo_panel.TabIndex = 5;
            // 
            // Gamewindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 436);
            this.Controls.Add(this.playerinfo_panel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Gamewindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gamewindow";
            this.Load += new System.EventHandler(this.Gamewindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.playerinfo_panel.ResumeLayout(false);
            this.playerinfo_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label player1_label;
        private System.Windows.Forms.Label player1chips_label;
        private System.Windows.Forms.Label desc_chips1_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel playerinfo_panel;


    }
}