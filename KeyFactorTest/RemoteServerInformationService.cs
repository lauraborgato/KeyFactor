using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyFactor.Application
{
    public class RemoteServerInformationService: IRemoteServerInformationService
    {
        public DataRecord[] getRemoteRecords(ServerDateTime notBefore, ServerDateTime notAfter, int recordLimit)
        {
            throw new NotImplementedException();
        }
    }
}
