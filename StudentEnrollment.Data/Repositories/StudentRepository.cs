using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.Data.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    StudentEnrollmentDbContext _db;
    public StudentRepository(StudentEnrollmentDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Student> GetStudentDetails(int id)
    {
        var student = await _db.Students
            .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student is null)
            throw new KeyNotFoundException($"Student with ID {id} not found.");

        return student;
    }


}
