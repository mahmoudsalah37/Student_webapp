
using StudentEnrollment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TodoApi.DTOs;
using StudentEnrollment.Data.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace TodoApi.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/courses", async ([FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper) =>
        {
            var courses = await courseRepository.GetAllAsync();
            var courseDtos = mapper.Map<List<CourseDto>>(courses);
            return Results.Ok(courseDtos);
        })
        .WithTags(nameof(Course))
        .AllowAnonymous()
        .WithName("GetAllCourses")
        .Produces<List<CourseDto>>(StatusCodes.Status200OK);

        routes.MapGet("/api/courses/{id}", async ([FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper, [FromRoute] int id) =>
        {
            var course = await courseRepository.GetByIdAsync(id);
            if (course is null) return Results.NotFound();
            var courseDto = mapper.Map<CourseDto>(course);
            return Results.Ok(courseDto);
        }).WithTags(nameof(Course))
        .AllowAnonymous()
        .WithName("GetCourseById")
        .Produces<CourseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapGet("/api/courses/getStudents/{id}", async ([FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper, [FromRoute] int id) =>
               {
                   var course = await courseRepository.GetStudents(id);
                   if (course is null) return Results.NotFound();
                   var courseDto = mapper.Map<CourseDetailsDto>(course);
                   return Results.Ok(courseDto);
               }).WithTags(nameof(Course))
               .WithName("GetCourseDetailsById")
               .Produces<CourseDetailsDto>(StatusCodes.Status200OK)
               .Produces(StatusCodes.Status404NotFound);

        routes.MapPost("/api/courses", async ([FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper, [FromBody] Course course) =>
        {
            await courseRepository.AddAsync(course);

            var courseDto = mapper.Map<CourseDto>(course);
            return Results.CreatedAtRoute(
                routeName: "GetCourseById",
                routeValues: new { id = course.Id },
                value: courseDto);
        }).WithTags(nameof(Course))
        .WithName("CreateCourse")
        .Produces<CourseDto>(StatusCodes.Status201Created);

        routes.MapPut("/api/courses/{id}", async ([FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper, [FromRoute] int id, [FromBody] CourseDto updatedCourse) =>
        {
            var course = await courseRepository.GetByIdAsync(id);
            if (course is null) return Results.NotFound();

            mapper.Map(updatedCourse, course);
            await courseRepository.UpdateAsync(course);
            return Results.NoContent();
        }).WithTags(nameof(Course))
        .WithName("UpdateCourse")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapDelete("/api/courses/{id}", [Authorize(Roles = "Administrator")] async ([FromServices] ICourseRepository courseRepository, [FromRoute] int id) =>
        {
            var course = await courseRepository.GetByIdAsync(id);
            if (course is null) return Results.NotFound();

            await courseRepository.DeleteAsync(course.Id);
            return Results.NoContent();
        }).WithTags(nameof(Course))
        .WithName("DeleteCourse")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }

}
