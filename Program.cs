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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form4());
        }
    }
}
