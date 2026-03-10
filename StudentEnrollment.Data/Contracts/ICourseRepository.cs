
namespace StudentEnrollment.Data.Contracts;

public interface ICourseRepository : IGenericRepository<Course>
{
    public Task<Course> GetStudents(int id);
}
