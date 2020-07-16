using BAi8_TDD;
using NUnit.Framework;

namespace NUnitCacular
{
    public class textprogram
    {
        private CalculatorService calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new CalculatorService();
        }

        [Test]
        [TestCase(10)]
        [TestCase(23)]
        [TestCase(14)]
        public void TestAdd1(int value)
        {
            Assert.AreEqual(value, calculator.Add(0, value));
        }
        [Test]
        [TestCase(50)]
        [TestCase(24)]
        [TestCase(144)]
        public void TestSub1(int value)
        {
            Assert.AreEqual(-value, calculator.Sub (0, value));
        }
        [Test]
        [TestCase(50)]
        [TestCase(24)]
        [TestCase(144)]
        public void TestSub2(int value)
        {
            Assert.IsTrue (-value == calculator.Sub(0, value));
        }
    }
}