using KalkulatorApp;

namespace CalculatorTests
{
    public class Tests

    {
        private Calculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ReturnsCorrectResult()
        {
            Assert.AreEqual(28,calculator.Add(13,15));
        }

        [Test]
        public void Subtract_ReturnsCorrectResult()
        {
            Assert.AreEqual(15, calculator.Subtract(28, 13));
        }

        [Test]
        public void Multiply_ReturnsCorrectResult()
        {
            Assert.AreEqual(195, calculator.Multiply(13, 15));
        }

        [Test]
        public void Divide_ReturnsCorrectResult()
        {
            Assert.AreEqual(13,calculator.Divide(195, 15));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(195, 0));
        }


    }
}