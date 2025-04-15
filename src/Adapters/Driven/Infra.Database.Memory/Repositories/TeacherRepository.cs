using Domain.Adapters;
using Domain.Entities.Courses;

namespace Infra.Database.Memory.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private static List<Teacher> _teachers;

    public TeacherRepository()
    {
        _teachers = new List<Teacher>();
    }

    public async Task<List<Teacher>> GetTeachersAsync(int skip = 0, int take = 10)
    {
        return _teachers.Skip(skip).Take(take).ToList();
    }

    public async Task<string> CreateTeacherAsync(Teacher teacher)
    {
        _teachers.Add(teacher);

        return teacher.Id;
    }

    public async Task<Teacher?> GetTeacherByIdAsync(string teacherId)
    {
        return _teachers.FirstOrDefault(s => s.Id == teacherId);
    }
    
    public async Task<string> UpdateTeacherAsync(string teacherId, Teacher teacher)
    {
        var teacherToUpdate = _teachers.FirstOrDefault(s => s.Id == teacherId);

        if (teacherToUpdate == null)
            return null;

        var indexToUpdate = _teachers.IndexOf(teacherToUpdate);

        _teachers[indexToUpdate] = teacherToUpdate.DeepClone(teacherId, teacher);

        return teacherId;
    }    
    
    
}