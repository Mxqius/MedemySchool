using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedemySchool
{
    public class TimeAndDate
    {
        public string GetTime()
        {
            PersianCalendar PC = new PersianCalendar();
            int day = PC.GetDayOfMonth(DateTime.Now);
            int month = PC.GetMonth(DateTime.Now);
            int year = PC.GetYear(DateTime.Now);
            string time = PC.GetHour(DateTime.Now).ToString().PadLeft(2, '0') + ":" + PC.GetMinute(DateTime.Now).ToString().PadLeft(2, '0') + ":" + PC.GetSecond(DateTime.Now).ToString().PadLeft(2, '0');
            return time;
        }
        public string GetDate()
        {
            PersianCalendar PC = new PersianCalendar();
            int day = PC.GetDayOfMonth(DateTime.Now);
            int month = PC.GetMonth(DateTime.Now);
            int year = PC.GetYear(DateTime.Now);
            string date = year.ToString() + "/" + month.ToString().PadLeft(2, '0') + "/" + day.ToString().PadLeft(2, '0');
            return date;
        }
    }
}
