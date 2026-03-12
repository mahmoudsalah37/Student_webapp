using System;
using FluentValidation;
using TodoApi.DTOs.Student;

namespace TodoApi.DTOs;

public class StudentDto : CreateStudentDto
{
    public int Id { get; set; }
}

public class StudentDtoValidator : AbstractValidator<StudentDto>
{
    public StudentDtoValidator()
    {
        Include(new CreateStudentValidator());
    }
}