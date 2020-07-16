using BAi8_TDD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitCacular
{
    class textngaytieptheo
    {
        private ngaytieptheo _ngaytieptheo;

        [SetUp]
        public void Setup()
        {
            _ngaytieptheo = new ngaytieptheo();
        }

        [Test]
        public void TestNgayTiepTheo_Batky()
        {
            var ngayHienTai = new DateTime(2020, 05, 05);

            var kyVong = ngayHienTai.AddDays(1);

            Assert.AreEqual(kyVong, _ngaytieptheo.nextDay(ngayHienTai));
        }

        [Test]
        public void TestNgayTiepTheo_Ngay28Thang2()
        {
            var ngayHienTai = new DateTime(2020, 02, 28);

            var kyVong = ngayHienTai.AddDays(1);

            Assert.AreEqual(kyVong, _ngaytieptheo.nextDay(ngayHienTai));
        }
    }
}
