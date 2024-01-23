using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop
{
    public class ConeComparer : IComparer<Cone>
    {
        public int Compare(Cone x, Cone y)
        {
            int returnInt = -1;
            if (x.Cost == y.Cost)
            {
                returnInt = 0;
            }
            else if (x.Cost > y.Cost)
            {
                returnInt = 1;
            }

            return returnInt;
        }
    }
}
