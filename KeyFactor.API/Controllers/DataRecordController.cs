using KeyFactor.Application;
using Microsoft.AspNetCore.Mvc;

namespace KeyFactor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataRecordController : ControllerBase
    {
        private readonly ILogger<DataRecordController> _logger;
        private readonly IServerInformationService _service;

        public DataRecordController(ILogger<DataRecordController> logger, IServerInformationService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<DataRecord> Get([FromQuery] int page, [FromQuery] int resultsPerPage)
        {
            _logger.LogInformation("Get Data Records");

            try
            {
                var result = _service.getRecords(page, resultsPerPage);
                _logger.LogInformation("Get Data Records - {0} records returned", result.Length);

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<DataRecord>();
            }
        }
    }
}