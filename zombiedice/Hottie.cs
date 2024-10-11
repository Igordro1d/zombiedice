using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombiedice
{
    public class Hottie : Die
    {
        /// <summary>
        /// create hottie die with 1 brain, 2 shotgun, 3 footprint
        /// </summary>
        public Hottie() : base(1, 2, 3)
        { }
        public override string ToString()
        {
            return "Hottie Die";
        }
    }
}
