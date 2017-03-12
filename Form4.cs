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

namespace WindowsFormsApplication3
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            showMsg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showMsg()
        {
            string msg= "Hello!\nI made this game for my course project of \nCSE107: Object Oriented Programming.\nThanks to \nDr. Ahmed Wasif Reza\nfor assigning me to this project.";
            char[] c = msg.ToCharArray();
            string p;
            label2.Text = msg;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
    }
}
