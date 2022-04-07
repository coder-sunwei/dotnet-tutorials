using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceSample
{
    public class ScopedProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly ILogger<ScopedProcessingService> _logger;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger)
        {
            _logger = logger;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref executionCount);

                _logger.LogInformation(
               "Scoped Processing Service is working. Count: {Count}", executionCount);

                await Task.Delay(1500, cancellationToken);
            }
        }
    }
}
