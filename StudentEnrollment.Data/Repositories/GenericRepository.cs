using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly StudentEnrollmentDbContext _db;

    public GenericRepository(StudentEnrollmentDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _db.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> GetByIdAsync(int id) => await _db.FindAsync<TEntity>(id);

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _db.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _db.Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
            return;
        _db.Remove(entity);
        await _db.SaveChangesAsync();

    }

    public async Task<bool> ExistsAsync(int id) => await _db.Set<TEntity>().AnyAsync(e => e.Id == id);
}
