using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributionGenerator
{
    class LemerRandom
    {
        private const int a = 1103515245;
        private const int m = 2147483647;
        private const int c = 12345;
        private long next;

        public LemerRandom()
        {
            next = (long) DateTime.Now.ToOADate();
        }

        public double NextDouble()
        {
            next = (a * next + c) % m;
            return (next * 1.0) / m;
        }
    }
}
