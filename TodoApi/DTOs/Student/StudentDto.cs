using System;
using TodoApi.DTOs.Student;

namespace TodoApi.DTOs;

public class StudentDto : CreateStudentDto
{
    public int Id { get; set; }
}
