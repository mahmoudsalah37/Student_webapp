using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using StudentEnrollment.Data;
using StudentEnrollment.Data.Contracts;
using TodoApi.DTOs;
using TodoApi.DTOs.Student;
using AutoMapper;

namespace TodoApi.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/students", async ([FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper) =>
        {
            var students = await studentRepository.GetAllAsync();
            var studentDtos = mapper.Map<List<StudentDto>>(students);

            return Results.Ok(studentDtos);
        }).WithTags(nameof(Student))
        .WithName("GetAllStudents")
        .Produces<List<StudentDto>>(StatusCodes.Status200OK);

        routes.MapGet("/api/students/{id}", async ([FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper, [FromRoute] int id) =>
        {
            var student = await studentRepository.GetByIdAsync(id);
            var studentDto = mapper.Map<StudentDto>(student);
            return student is null ? Results.NotFound() : Results.Ok(studentDto);
        }).WithTags(nameof(Student))
        .WithName("GetStudentById")
        .Produces<StudentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
        routes.MapGet("/api/students/getDetails/{id}", async ([FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper, [FromRoute] int id) =>
              {
                  var student = await studentRepository.GetStudentDetails(id);
                  var studentDto = mapper.Map<StudentDetailsDto>(student);
                  return student is null ? Results.NotFound() : Results.Ok(studentDto);
              }).WithTags(nameof(Student))
              .WithName("GetStudentDetailsById")
              .Produces<StudentDetailsDto>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);
        routes.MapPost("/api/students", async ([FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper, [FromBody] CreateStudentDto student) =>
        {
            var studentEntity = mapper.Map<Student>(student);
            await studentRepository.AddAsync(studentEntity);

            var studentDto = mapper.Map<StudentDto>(studentEntity);
            return Results.CreatedAtRoute(
                routeName: "GetStudentById",
                routeValues: new { id = studentDto.Id },
                value: studentDto);
        }).WithTags(nameof(Student))
        .WithName("CreateStudent")
        .Produces<StudentDto>(StatusCodes.Status201Created);

        routes.MapPut("/api/students/{id}", async ([FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper, [FromRoute] int id, [FromBody] CreateStudentDto createStudentDto) =>
        {
            var student = await studentRepository.GetByIdAsync(id);
            if (student is null) return Results.NotFound();
            mapper.Map(createStudentDto, student);
            await studentRepository.UpdateAsync(student);
            return Results.NoContent();
        }).WithTags(nameof(Student))
        .WithName("UpdateStudent")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapDelete("/api/students/{id}", async ([FromServices] IStudentRepository studentRepository, [FromRoute] int id) =>
        {
            var student = await studentRepository.GetByIdAsync(id);
            if (student is null) return Results.NotFound();

            await studentRepository.DeleteAsync(id);
            return Results.NoContent();
        }).WithTags(nameof(Student))
        .WithName("DeleteStudent")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}
