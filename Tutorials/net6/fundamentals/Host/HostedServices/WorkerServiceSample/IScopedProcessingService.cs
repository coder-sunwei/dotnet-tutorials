﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceSample
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}
