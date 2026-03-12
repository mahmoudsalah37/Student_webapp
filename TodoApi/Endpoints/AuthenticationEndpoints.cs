
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs.Authentication;
using TodoApi.Filters;
using TodoApi.Services;

namespace TodoApi.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/register", async ([FromBody] RegisterDto request, IAuthManager authManager) =>
        {
            var errors = await authManager.Register(request);
            if (!errors.Any())
                return Results.Ok();
            return Results.BadRequest(errors);
        })
        .AddEndpointFilter<ValidatationFilter<RegisterDto>>()
        .WithTags("Authentication")
        .AllowAnonymous()
        .WithName("Register")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest);

        routes.MapPost("/login", async ([FromBody] LoginDto request, IValidator<LoginDto> validator, IAuthManager authManager) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.ToDictionary());

            var response = await authManager.Login(request);
            if (response is null)
                return Results.Unauthorized();
            return Results.Ok(response);
        })
        .AddEndpointFilter<ValidatationFilter<LoginDto>>()
        .WithTags("Authentication")
        .AllowAnonymous()
        .WithName("Login")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized);


    }

}