using Domain.Courses.Dtos;

namespace Domain.Courses.Ports.In;

public interface ITeacherManager
{
    Task<string> CreateTeacherAsync(TeacherDto teacherDto);

    Task<string> UpdateTeacherAsync(string teacherId, TeacherDto teacherDto);

    Task<TeacherDto?> GetTeacherByIdAsync(string teacherDto);

    Task<List<TeacherDto>> GetTeachersAsync(int skip = 0, int take = 10);
}