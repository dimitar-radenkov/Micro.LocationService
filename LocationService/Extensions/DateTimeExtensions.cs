using System;

namespace LocationService.Extensions
{
    public static class DateTimeExtensions
    {
        public static UInt32 ToUnixTime(this DateTime datetime)
        {
            var sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (UInt32)(datetime - sTime).TotalSeconds;
        }

        public static DateTime ToDateTime(this UInt32 unixtime)
        {
            var sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return sTime.AddSeconds(unixtime);
        }
    }
}
