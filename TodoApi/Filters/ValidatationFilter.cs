
using FluentValidation;
using TodoApi.DTOs.Authentication;

namespace TodoApi.Filters;

public class ValidatationFilter<T> : IEndpointFilter where T : class
{
    private readonly IValidator<T> _validator;
    public ValidatationFilter(IValidator<T> validator)
    {
        _validator = validator;
    }
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<T>>();
        var request = context.GetArgument<T>(0);
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Results.BadRequest(validationResult.ToDictionary());
        return await next(context);
    }
}
