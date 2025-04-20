using Domain.Students.Entities;
using Domain.Students.Ports.Out;

namespace Infra.Database.SqlServer.Students.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _dbContext;

    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Student>> GetStudentsAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateStudentAsync(Student student)
    {
        throw new NotImplementedException();
    }

    public async Task<Student?> GetStudentByIdAsync(string studentId)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UpdateStudentAsync(string studentId, Student student)
    {
        throw new NotImplementedException();
    }
}