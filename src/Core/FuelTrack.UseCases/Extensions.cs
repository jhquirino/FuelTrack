// -----------------------------------------------------------------------
//  <copyright file="Extensions.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;

namespace FuelTrack
{
    public static class Extensions
    {
        public static DateTime UNIX_EPOCH = new DateTime(1970, 01, 01, 00, 00, 00, 00, DateTimeKind.Utc);

        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            var utcInput = dateTime.ToUniversalTime();
            var unixTimestamp = Convert.ToInt64((utcInput - UNIX_EPOCH).TotalSeconds);
            return unixTimestamp;
        }

        public static DateTime FromUnixTimestamp(this long timestamp)
        {
            return UNIX_EPOCH.AddSeconds(timestamp).ToLocalTime();
        }
    }
}
