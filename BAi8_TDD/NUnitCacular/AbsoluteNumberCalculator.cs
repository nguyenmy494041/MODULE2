using BAi8_TDD;
using NUnit.Framework;

namespace NUnitCacular
{
    public class Tests1
    {
        private AbsoluteNumberCalculator absoluteNumberCalculator;

        [SetUp]
        public void Setup()
        {
            absoluteNumberCalculator = new AbsoluteNumberCalculator();
        }

        [TestCase(10)]
        [TestCase(26)]
        [TestCase(0)]
        public void FindAbsolute1(int value)
        {
            int expected = value;

            int result = absoluteNumberCalculator.FindAbsolute(value);

            Assert.AreEqual(expected, result);
        }
        [TestCase(-10)]
        [TestCase(-26)]
        [TestCase(0)]
        public void FindAbsolute2(int value)
        {
           

            Assert.AreEqual(-value, absoluteNumberCalculator.FindAbsolute(value));
        }


    }
}