using FluentValidation;

namespace TodoApi.DTOs.Authentication;

public class RegisterDto : LoginDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }
}

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        Include(new LoginValidator());
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now);
    }
}