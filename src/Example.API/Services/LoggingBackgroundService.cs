using Microsoft.Extensions.Hosting;
using Serilog;

namespace Example.API.Services;

public class LoggingBackgroundService : BackgroundService
{
    private readonly PeriodicTimer _timer;

    public LoggingBackgroundService()
    {
        _timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _timer.WaitForNextTickAsync(stoppingToken) && stoppingToken.IsCancellationRequested is false)
        {
            Log.Information("Background log message");
        }
    }
}
