using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
     class DateModifier
    {
        public int CalcDiffDays(string date1, string date2)
        {
            string format = "yyyy MM dd";

            var firstDate = DateTime.ParseExact(date1, format, null);
            var secondDate = DateTime.ParseExact(date2, format, null);

            return Math.Abs((firstDate - secondDate).Days);
        }
    }
}
