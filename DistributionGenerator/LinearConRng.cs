using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributionGenerator
{
    public class LinearConRng
    {
        private const long a = 25214903917;
        private const long c = 11;
        private long seed;
        public LinearConRng()
        {
            seed = (long) DateTime.Now.ToOADate();
        }
        private int next(int bits) 
        {
            seed = (seed * a + c) & ((1L << 48) - 1);
            return (int)(seed >> (48 - bits));
        }
        public double NextDouble()
        {
            return (((long)next(26) << 27) + next(27)) / (double)(1L << 53);
        }
    }
}
