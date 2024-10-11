using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zombiedice
{
    public class Player
    {
        private int _brains;
        private int _shotguns;
        private int _footprints;
        private int _score;
        private List<Die> _footprintDice;
        private List<Die> _leftoverDice;
        private List<Die> _currentDice;
        private bool _isTurn;
        /// <summary>
        /// gets the current dice in the player's hand
        /// </summary>
        public List<Die> CurrentDice { get { return _currentDice; } }
        /// <summary>
        /// gets the number of brains the player has
        /// </summary>
        public int Brains { get { return _brains; } set { _brains = value; } }
        /// <summary>
        /// gets the number of shotguns the player has
        /// </summary>
        public int Shotguns { get { return _shotguns; } set { _shotguns = value; } }
        /// <summary>
        /// gets the number of footprints the player has
        /// </summary>
        public int Footprints { get { return _footprints; } set { _footprints = value; } }
        /// <summary>
        /// gets the player's score
        /// </summary>
        public int Score { get { return _score; } set { _score = value; } }
        /// <summary>
        /// checks if its the players turn
        /// </summary>
        public bool IsTurn { get { return _isTurn; } set { _isTurn = value; } }
        /// <summary>
        /// creates a player
        /// </summary>
        public Player()
        {
            _brains = 0;         
            _shotguns = 0;       
            _footprints = 0;
            _score = 0;
            _footprintDice = new List<Die>();
            _leftoverDice = new List<Die>();
            _currentDice = new List<Die>();
            _isTurn = true;
        }
        /// <summary>
        /// rolls the dice in the hand and updates the player's stats
        /// </summary>
        /// <param name="hand"></param>
        public void Hand(Cup cup)
        {
            Die[] diceToRoll = cup.ShakeCup();

            // Reset footprints list at the start of the roll
            _footprintDice.Clear();
            _currentDice.Clear();

            foreach (Die d in diceToRoll)
            {
                _currentDice.Add(d);
                Die.DieValue result = d.Roll();  
                
                switch (result)
                {
                    case Die.DieValue.Brain:
                        _brains++;            
                        cup.RemoveDie(d);
                        _leftoverDice.Add(d);
                        cup.AddDie(d);
                        break;

                    case Die.DieValue.Shotgun:
                        _shotguns++;           
                        cup.RemoveDie(d);
                        _leftoverDice.Add(d);
                        break;

                    case Die.DieValue.Footprint:
                        _footprints++;
                        cup.RemoveDie(d);
                        _footprintDice.Add(d); 
                        break;
                }
            }
        }
        /// <summary>
        /// returns the current hand of the player
        /// </summary>
        /// <returns></returns>
        public string[] CurrentHand()
        {
            List<string> diceResults = new List<string>();

            foreach (Die d in _currentDice)
            {
                diceResults.Add(d.GetType().Name); 
            }

            return diceResults.ToArray();
        }
        /// <summary>
        /// resets the player's stats
        /// </summary>
        public void Reset()
        {
            _brains = 0;
            _shotguns = 0;
            _footprints = 0;
            _footprintDice.Clear();
            _leftoverDice.Clear();

        }   
        /// <summary>
        /// rolls the dice in the hand that are footprints
        /// </summary>
        /// <param name="cup"></param>
        public void RollAgain(Cup cup)
        {
            int diceToRoll = 3 - _footprintDice.Count;
            Die[] newDice = cup.ShakeCup(diceToRoll);
            List<Die> diceToRollList = new List<Die>(_footprintDice);
            diceToRollList.AddRange(newDice);
            _footprints = 0;
            _footprintDice.Clear();
            Hand(cup);
        }

    }
}
