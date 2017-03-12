using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        enum PlayerTurn { none, player1, player2};
        enum Winner { none, player1, player2, draw};
        PlayerTurn turn;
        Winner winner;
        void OnNewGame()
        {
            PictureBox[] allPitures = {pictureBox1,
                                        pictureBox2,
                                        pictureBox3,
                                        pictureBox4,
                                        pictureBox5,
                                        pictureBox6,
                                        pictureBox7,
                                        pictureBox8,
                                        pictureBox9};
            foreach (var p in allPitures)
                p.Image = null;
            turn = PlayerTurn.player1;
            winner = Winner.none;
            ShowTurn();
        }
        Winner GetWinner()
        {
            PictureBox[] allWinningMoves = {pictureBox1,pictureBox2,pictureBox3,
                                             pictureBox4,pictureBox5,pictureBox6,
                                             pictureBox7,pictureBox8,pictureBox9,
                                             pictureBox1,pictureBox4,pictureBox7,
                                             pictureBox2,pictureBox5,pictureBox8,
                                             pictureBox3,pictureBox6,pictureBox9,
                                             pictureBox1,pictureBox5,pictureBox9,
                                             pictureBox3,pictureBox5,pictureBox7};
            for(int i=0; i<allWinningMoves.Length;i+=3)
            {
                if(allWinningMoves[i].Image!=null)
                {
                    if(allWinningMoves[i].Image==allWinningMoves[i+1].Image && allWinningMoves[i].Image == allWinningMoves[i + 2].Image)
                    {
                        if (allWinningMoves[i].Image == player1.Image)
                        {
                            return Winner.player1;
                        }
                        else
                            return Winner.player2;
                    }
                }
            }

            PictureBox[] allPitures = {pictureBox1,
                                        pictureBox2,
                                        pictureBox3,
                                        pictureBox4,
                                        pictureBox5,
                                        pictureBox6,
                                        pictureBox7,
                                        pictureBox8,
                                        pictureBox9};
            foreach (var p in allPitures)
                if (p.Image == null)
                    return Winner.none;

            return Winner.draw;
        }
        void ShowTurn()
        {
            string status = "";
            string msg = "";
            switch (winner)
            {
                case Winner.none:
                    if (turn == PlayerTurn.player1)
                        status = "Turn: Player X";
                    else
                        status = "Turn: Player O";
                    break;

                case Winner.player1:
                    msg= status = "Player X wins!";
                    break;

                case Winner.player2:
                    msg = status = "Player O wins!";
                    break;
                case Winner.draw:
                    status = "It's a tie!";
                    break;
            }
            lblstatus.Text = status;
            if(msg!="")
            {
                MessageBox.Show(msg, "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if (p.Image != null)
                return;
            if (turn == PlayerTurn.none)
                return;

            if(turn==PlayerTurn.player1)
                p.Image = player1.Image;
            else
                p.Image = player2.Image;
            winner = GetWinner();
            if(winner==Winner.none)
            {
                turn = (PlayerTurn.player1 == turn) ? PlayerTurn.player2 : PlayerTurn.player1;
            }
            else
            {
                turn = PlayerTurn.none;
            }
            ShowTurn();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnNewGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnNewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about = "Hello, I am Mujtaba Asif.\nI made this game for my course project of \nCSE107: Object Oriented Programming.\nThanks to \nDr. Ahmed Wasif Reza\nfor assigning me to this project.";
            MessageBox.Show(about, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
