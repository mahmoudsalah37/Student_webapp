using FluentValidation;
using StudentEnrollment.Data.Contracts;

namespace TodoApi.DTOs.Enrollment;

public class EnrollmentDto : CreateEnrollmentDto
{


    public StudentDto Student { get; set; }
    public CourseDto Course { get; set; }
}

public class EnrollmentDtoValidator : AbstractValidator<EnrollmentDto>
{
    public EnrollmentDtoValidator(ICourseRepository courseRepository, IStudentRepository studentRepository)
    {
        Include(new CreateEnrollmentValidator(courseRepository, studentRepository));
    }
}