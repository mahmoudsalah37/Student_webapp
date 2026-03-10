using AutoMapper;
using StudentEnrollment.Data;
using TodoApi.DTOs;
using TodoApi.DTOs.Enrollment;
using TodoApi.DTOs.Student;

namespace TodoApi.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Course, CreateCourseDto>().ReverseMap();
        CreateMap<Course, CourseDetailsDto>()
        .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Enrollments.Select(e => e.Student)));
        //TODO

        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<Student, CreateStudentDto>().ReverseMap();
        CreateMap<Student, StudentDetailsDto>()
        .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Enrollments.Select(e => e.Course)));

        CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
        CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();

    }

}
