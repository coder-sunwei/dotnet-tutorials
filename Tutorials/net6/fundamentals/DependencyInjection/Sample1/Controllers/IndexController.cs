using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample1.Services;
using System.Text;

namespace Sample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationScoped _scopedOperation;

        public IndexController(
                      ILogger<IndexController> logger,
                      IOperationTransient transientOperation,
                      IOperationScoped scopedOperation,
                      IOperationSingleton singletonOperation
            )
        {
            _logger = logger;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
        }

        [HttpGet]
        public IActionResult Index()
        {

            _logger.LogInformation("Transient: " + _transientOperation.OperationId);
            _logger.LogInformation("Scoped: " + _scopedOperation.OperationId);
            _logger.LogInformation("Singleton: " + _singletonOperation.OperationId);

            var sb = new StringBuilder();

            sb.AppendLine("Transient: " + _transientOperation.OperationId);
            sb.AppendLine("Scoped: " + _scopedOperation.OperationId);
            sb.AppendLine("Singleton: " + _singletonOperation.OperationId);

            return Content(sb.ToString());
        }
    }
}
