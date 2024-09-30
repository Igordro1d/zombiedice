using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombiedice
{
    public abstract class Die
    {
        protected string[] _dieSideArray;
        /// <summary>
        /// create die with correct number for each facing
        /// </summary>
        /// <param name="brain">number of sides with brain</param>
        /// <param name="shotgun">number of sides with shotgun</param>
        /// <param name="footprint">number of sides with footprint</param>
        public Die(int brain, int shotgun, int footprint) 
        {
            _dieSideArray = new string[6];
            int index = 0;
            //add number of brains for a given die
            for (int i = 0; i < brain; i++)
            {
                _dieSideArray[index++] = "brain";
            }
            //add number of shotgun for a given die
            for (int i = 0; i < shotgun; i++)
            {
                _dieSideArray[index++] = "shotgun";
            }
            //add number of footprint for a given die
            for (int i = 0; i < footprint; i++)
            {
                _dieSideArray[index++] = "footprint";
            }
        }
        /// <summary>
        /// rolls die
        /// </summary>
        /// <returns>value of the facing</returns>
        public string Roll() 
        {
            Random rand = new Random();
            return _dieSideArray[rand.Next(_dieSideArray.Length)];
        }


    }
}
