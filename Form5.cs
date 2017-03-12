/**************************************************************
 * Project: Tic Tac Toe
 * Author: Md. Mujtaba Asif
 * Student ID: 2016-2-60-037
 * Email: mjtbasif@gmail.com
 * Course Code: CSE107
 * Course Instructor: Dr. Ahmed Wasif Reza
 * Date: 12/7/2016
 * **********************************************************/
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication3
{
    public partial class Form5 : Form
    {
        enum PlayerTurn { none, player1, player2 };
        enum Winner { none, player1, player2, draw };
        PlayerTurn turn;
        int xCount, oCount, tieCount;
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
            for (int i = 0; i < allWinningMoves.Length; i += 3)
            {
                if (allWinningMoves[i].Image != null)
                {
                    if (allWinningMoves[i].Image == allWinningMoves[i + 1].Image && allWinningMoves[i].Image == allWinningMoves[i + 2].Image)
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
            string xC = "0";
            string oC = "0";
            string status = "";
            string msg = "";
            switch (winner)
            {
                case Winner.none:
                    if (turn == PlayerTurn.player1)
                    {
                        playtic();
                        status = "Turn: Player X";
                    }

                    else
                    {
                        status = "Turn: Player O";
                        playtic();
                    }

                    break;

                case Winner.player1:
                    msg = status = "You win!";
                    xCount++;
                    break;

                case Winner.player2:
                    msg = status = "You lose!";
                    oCount++;
                    break;
                case Winner.draw:
                    msg = status = "Computer is as smart as you!";
                    tieCount++;
                    break;
            }
            xC = xCount.ToString();
            oC = oCount.ToString();
            label3.Text = xC;
            label4.Text = oC;

            if (msg != "")
            {
                playwin();
                MessageBox.Show(msg, "Desicion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void playtic()
        {
            SoundPlayer audio = new SoundPlayer(WindowsFormsApplication3.Properties.Resources.tic);
            audio.Play();
        }
        private void playwin()
        {
            SoundPlayer audio = new SoundPlayer(WindowsFormsApplication3.Properties.Resources.win);
            audio.Play();
        }

        public Form5()
        {
            xCount = 0;
            oCount = 0;
            tieCount = 0;
            InitializeComponent();
        }
        

        private void twoPlayerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void twoPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnNewGame();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            OnNewGame();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            PictureBox p = sender as PictureBox;
            if (p.Image != null)
                return;
            if (turn == PlayerTurn.none)
                return;

            if (turn == PlayerTurn.player1)
            {
                p.Image = player1.Image;
                winner = GetWinner();
                //Thread.Sleep(1000);
                if(winner==Winner.none)
                 turn = PlayerTurn.player2;
            }
            
            if (turn==PlayerTurn.player2)
            {

                for (int i = 0; i < allPitures.Length; i++)
                {
                    if (allPitures[i].Image == null)
                    {
                        allPitures[i].Image = player2.Image;
                        break;
                    }

                }

            }
            winner = GetWinner();
            if (winner == Winner.none)
            {
                turn = (PlayerTurn.player1 == turn) ? PlayerTurn.player2 : PlayerTurn.player1;
            }
            else
            {
                turn = PlayerTurn.none;
            }
            ShowTurn();
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
