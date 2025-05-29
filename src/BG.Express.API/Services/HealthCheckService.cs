using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BG.Express.API.Services.Implementations;

public class HealthCheckService : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            await Task.WhenAll(new Task[] { });

            return new HealthCheckResult(HealthStatus.Healthy);
        }
        catch (Exception ex)
        {
            return new HealthCheckResult(HealthStatus.Unhealthy);
        }
    }
}
