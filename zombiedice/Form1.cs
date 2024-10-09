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
    Player player2;
    Cup gameCup;
    public Form1()
    {
        InitializeComponent();

        player1 = new Player();
        player2 = new Player();
        player2.IsTurn = false;  // Start with player1's turn
        gameCup = new Cup();
        buttonRollAgain.Visible = false; // roll again button hidden initially
    }

    /// <summary>
    /// Rolls dice for the current player
    /// </summary>
    private void button1_Click(object sender, EventArgs e)
    {
        if (player1.IsTurn)
        {
            player1.Hand(gameCup);

            if (player1.Shotguns >= 3)
            {
                MessageBox.Show("Player1 got 3 shotguns! Player1 loses their turn!");
                EndPlayerTurn(player1);
                    player1.IsTurn = false;
                    player2.IsTurn = true;  // Switch to player2
                }
            else
            {
                
                Console.WriteLine("Player1: Brains: " + player1.Brains + " Shotguns: " + player1.Shotguns + " Footprints: " + player1.Footprints);
            }
        }
        else if (player2.IsTurn)
        {
            player2.Hand(gameCup);

            if (player2.Shotguns >= 3)
            {
                MessageBox.Show("Player2 got 3 shotguns! Player2 loses their turn!");
                EndPlayerTurn(player2);
                    player2.IsTurn = false;
                    player1.IsTurn = true;  // Switch to player1
                }
            else
            {
               
                Console.WriteLine("Player2: Brains: " + player2.Brains + " Shotguns: " + player2.Shotguns + " Footprints: " + player2.Footprints);
            }
        }

        buttonStart.Visible = false;  
        buttonRollAgain.Visible = true;   
    }

    /// <summary>
    /// Handles rolling again for the current player
    /// </summary>
    private void button3_Click(object sender, EventArgs e)
    {
        if (player1.IsTurn)
        {
            player1.RollAgain(gameCup);

            if (player1.Shotguns >= 3)
            {
                MessageBox.Show("Player1 got 3 shotguns! Player1 loses their turn!");
                EndPlayerTurn(player1);
                    player1.IsTurn = false;
                    player2.IsTurn = true;  // Switch to player2
                }
            else
            {
                
                Console.WriteLine("Player1: Brains: " + player1.Brains + " Shotguns: " + player1.Shotguns + " Footprints: " + player1.Footprints);
            }
        }
        else if (player2.IsTurn)
        {
            player2.RollAgain(gameCup);

            if (player2.Shotguns >= 3)
            {
                MessageBox.Show("Player2 got 3 shotguns! Player2 loses their turn!");
                EndPlayerTurn(player2);
                player2.IsTurn = false;
                player1.IsTurn = true;  // Switch to player1

                }
            else
            {
                
                Console.WriteLine("Player2: Brains: " + player2.Brains + " Shotguns: " + player2.Shotguns + " Footprints: " + player2.Footprints);
            }
        }

        buttonStart.Visible = true;  
        buttonRollAgain.Visible = false;  
    }

    /// <summary>
    /// Ends the current player's turn, switches to the next player
    /// </summary>
    private void button2_Click(object sender, EventArgs e) 
    {
        if (player1.IsTurn)
        {
            player1.Score += player1.Brains;
            EndPlayerTurn(player1);
            player1.IsTurn = false;
            player2.IsTurn = true;  // Switch to player2
        }
        else if (player2.IsTurn)
        {
            player2.Score += player2.Brains;
            EndPlayerTurn(player2);
            player2.IsTurn = false;
            player1.IsTurn = true;  // Switch to player1
        }

        // check if anyone reached the winning condition
        if (player1.Score >= 13)
        {
            MessageBox.Show("Player1 wins with 13 brains!");
            ResetGame();
        }
        else if (player2.Score >= 13)
        {
            MessageBox.Show("Player2 wins with 13 brains!");
            ResetGame();
        }

        // Update score display
        textBox1.Text =  player1.Score.ToString();
        textBox2.Text = player2.Score.ToString();
        gameCup = new Cup();

        
    }

    /// <summary>
    /// Resets a player's stats at the end of their turn
    /// </summary>
    private void EndPlayerTurn(Player player)
    {
        player.Reset();
        gameCup = new Cup();
        buttonStart.Visible = true;   
        buttonRollAgain.Visible = false;  
    }

    /// <summary>
    /// Resets the entire game for both players
    /// </summary>
    private void ResetGame()
    {
        player1.Reset();
        player2.Reset();
        gameCup = new Cup();
        player1.Score = 0;
        player2.Score = 0;
        textBox1.Text = "0";
        textBox2.Text = "0";
        }
}

}
