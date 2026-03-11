
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Data;
using TodoApi.DTOs.Authentication;
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
        }).WithTags("Authentication")
        .WithName("Register")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest);

        routes.MapPost("/login", async ([FromBody] LoginDto request, IAuthManager authManager) =>
        {
            var response = await authManager.Login(request);
            if (response is null)
                return Results.Unauthorized();
            return Results.Ok(response);
        }).WithTags("Authentication")
        .WithName("Login")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized);


    }

}