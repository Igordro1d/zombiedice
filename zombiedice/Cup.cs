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
    }
}
