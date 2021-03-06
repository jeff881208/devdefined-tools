﻿using System;

namespace DevDefined.OAuth.Core
{
    public static class DateTimeUtility
    {
        public static long Epoch(this DateTime d)
        {
            return (long) (d.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static string EpocString(this DateTime d)
        {
            return Epoch(d).ToString();
        }

        public static DateTime FromEpoch(int epoch)
        {
            var d = new DateTime(1970, 1, 1);
            d = d.AddSeconds(epoch);
            return d;
        }

        public static long UtcNowEpoch()
        {
            return DateTime.UtcNow.Epoch();
        }

        public static bool IsTimestampExpired(int epochTime, int expirationMinutes)
        {
            return (UtcNowEpoch() > epochTime + expirationMinutes*60);
        }
    }
}