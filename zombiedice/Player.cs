using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombiedice
{
    public class Player
    {
        private int _brains;
        private int _shotguns;
        private int _footprints;
        private int _score;
        private List<Die> _footprintDice;
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
        /// creates a player
        /// </summary>
        public Player()
        {
            _brains = 0;         
            _shotguns = 0;       
            _footprints = 0;
            _score = 0;
            _footprintDice = new List<Die>();
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

            foreach (Die d in diceToRoll)
            {
                Die.DieResult result = d.Roll();  

                switch (result)
                {
                    case Die.DieResult.Brain:
                        _brains++;            
                        cup.RemoveDie(d);      
                        break;

                    case Die.DieResult.Shotgun:
                        _shotguns++;           
                        cup.RemoveDie(d);      
                        break;

                    case Die.DieResult.Footprint:
                        _footprints++;         
                        _footprintDice.Add(d); 
                        break;
                }
            }
        }
        public void Reset()
        {
            _brains = 0;
            _shotguns = 0;
            _footprints = 0;
            _footprintDice.Clear();
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
