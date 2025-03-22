using System;
using System.Collections.Generic;
using System.Linq;

namespace KalkulatorApp
{
    public class ScientificCalculator
    {
        private readonly Calculator calculator;

        public ScientificCalculator(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public double Power(double x, double y) => Math.Pow(x, y);

        public double SquareRoot(double x)
        {
            if (x < 0)
                throw new ArgumentException("Nie można pierwiastkować liczby ujemnej.");
            return Math.Sqrt(x);
        }

        public double Log(double x)
        {
            if (x <= 0)
                throw new ArgumentException("Logarytm działa tylko dla liczb dodatnich.");
            return Math.Log(x);
        }

        public double SumSequence(IEnumerable<double> nums) => nums.Sum();

        public double Average(IEnumerable<double> nums) => nums.Average();

        public double MaximumNum(IEnumerable<double> nums) => nums.Max();

        public double MinimumNum(IEnumerable<double> nums) => nums.Min();
    }
}
