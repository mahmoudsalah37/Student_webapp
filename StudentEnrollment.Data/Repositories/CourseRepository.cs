using System;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.Data.Repositories;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    StudentEnrollmentDbContext _db;
    public CourseRepository(StudentEnrollmentDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Course> GetStudents(int id)
    {
        var course = await _db.Courses
            .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course is null)
            throw new KeyNotFoundException($"Course with ID {id} not found.");

        return course;
    }
}
