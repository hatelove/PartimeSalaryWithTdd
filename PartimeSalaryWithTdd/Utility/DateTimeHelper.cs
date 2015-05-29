using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartimeSalaryWithTdd.Utility
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// 傳入兩個時間，回傳間隔的小時數
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static double TotalHours(DateTime start, DateTime end)
        {
            var result = new TimeSpan(end.Ticks - start.Ticks).TotalHours;

            return result;
        }
    }
}
