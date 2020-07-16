using BAi8_TDD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitCacular
{
    class TinhGiaiThuaTests
    {
        private TinhGiaiThua _tinhGiaiThua;

        [SetUp]
        public void Setup()
        {
            _tinhGiaiThua = new TinhGiaiThua();
        }

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(10)]
        public void TestTinhGiaiThua_BatKy(int val) {
            int expected = 1;

            for(int i = 1; i <= val; i++)
            {
                expected *= i;
            }

            var result = _tinhGiaiThua.Calc(val);

            Assert.AreEqual(expected, result);
        }
    }
}
