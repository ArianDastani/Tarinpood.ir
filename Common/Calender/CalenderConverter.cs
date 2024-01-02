using System.Globalization;

namespace Common.Calender
{
    public static class CalenderConverter
    {
        

        public static string ToShamsiNow(this DateTime value)
        {

            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");

        }
        public static string ToShamsi(DateTime? value)
        {

            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear((DateTime)value).ToString("00") + "/" + pc.GetMonth((DateTime)value).ToString("00") + "/" + pc.GetDayOfMonth((DateTime)value);


        }

        public static DateTime ToMiladi(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new PersianCalendar());
        }
        public static DateTime ToShamsi2(DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return Convert.ToDateTime(pc.GetYear(dateTime) + "/" + pc.GetMonth(dateTime) + "/" + pc.GetDayOfMonth(dateTime));
        }
        public static string ToShamsiNowServer(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetHour(value).ToString() + ":" +
                   pc.GetMinute(value).ToString() + ":" +
                   pc.GetSecond(value).ToString() + "    " +
                   pc.GetYear(value) + "/" +
                pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");

            


        }

    }
}
