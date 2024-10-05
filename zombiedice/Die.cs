using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombiedice
{
    public abstract class Die
    {
        public enum DieResult
        {
            Brain,
            Shotgun,
            Footprint
        }
        protected DieResult[] _dieSideArray;
        /// <summary>
        /// create die with correct number for each facing
        /// </summary>
        /// <param name="brain">number of sides with brain</param>
        /// <param name="shotgun">number of sides with shotgun</param>
        /// <param name="footprint">number of sides with footprint</param>
        /// 
        public Die(int brain, int shotgun, int footprint) 
        {
            _dieSideArray = new DieResult[6];
            int index = 0;
            for (int i = 0; i < brain; i++)
            {
                _dieSideArray[index++] = DieResult.Brain;
            }
            for (int i = 0; i < shotgun; i++)
            {
                _dieSideArray[index++] = DieResult.Shotgun;
            }
            for (int i = 0; i < footprint; i++)
            {
                _dieSideArray[index++] = DieResult.Footprint;
            }
        }
        /// <summary>
        /// rolls die
        /// </summary>
        /// <returns>value of the facing</returns>
        public DieResult Roll() 
        {
            Random rand = new Random();
            return _dieSideArray[rand.Next(_dieSideArray.Length)];
        }


    }
}
