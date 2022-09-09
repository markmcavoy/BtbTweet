using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiteTheBullet.BtbTweet.Extensions
{
    public static class DateTimeHelper
    {
        public static string ApproxAge(this DateTime input)
        {
            var timeDiff = DateTime.Now - input;

            var timeDiffMin = timeDiff.TotalMinutes;
            var timeDiffHours = timeDiff.TotalHours;
            var timeDiffDay = timeDiff.TotalDays;

            if (timeDiffDay >= 1)
                return ($"<p>About {Math.Round(timeDiffDay, 0, MidpointRounding.AwayFromZero)} days ago</p>");
            else if (timeDiffHours >= 1)
                return ($"<p> About {Math.Round(timeDiffHours, 0, MidpointRounding.AwayFromZero)} hours ago</p>");
            else
                return ($"<p>About {Math.Round(timeDiffMin, 0, MidpointRounding.AwayFromZero)} minutes ago</p>");
        }
    }
}