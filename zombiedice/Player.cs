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
        /// <summary>
        /// gets the number of brains the player has
        /// </summary>
        public int Brains { get { return _brains; } }
        /// <summary>
        /// gets the number of shotguns the player has
        /// </summary>
        public int Shotguns { get { return _shotguns; } }
        /// <summary>
        /// gets the number of footprints the player has
        /// </summary>
        public int Footprints { get { return _footprints; } }
        /// <summary>
        /// creates a player
        /// </summary>
        public Player()
        {
            _brains = 0;         
            _shotguns = 0;       
            _footprints = 0;     
        }
        /// <summary>
        /// rolls the dice in the hand and updates the player's stats
        /// </summary>
        /// <param name="hand"></param>
        public void Hand(Die[] hand)
        {
            foreach (Die d in hand)
            {
                Die.DieResult result = d.Roll();
                switch (result)
                {
                    case Die.DieResult.Brain:
                        _brains++;
                        break;
                    case Die.DieResult.Shotgun:
                        _shotguns++;
                        break;
                    case Die.DieResult.Footprint:
                        _footprints++;
                        break;
                }
            }
        }
    }
}
