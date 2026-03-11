using System;

namespace TodoApi.DTOs.Authentication;

public class ErrorReponseDto
{
    public string Code { get; set; }
    public string Description { get; set; }
}
