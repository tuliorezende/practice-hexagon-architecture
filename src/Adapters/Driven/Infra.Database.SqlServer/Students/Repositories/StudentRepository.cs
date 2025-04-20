using Domain.Students.Entities;
using Domain.Students.Ports.Out;
using Microsoft.EntityFrameworkCore;

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
        var teachersEntities = await _dbContext.Students.Skip(skip).Take(take).ToListAsync();

        var teachers = teachersEntities.ConvertAll(s =>
            Student.Load(s.Id, s.Name, s.Address, s.PersonalDocument, s.Telephone, s.Email));

        return teachers;
    }

    public async Task<string> CreateStudentAsync(Student student)
    {
        var studentEntity = new Infra.Database.SqlServer.Students.Entities.Student(
            student.Id,
            student.Name,
            student.Address,
            student.Telephone,
            student.Email,
            student.PersonalDocument);

        _dbContext.Students.Add(studentEntity);
        await _dbContext.SaveChangesAsync();

        return student.Id;
    }

    public async Task<Student?> GetStudentByIdAsync(string studentId)
    {
        var studentEntity = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId);

        if (studentEntity is null)
            return null;

        var student = Student.Load(
            studentEntity.Id,
            studentEntity.Name,
            studentEntity.Address,
            studentEntity.PersonalDocument,
            studentEntity.Telephone,
            studentEntity.Email);

        return student;
    }

    public async Task<string> UpdateStudentAsync(string studentId, Student student)
    {
        var entityToUpdate = await _dbContext.Students.FirstOrDefaultAsync(t => t.Id == studentId);

        if (entityToUpdate is null)
            return null;

        entityToUpdate.Update(studentId, student);
        _dbContext.Students.Update(entityToUpdate);

        await _dbContext.SaveChangesAsync();

        return studentId;
    }
}