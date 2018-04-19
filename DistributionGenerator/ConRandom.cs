using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributionGenerator
{
    class ConRandom
    {
        private const int a = 16807;
        private const int m = 2147483647;
        private long next;

        public ConRandom()
        {
            next = (long) DateTime.Now.ToOADate();
        }

        public double NextDouble()
        {
            next = (a * next) % m;
            return (next * 1.0) / m;
        }
    }
}
