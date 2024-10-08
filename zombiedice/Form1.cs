using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zombiedice
{
    public partial class Form1 : Form
    {
        Player player1;
        Cup gameCup;
        public Form1()
        {
            InitializeComponent();
            player1 = new Player();
            gameCup = new Cup();
            button3.Visible = false;
        }
        /// <summary>
        /// rolls die first time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            player1.Hand(gameCup);

            if (player1.Shotguns >= 3)
            {
                MessageBox.Show("You got 3 shotguns! You lose!");
                player1.Reset();
            }
            else
            {
                // Display results
                Console.WriteLine("Brains: " + player1.Brains + "\n" + "Shotguns: " + player1.Shotguns + "\n" + "Footprints: " + player1.Footprints);
            }
            button1.Visible = false;
            button3.Visible = true;
        }
        /// <summary>
        /// rolls die again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)  // Roll again button
        {
            player1.RollAgain(gameCup);

            if (player1.Shotguns >= 3)
            {
                MessageBox.Show("You got 3 shotguns! You lose!");
                player1.Reset();
            }
            else
            {
                // Display results
                Console.WriteLine("Brains: " + player1.Brains + "\n" + "Shotguns: " + player1.Shotguns + "\n" + "Footprints: " + player1.Footprints);
            }
            if (player1.Brains == 13)
            {
                MessageBox.Show("You got 13 brains! You win!");
                player1.Reset();
            }   
        }
        /// <summary>
        /// if turn finished, add brain to score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            player1.Score += player1.Brains;
            player1.Reset();
            player1.Brains = 0;
            gameCup = new Cup();
            textBox1.Text = player1.Score.ToString();
            button1.Visible = true;
            button3.Visible = false;
        }
    }
}
