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
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            player1.Hand(gameCup);
            // if they get 3 shotgun they lose and restart their hand
            if (player1.Shotguns >= 3)
            {
                MessageBox.Show("You got 3 shotguns! You lose!");
                player1.Reset();
            }
            Console.WriteLine("Brains: " + player1.Brains + "\n" + "Shotguns: " + player1.Shotguns + "\n" + "Footprints: " + player1.Footprints);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player1.RollAgain(gameCup);

            
            if (player1.Shotguns >= 3)
            {
                MessageBox.Show("You got 3 shotguns! You lose! Your turn is over.");
                player1.Reset();    
            }
            Console.WriteLine("Brains: " + player1.Brains + "\n" + "Shotguns: " + player1.Shotguns + "\n" + "Footprints: " + player1.Footprints);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player1.Score += player1.Brains;
        }
    }
}
