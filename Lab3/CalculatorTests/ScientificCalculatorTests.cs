using KalkulatorApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    public class ScientificCalculatorTests
    {
        private ScientificCalculator scientificCalculator;

        [SetUp]
        public void Setup()
        {
            scientificCalculator = new ScientificCalculator(new Calculator());

        }

        [Test]
       public void Power_ReturnsCorrectResult()
        {
            Assert.AreEqual(25, scientificCalculator.Power(5, 2));

        }

        [Test]

        public void SquareRoot_ReturnsCorrectResult()
        {
            Assert.AreEqual(5, scientificCalculator.SquareRoot(25));
        }

        [Test]
        public void SquareRoot_NegativeNumber_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => scientificCalculator.SquareRoot(-25));
        }

        [Test]
        public void Log_ReturnsCorrectResult()
        {
            Assert.AreEqual(1, scientificCalculator.Log(Math.E), 0.00001);
        }
        [Test]
        public void Log_NonPositive_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => scientificCalculator.Log(0));
        }

        [Test]
        public void SumSequence_ReturnsCorrectResult()
        {
            Assert.AreEqual(35, scientificCalculator.SumSequence(new List<double> { 25, 6, 4 }));
        }

        [Test]
        public void Average_ReturnsCorrectResult()
        {
            var result = scientificCalculator.Average(new List<double> { 25, 6, 4 });
            Assert.AreEqual(11.666666666666666, result, 0.0001);
        }

        [Test]
        public void MaximumNum_ReturnsCorrectResult()
        {
            Assert.AreEqual(25, scientificCalculator.MaximumNum(new List<double> { 25, 4, 6 }));
        }

        [Test]
        public void MinimumNum_ReturnsCorrectResult()
        {
            Assert.AreEqual(4, scientificCalculator.MinimumNum(new List<double> { 25, 4, 6 }));
        }
    }
}
