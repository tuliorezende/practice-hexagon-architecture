using Domain.Courses.Entities;
using Domain.Courses.Ports.Out;

namespace Infra.Database.SqlServer.Courses.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _dbContext;

    public TeacherRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Teacher>> GetTeachersAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateTeacherAsync(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public async Task<Teacher?> GetTeacherByIdAsync(string teacherId)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UpdateTeacherAsync(string teacherId, Teacher teacher)
    {
        throw new NotImplementedException();
    }
}