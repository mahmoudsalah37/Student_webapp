using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace StudentEnrollment.Data;

public class StudentEnrollmentDbContextFactory : IDesignTimeDbContextFactory<StudentEnrollmentDbContext>
{
    public StudentEnrollmentDbContext CreateDbContext(string[] args)
    {

        //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<StudentEnrollmentDbContext>();
        var connectionString = config.GetConnectionString("SchoolDbConnection");
        optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();

        return new StudentEnrollmentDbContext(optionsBuilder.Options);
    }
}