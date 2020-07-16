using System;
using System.Collections.Generic;
using System.Text;
using BAi8_TDD;
using NUnit.Framework;

namespace NUnitCacular
{
    class testTamgiac
    {
        private Tamgiac _tamgiac;
        [SetUp]
        public void Setup()
        {
            _tamgiac = new Tamgiac();

        }
        //[TestCase(4, 8, 4,ExpectedResult ="tam giac can")]
        //[TestCase(4, 4, 4, ExpectedResult = "tam giac deu")]
        //[TestCase(5, 6, 4, ExpectedResult = "tam giac thuong")]
        //[TestCase(8, 3, 2, ExpectedResult = "Khong phai tam giac")]

        //public string testtamgiac0(int a, int b, int c)
        //{
        //    return _tamgiac.Kiemtratamgiac(a, b, c);
        //}

        [TestCase(4, 3, 4)]
        [TestCase(4, 5, 6)]
        public void testtamgiac1(int a, int b, int c)
        {
            var expected = "tam giac can";
            var result = _tamgiac.Kiemtratamgiac(a, b, c);
            Assert.AreEqual(expected, result);
        }

        [TestCase(4, 12, 4)]
        [TestCase(4, 12, 6)]
        public void testtamgiac2(int a, int b, int c)
        {
            var expected = "Khong phai tam giac";
            var result = _tamgiac.Kiemtratamgiac(a, b, c);
            Assert.AreEqual(expected, result);
        }
        [TestCase(4, 4, 4)]
        [TestCase(8, 8, 8)]
        public void testtamgiac3(int a, int b, int c)
        {
            var expected = "tam giac deu";
            var result = _tamgiac.Kiemtratamgiac(a, b, c);
            Assert.AreEqual(expected, result);
        }
    }
}
