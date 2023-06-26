using KeyFactor.Application;

namespace KeyFactor.Test
{
    internal class FakeRemoteServerService : IRemoteServerInformationService
    {
        public DataRecord[] getRemoteRecords(ServerDateTime notBefore, ServerDateTime notAfter, int recordLimit)
        {
            var cacheData = new List<DataRecord>();
            ServerDateTime initialDate = FakeServiceDataHelper.getMinValue();
            int miliseconds = Convert.ToInt32(new TimeSpan(0, 30, 0).TotalMilliseconds);
            int id = 0;
            while(initialDate.ServerDate < FakeServiceDataHelper.getCurrentTime().ServerDate)
            {
                cacheData.Add(new DataRecord()
                {
                    ID = id,
                    CreationDate = FakeServiceDataHelper.addMilliseconds(initialDate, miliseconds),
                    Data = new byte[12]
                });

                id++;

                initialDate = FakeServiceDataHelper.addMilliseconds(initialDate, miliseconds);

            }



            return cacheData
                .Where(x => x.CreationDate.ServerDate >= notBefore.ServerDate && x.CreationDate.ServerDate <= notAfter.ServerDate)
                .Take(recordLimit)
                .ToArray();
        }
    }
}
