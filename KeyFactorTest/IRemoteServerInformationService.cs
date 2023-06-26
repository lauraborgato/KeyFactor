using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyFactor.Application
{
    public interface IRemoteServerInformationService
    {
        DataRecord[] getRemoteRecords(ServerDateTime notBefore, ServerDateTime notAfter, int recordLimit);
    }
}
