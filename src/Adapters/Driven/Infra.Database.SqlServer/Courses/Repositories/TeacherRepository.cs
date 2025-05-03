using Domain.Courses.Entities;
using Domain.Courses.Ports.Out;
using Microsoft.EntityFrameworkCore;

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
        var teachersEntities = await _dbContext.Teachers.Skip(skip).Take(take).ToListAsync();

        var teachers = teachersEntities.ConvertAll(s => Teacher.Load(s.Id, s.Name, s.Discipline));

        return teachers;
    }

    public async Task<string> CreateTeacherAsync(Teacher teacher)
    {
        var teacherEntity = new Entities.Teacher
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Discipline = teacher.Discipline,
        };

        _dbContext.Teachers.Add(teacherEntity);
        await _dbContext.SaveChangesAsync();

        return teacher.Id;
    }

    public async Task<Teacher?> GetTeacherByIdAsync(string teacherId)
    {
        var teacherEntity = await _dbContext.Teachers.FirstOrDefaultAsync(s => s.Id == teacherId);

        if (teacherEntity is null)
            return null;

        var teacher = Teacher.Load(teacherEntity.Id, teacherEntity.Name, teacherEntity.Discipline);
        return teacher;
    }

    public async Task<string> UpdateTeacherAsync(string teacherId, Teacher teacher)
    {
        var entityToUpdate = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.Id == teacherId);

        if (entityToUpdate is null)
            return null;

        entityToUpdate.Update(teacherId, teacher);
        _dbContext.Teachers.Update(entityToUpdate);

        await _dbContext.SaveChangesAsync();

        return teacherId;
    }
}