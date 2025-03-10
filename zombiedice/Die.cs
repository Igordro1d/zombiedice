﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombiedice
{
    public abstract class Die
    {
        public enum DieValue
        {
            Brain,
            Shotgun,
            Footprint
        }
        protected DieValue[] _dieSideArray;
        /// <summary>
        /// create die with correct number for each facing
        /// </summary>
        /// <param name="brain">number of sides with brain</param>
        /// <param name="shotgun">number of sides with shotgun</param>
        /// <param name="footprint">number of sides with footprint</param>
        /// 
        public Die(int brain, int shotgun, int footprint) 
        {
            _dieSideArray = new DieValue[6];
            int index = 0;
            for (int i = 0; i < brain; i++)
            {
                _dieSideArray[index++] = DieValue.Brain;
            }
            for (int i = 0; i < shotgun; i++)
            {
                _dieSideArray[index++] = DieValue.Shotgun;
            }
            for (int i = 0; i < footprint; i++)
            {
                _dieSideArray[index++] = DieValue.Footprint;
            }
        }
        /// <summary>
        /// rolls die
        /// </summary>
        /// <returns>value of the facing</returns>
        public DieValue Roll() 
        {
            Random rand = new Random();
            return _dieSideArray[rand.Next(_dieSideArray.Length)];
        }


    }
}
