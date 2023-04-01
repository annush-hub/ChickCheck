using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public static class TimeAdapter
    {
        public static DateTime unixToDt(int unixTimestamp)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unixTimestamp).ToLocalTime();
            return dt;
        }
    }
}
