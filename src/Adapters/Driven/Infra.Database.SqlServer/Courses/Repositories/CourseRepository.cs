using Domain.Courses.Entities;
using Domain.Courses.Ports.Out;

namespace Infra.Database.SqlServer.Courses.Repositories;

public class CourseRepository: ICourseRepository
{
    private readonly AppDbContext _dbContext;

    public CourseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Course>> GetCoursesAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateCourseAsync(Course course)
    {
        throw new NotImplementedException();
    }

    public async Task<Course?> GetCourseByIdAsync(string courseId)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UpdateCourseAsync(string courseId, Course course)
    {
        throw new NotImplementedException();
    }
}