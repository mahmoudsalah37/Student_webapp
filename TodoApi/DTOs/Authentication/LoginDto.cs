using System;
using FluentValidation;

namespace TodoApi.DTOs.Authentication;

public class LoginDto
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }

}

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(20);
    }
}