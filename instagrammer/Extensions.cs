﻿using System;

namespace instagrammer {
    public static partial class Extensions {
        public static DateTime ConvertFromUnixTimestamp(this double timestamp) {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}
