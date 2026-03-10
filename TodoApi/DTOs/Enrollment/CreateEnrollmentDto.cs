using System;

namespace TodoApi.DTOs.Enrollment;

public class CreateEnrollmentDto
{
    public int CourseId { get; set; }

    public int StudentId { get; set; }
}
