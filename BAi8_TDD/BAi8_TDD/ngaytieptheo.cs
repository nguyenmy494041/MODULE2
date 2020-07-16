using System;
using System.Collections.Generic;
using System.Text;

namespace BAi8_TDD
{
    public class ngaytieptheo
    {
        public DateTime nextDay(DateTime date)
        {
            return date.AddDays(1);
        }
    }

}
