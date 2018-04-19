using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributionGenerator
{
    class LaggedFibRng
    {
        private const int k = 10;
        private const int j = 7;
        private const int m = 2147483647; 
        private List<int> vals = null;
        private int seed;
        public LaggedFibRng()
        {
            seed = (int) DateTime.Now.ToOADate();
            vals = new List<int>();
            for (int i = 0; i < k + 1; ++i)
                vals.Add(seed);
            if (seed % 2 == 0) vals[0] = 11;
            for (int ct = 0; ct < 1000; ++ct)
            {
                double dummy = this.NextDouble();
            }
        }
        public double NextDouble()
        {
            int left = vals[0] % m;  
            int right = vals[k - j] % m; 
            long sum = (long)left + (long)right;
            seed = (int)(sum % m);
            vals.Insert(k + 1, seed);
            vals.RemoveAt(0);
            return (1.0 * seed) / m;
        }
    }
}
