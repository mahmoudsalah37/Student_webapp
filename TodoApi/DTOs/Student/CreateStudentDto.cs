using System;
using FluentValidation;

namespace TodoApi.DTOs.Student;

public class CreateStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public string IdNumber { get; set; }

    public byte[] ProfilePicture { get; set; }

    public string OriginalFileName { get; set; }

}

public class CreateStudentValidator : AbstractValidator<CreateStudentDto>
{
    public CreateStudentValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now);
        RuleFor(x => x.IdNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.OriginalFileName).NotNull().When(x => x.ProfilePicture != null);
    }
}