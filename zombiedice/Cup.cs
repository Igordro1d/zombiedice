using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombiedice
{
    public class Cup
    {
        protected List<Die> _diceList;
        protected List<Die> _brainList;
        /// <summary>
        /// initialises the dice in the cup
        /// </summary>
        public Cup()
        {
            _diceList = new List<Die>();
            _brainList = new List<Die>();
            //add 6 green dice
            for (int i = 0; i < 6; i++)
            {
                _diceList.Add(new Green_Die());
            }

            //add 2 yellow dice
            for (int i = 0; i < 2; i++)
            {
                _diceList.Add(new Yellow_Die());
            }

            //add 2 hottie dice
            for (int i = 0; i < 2; i++)
            {
                _diceList.Add(new Hottie());
            }

            //add 3 red dice
            for (int i = 0; i < 3; i++)
            {
                _diceList.Add(new Red_Die());
            }

        }
        /// <summary>
        /// removes die from cup
        /// </summary>
        /// <param name="die"></param>
        public void RemoveDie(Die die)
        {
            _diceList.Remove(die);
        }
        public void AddDie(Die die)
        {
            _brainList.Add(die);
        }
        /// <summary>
        /// shakes cup and returns array with 3 dice
        /// </summary>
        /// <returns></returns>
        public Die[] ShakeCup(int numDice = 3)
        {
            Random rand = new Random();
            Die[] dice = new Die[3];
            if (_diceList.Count < 3)
            {
                // if no dice left in the cup, add set-aside brain dice back to the cup
                _diceList.AddRange(_brainList);
                _brainList.Clear(); 
            }
            for (int i = 0; i < 3; i++)
            {
                dice[i] = _diceList[rand.Next(_diceList.Count)];
            }
            return dice;
           

        }

    }
}
