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
        /// <summary>
        /// initialises the dice in the cup
        /// </summary>
        public Cup()
        {
            _diceList = new List<Die>();
            //add 6 green dice
            for (int i = 0; i < 6; i++)
            {
                _diceList.Add(new Green_Die());
            }

            //add 4 yellow dice
            for (int i = 0; i < 4; i++)
            {
                _diceList.Add(new Yellow_Die());
            }

            //add 3 red dice
            for (int i = 0; i < 3; i++)
            {
                _diceList.Add(new Red_Die());
            }

        }
        /// <summary>
        /// add die to cup
        /// </summary>
        /// <param name="die">die</param>
        public void AddDie(Die die)
        {
            _diceList.Add(die);
        }
        /// <summary>
        /// shakes cup and returns array with 3 dice
        /// </summary>
        /// <returns></returns>
        public Die[] ShakeCup()
        {
            Random rand = new Random();
            Die[] dice = new Die[3];
            for (int i = 0; i < 3; i++)
            {
                dice[i] = _diceList[rand.Next(_diceList.Count)];
            }
            return dice;
        }

    }
}
