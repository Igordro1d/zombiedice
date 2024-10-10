using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombiedice
{
    public class Green_Die : Die
    {
        /// <summary>
        /// creates green die with 3 brains, 1 shotgun, 2 footprint
        /// </summary>
        public Green_Die() : base(3, 1, 2)
        {
        }
        public override string ToString()
        {
            return "Green Die";
        }
    }
}
