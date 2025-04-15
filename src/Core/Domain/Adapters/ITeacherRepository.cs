using Domain.Entities.Courses;

namespace Domain.Adapters;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetTeachersAsync(int skip = 0, int take = 10);

    Task<string> CreateTeacherAsync(Teacher teacher);

    Task<Teacher?> GetTeacherByIdAsync(string teacherId);

    Task<string> UpdateTeacherAsync(string teacherId, Teacher teacher);
}