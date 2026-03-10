
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Contracts;
using AutoMapper;
using TodoApi.DTOs.Enrollment;

namespace TodoApi.Endpoints;


public static class EnrollmentEndpoints
{
    public static void MapEnrollmentEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/enrollments", async ([FromServices] IEnrollmentRepository enrollmentRepository, [FromServices] IMapper mapper) =>
        {
            var enrollments = await enrollmentRepository.GetAllAsync();
            var enrollmentDtos = mapper.Map<List<EnrollmentDto>>(enrollments);
            return Results.Ok(enrollmentDtos);
        }).WithTags(nameof(Enrollment))
        .WithName("GetAllEnrollments")
        .Produces<List<EnrollmentDto>>(StatusCodes.Status200OK);

        routes.MapGet("/api/enrollments/{id}", async ([FromServices] IEnrollmentRepository enrollmentRepository, [FromServices] IMapper mapper, [FromRoute] int id) =>
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(id);
            var enrollmentDto = mapper.Map<EnrollmentDto>(enrollment);
            return enrollment is null ? Results.NotFound() : Results.Ok(enrollmentDto);
        }).WithTags(nameof(Enrollment))
        .WithName("GetEnrollmentById")
        .Produces<EnrollmentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPost("/api/enrollments", async ([FromServices] IEnrollmentRepository enrollmentRepository, [FromServices] IMapper mapper, [FromBody] CreateEnrollmentDto createEnrollmentDto) =>
        {
            var enrollment = mapper.Map<Enrollment>(createEnrollmentDto);
            var createdEnrollment = await enrollmentRepository.AddAsync(enrollment);

            return Results.CreatedAtRoute(
                routeName: "GetEnrollmentById",
                routeValues: new { id = createdEnrollment.Id },
                value: createdEnrollment);
        }).WithTags(nameof(Enrollment))
        .WithName("CreateEnrollment")
        .Produces<EnrollmentDto>(StatusCodes.Status201Created);

        routes.MapPut("/api/enrollments/{id}", async ([FromServices] IEnrollmentRepository enrollmentRepository, [FromServices] IMapper mapper, [FromRoute] int id, [FromBody] CreateEnrollmentDto updateEnrollmentDto) =>
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(id);
            if (enrollment is null) return Results.NotFound();

            mapper.Map(updateEnrollmentDto, enrollment);
            await enrollmentRepository.UpdateAsync(enrollment);
            return Results.NoContent();
        }).WithTags(nameof(Enrollment))
        .WithName("UpdateEnrollment")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapDelete("/api/enrollments/{id}", async ([FromServices] IEnrollmentRepository enrollmentRepository, [FromRoute] int id) =>
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(id);
            if (enrollment is null) return Results.NotFound();

            await enrollmentRepository.DeleteAsync(id);
            return Results.NoContent();
        }).WithTags(nameof(Enrollment))
        .WithName("DeleteEnrollment")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}
