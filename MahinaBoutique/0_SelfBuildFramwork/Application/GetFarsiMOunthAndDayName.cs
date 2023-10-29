using System;
using System.Globalization;

namespace _0_SelfBuildFramwork.Application
{
    public static class GetFarsiMOunthAndDayName
        {
            private static string[] Days = { "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه" };
            private static string[] Months = { "فروردین", "اریبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن" , "اسفند" };
            private static PersianCalendar pc = new PersianCalendar();

            public static string ToPersianDateString(this DateTime date)
            {
                return ($"{Days[pc.GetDayOfWeek(date).GetHashCode()]} {pc.GetDayOfMonth(date)} {Months[pc.GetMonth(date) - 1]} {pc.GetYear(date)}");
            }

            public static string GetDay(this DateTime date)
            {
                return ($"{pc.GetDayOfMonth(date)}");
            }

            public static string GetMounthName(this DateTime date)
            {
                return ($"{Months[pc.GetMonth(date) - 1]}");
            }

       }
}