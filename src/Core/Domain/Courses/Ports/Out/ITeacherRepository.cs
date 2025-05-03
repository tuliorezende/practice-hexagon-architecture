using Domain.Courses.Entities;

namespace Domain.Courses.Ports.Out;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetTeachersAsync(int skip = 0, int take = 10);

    Task<string> CreateTeacherAsync(Teacher teacher);

    Task<Teacher?> GetTeacherByIdAsync(string teacherId);

    Task<string> UpdateTeacherAsync(string teacherId, Teacher teacher);
}