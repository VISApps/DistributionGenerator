using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributionGenerator
{
    public enum RandomType { Standart, Conq, Lemer};

    class RandomGenerator
    {
        private static Random random = new Random();
        private static ConRandom conrandom = new ConRandom();
        private static LemerRandom lemerrandom = new LemerRandom();
        private static LaggedFibRng laggedFibRng = new LaggedFibRng();
        private static WichmannRng wichmannRng = new WichmannRng(1);

        public RandomGenerator()
        {

        }

        public double NextDouble(RandomType type)
        {
            switch (type)
            {
                case RandomType.Standart:
                    return random.NextDouble();
                case RandomType.Conq:
                    return conrandom.NextDouble();
                case RandomType.Lemer:
                    return laggedFibRng.NextDouble();
                default:
                    return random.NextDouble();
            }
        }
    }
}
