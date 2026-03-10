
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.Data.Repositories;

public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
{
    StudentEnrollmentDbContext _db;
    public EnrollmentRepository(StudentEnrollmentDbContext db) : base(db)
    {
        _db = db;
    }


}
