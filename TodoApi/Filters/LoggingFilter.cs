using System;

namespace TodoApi.Filters;

public class LoggingFilter : IEndpointFilter
{
    private readonly ILogger _logger;

    public LoggingFilter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<LoggingFilter>();
    }
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var endpoint = context.HttpContext.GetEndpoint();
        var endpointName = endpoint?.DisplayName ?? "Unknown Endpoint";
        _logger.LogInformation("Handling request for {Endpoint}", endpointName);
        try
        {
            var result = await next(context);
            _logger.LogInformation("Finished handling request for {Endpoint}", endpointName);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while handling request for {Endpoint}", endpointName);
            return Results.Problem("An unexpected error occurred.");
            throw;
        }
    }
}
