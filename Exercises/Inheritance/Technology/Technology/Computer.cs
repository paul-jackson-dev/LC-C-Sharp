using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technology
{
    internal class Computer
    {
        public double GPU { get; set; }
        public double HarddriveSpace { get; set; }
        public readonly bool hasKeyboard;

        public Computer(double gPU, double harddriveSpace, bool hasKeyboard)
        {
            GPU = gPU;
            HarddriveSpace = harddriveSpace;
            this.hasKeyboard = hasKeyboard;
        }

        public double AddGPU(double gpu)
        {
            return GPU += gpu;
        }

        public double AddHarddriveSpace(double harddriveSpace)
        {
            return HarddriveSpace += harddriveSpace;
        }

        public override string ToString()
        {
            return string.Concat(GPU, " ", HarddriveSpace, " ", hasKeyboard);
        }
    }
}
