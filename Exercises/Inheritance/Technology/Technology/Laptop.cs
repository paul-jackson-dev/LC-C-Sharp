using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technology
{
    internal class Laptop : Computer
    {
        public double Weight { get; set; }

        public Laptop(double gPU, double harddriveSpace, bool hasKeyboard, double weight) : base(gPU, harddriveSpace, hasKeyboard)
        {
            Weight = weight;
        }

        public bool IsHeavy()
        {
            if (Weight > 10)
            {
                return true;
            }
            return false;
        }

        public override string? ToString()
        {

            return string.Concat(GPU, " ", HarddriveSpace, " ", hasKeyboard, " ", Weight);
        }
    }
}
