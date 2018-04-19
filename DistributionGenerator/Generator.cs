using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributionGenerator
{
    public enum Distribution { Even, Triangular, Exponential, Trapezoidal, Normal};

    public class Generator
    {
        
        private static RandomGenerator random = new RandomGenerator();

        public Generator()
        {

        }

        public double[] Generate(int a, int b, int n, RandomType type)
        {
            double[]  values = new double[n];
            for(int i=0; i<n; i++)
            {
                values[i] = random.NextDouble(type) * (b - a) + a;
            }
            return values;
        }

        public double[,] CreateHistogram(double a, double b, int n, int intervals, Distribution distribution, double c, double d, RandomType type)
        {
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = random.NextDouble(type) * (b - a) + a;
            }
            switch (distribution)
            {
                case Distribution.Triangular:
                    //values = ConvertToTriangular(values, param);
                    values = GenerateTriangular(a, b, c, n, type);
                    //n = n / 2;
                    break;
                case Distribution.Exponential:
                    values = GenerateExponential(a, b, n, type);
                    break;
                case Distribution.Trapezoidal:
                    values = GenerateTrapezoidal(a,b,c,d,n, type);
                    break;
                case Distribution.Normal:
                    values = GenerateNormal(c,d,n,12,type);
                    break;
            }
            double h = Math.Abs((values.Max() - values.Min()) / intervals);
            double[,] result = new double[intervals, 2];
            double min = values.Min();
            for (int i = 0; i < intervals; i++)
            {
                result[i, 0] = min + (h / 2);
                result[i, 1] = 0;
                min = min + h;
            }
            min = values.Min();
            Array.Sort(values);
            int f = 0;
            int j = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < min + h)
                {
                    f++;
                }
                else
                {
                    result[j, 1] = (double)f / (double)n;
                    //result[j, 2] = f;
                    f = 0;
                    j++;
                    min = min + h;
                }
            }
            if (j < intervals)
            {
                result[j, 0] = min + (h / 2);
                result[j, 1] = (double)f / (double)n;
                j++;
            }
            return result;
        }

        private double[] ConvertToTriangular(double[] values, int t)
        {
            int size = values.Length / 2;
            double[] result = new double[size];
            int j = 0;
            for(int i = 0; i < size; i++)
            {
                result[i] = t * (values[j] + values[j + 1]);
                j = j + 2;
            }
            return result;
            
        }

        private double[] ConvertToExponential(double[] values, int l)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (-1) * (1/l) * Math.Log(values[i]) ;
            }
            return values;
        }

        private double[] GenerateExponential(double a, double b, int n, RandomType type)
        {
            double[] result = new double[n];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (-1) * Math.Log(random.NextDouble(type));
            }
            return result;
        }

        private double[] GenerateTriangular(double a, double b,double c, int n, RandomType type)
        {
            double[] result = new double[n];
            double f = (c - a) / (b - a);
            for(int i=0; i<n; i++)
            {
                double rnd = random.NextDouble(type);
                if (rnd < f)
                {
                    result[i] = a + Math.Sqrt(rnd * (b - a) * (c - a));
                }
                else {
                    result[i] = b - Math.Sqrt((1 - rnd) * (b - a) * (b - c));
                }
            }
            return result;
        }

        private double[] GenerateTrapezoidal(double a, double b, double c, double d, int n, RandomType type) {
            double[] first = new double[n];
            double[] second = new double[n];
            double[] result = new double[n];
            for (int i = 0; i < n; i++)
            {
                first[i] = random.NextDouble(type) * (b - a) + a;
            }
            for (int i = 0; i < n; i++)
            {
                second[i] = random.NextDouble(type) * (d - c) + c;
            }
            for(int i = 0; i < n; i++)
            {
                result[i] = first[i] + second[i];
            }
            return result;
        }

        private double[] GenerateNormal(double m, double sigma, int n, int count, RandomType type)
        {
            double[] result = new double[n];
            for(int i=0; i < n; i++)
            {
                double value = 0;
                for(int j=0; j < count; j++)
                {
                    value = value + random.NextDouble(type);
                }
                result[i] = m + (sigma * (Math.Sqrt(12 / count) * (value - (count/2))));
            }
            return result;
        }
    }
}
