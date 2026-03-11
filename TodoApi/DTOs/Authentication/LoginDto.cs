using System;

namespace TodoApi.DTOs.Authentication;

public class LoginDto
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }

}
