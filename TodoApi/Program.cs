using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Repositories;
using TodoApi.Configurations;
using TodoApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var con = builder.Configuration.GetConnectionString("SchoolDbConnection");
builder.Services.AddDbContext<StudentEnrollmentDbContext>(options =>
    options.UseNpgsql(con).UseSnakeCaseNamingConvention());

builder.Services.AddIdentityCore<SchoolUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StudentEnrollmentDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddAutoMapper(typeof(MapperConfig));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

// Endpoints
app.MapStudentEndpoints();
app.MapEnrollmentEndpoints();
app.MapCourseEndpoints();

app.Run();
