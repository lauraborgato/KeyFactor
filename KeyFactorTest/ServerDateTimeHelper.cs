namespace KeyFactor.Application
{
    public static class ServerDateTimeHelper
    {
        // ServerDateTime helper functions 

        // Returns a ServerDateTime representing the current instant 

        // MAY NOT BE MODIFIED 

        public static ServerDateTime getCurrentTime()
        {
           throw new NotImplementedException();
        }


        // Returns a ServerDateTime representing the earliest supported time 

        // MAY NOT BE MODIFIED 

        public static ServerDateTime getMinValue()
        {
            throw new NotImplementedException();
        }



        // Returns a ServerDateTime representing a time millis milliseconds after source 

        // MAY NOT BE MODIFIED 

        public static ServerDateTime addMilliseconds(ServerDateTime source, int millis)
        {
            throw new NotImplementedException();
        }


        public static int getMiliseconds(ServerDateTime initialServerDateTime, DateTime finalServerDateTime) {
            TimeSpan diffDates = finalServerDateTime - initialServerDateTime.ServerDate;

            return Convert.ToInt32(diffDates.TotalMilliseconds);
        }

    }
}
