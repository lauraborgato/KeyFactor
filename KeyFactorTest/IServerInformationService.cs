using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyFactor.Application
{
    public interface IServerInformationService
    {
        DataRecord[] getRecords(int pageNumber, int resultsPerPage);
    }
}
