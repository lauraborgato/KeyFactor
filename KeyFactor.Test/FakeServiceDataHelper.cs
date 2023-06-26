using KeyFactor.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyFactor.Test
{
    internal class FakeServiceDataHelper
    {
        // ServerDateTime helper functions 

        // Returns a ServerDateTime representing the current instant 

        // MAY NOT BE MODIFIED 

        public static ServerDateTime getCurrentTime()
        {
            return new ServerDateTime()
            {
                ServerDate = DateTime.Now,
            };
        }



        // Returns a ServerDateTime representing the earliest supported time 

        // MAY NOT BE MODIFIED 

        public static ServerDateTime getMinValue()
        {
            return new ServerDateTime
            {
                ServerDate = DateTime.Now.AddDays(-4),
            };
        }



        // Returns a ServerDateTime representing a time millis milliseconds after source 

        // MAY NOT BE MODIFIED 

        public static ServerDateTime addMilliseconds(ServerDateTime source, int millis)
        {
            var newServerDate = source.ServerDate.AddMilliseconds(millis);

            return new ServerDateTime()
            {
                ServerDate = newServerDate,
            };
        }


        public static int getMiliseconds(ServerDateTime initialServerDateTime, DateTime finalServerDateTime)
        {
            TimeSpan diffDates = finalServerDateTime - initialServerDateTime.ServerDate;

            return Convert.ToInt32(diffDates.TotalMilliseconds);
        }
    }
}
