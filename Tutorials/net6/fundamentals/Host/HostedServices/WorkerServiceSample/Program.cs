using WorkerServiceSample;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //services.AddHostedService<Worker>();
        //services.AddHostedService<TimedHostedService>();
        //services.AddHostedService<ConsumeScopedServiceHostedService>();
        //services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
        services.AddSingleton<MonitorLoop>();
        services.AddHostedService<QueuedHostedService>();
        services.AddSingleton<IBackgroundTaskQueue>(ctx =>
        {
            var queueCapacity = 100;
            return new BackgroundTaskQueue(queueCapacity);
        });
    })
    .Build();

var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
monitorLoop.StartMonitorLoop();

await host.RunAsync();
