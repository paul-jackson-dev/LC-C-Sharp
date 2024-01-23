using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop
{
    public class FlavorComparer : IComparer<Flavor>
    {

        public int Compare(Flavor x, Flavor y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
}
