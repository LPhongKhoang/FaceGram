using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceGram.Common
{
    public class DateTimeUtils
    {
        //private const string[] TimeUnit = {"Year"}
        public static string getTimeAgo(DateTime time)
        {
            if (time == DateTime.MinValue)
            {
                return string.Empty;
            }

            DateTime currentTime = DateTime.Now;

            TimeSpan timeSpanAgo = currentTime.Subtract(time);

            int day = timeSpanAgo.Days;
            int year = convertToIntYear(day);
            if(year >= 1)
            {
                return formatTimeAgo(year, "year");
            }
            else
            {
                if (day >= 1)
                {
                    return formatTimeAgo(day, "day");
                }
                else
                {
                    int hour = timeSpanAgo.Hours;
                    if(hour >= 1)
                    {
                        return formatTimeAgo(hour, "hour");
                    }
                    else
                    {
                        int minute = timeSpanAgo.Minutes;
                        return formatTimeAgo(minute, "minute");
                    }
                }
            }

            
        }

        private static int convertToIntYear(int day)
        {
            return day / 365;
        }

        private static string formatTimeAgo(int number, string unit)
        {
            return number <= 1 ? $"{number} {unit} ago" : $"{number} {unit}s ago";
        }

        public static string getKeyTimeStamp()
        {
            return getTimeStamp(DateTime.Now);
        }

        private static string getTimeStamp(DateTime d)
        {
            return d.ToString("yyyyMMddHHmmssffff");
        }

        
    }
}