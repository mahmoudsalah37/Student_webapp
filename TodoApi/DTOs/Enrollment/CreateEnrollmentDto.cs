using System;
using FluentValidation;
using StudentEnrollment.Data.Contracts;

namespace TodoApi.DTOs.Enrollment;

public class CreateEnrollmentDto
{
    public int CourseId { get; set; }

    public int StudentId { get; set; }
}

public class CreateEnrollmentValidator : AbstractValidator<CreateEnrollmentDto>
{
    public readonly ICourseRepository _courseRepository;
    public readonly IStudentRepository _studentRepository;


    public CreateEnrollmentValidator(ICourseRepository courseRepository, IStudentRepository studentRepository)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;

        RuleFor(x => x.CourseId).GreaterThan(0).MustAsync(async (courseId, cancellation) =>
            {
                var courseExists = await _courseRepository.ExistsAsync(courseId);
                return courseExists;
            }).WithMessage("{PropertyName} does not exist.");

        RuleFor(x => x.StudentId).GreaterThan(0).MustAsync(async (studentId, cancellation) =>
            {
                var studentExists = await _studentRepository.ExistsAsync(studentId);
                return studentExists;
            }).WithMessage("{PropertyName} does not exist.");
    }
}