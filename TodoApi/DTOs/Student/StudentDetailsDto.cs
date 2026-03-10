using TodoApi.DTOs.Enrollment;

namespace TodoApi.DTOs;

public class StudentDetailsDto : StudentDto
{
    public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
}