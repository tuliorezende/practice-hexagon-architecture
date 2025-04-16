using Domain.Courses.Dtos;
using Domain.Courses.Entities;
using Domain.Courses.Ports;
using Domain.Courses.Ports.In;
using Domain.Courses.Ports.Out;

namespace Application.Services;

public class TeacherManager : ITeacherManager
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherManager(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    #region Teacher Crud Operations

    public async Task<string> CreateTeacherAsync(TeacherDto teacherDto)
    {
        var teacher = new Teacher(teacherDto);

        var teacherId = await _teacherRepository.CreateTeacherAsync(teacher);
        return teacherId;
    }

    public async Task<string> UpdateTeacherAsync(string teacherId, TeacherDto teacherDto)
    {
        var teacher = new Teacher(teacherDto);

        var updatedId = await _teacherRepository.UpdateTeacherAsync(teacherId, teacher);

        return updatedId;
    }

    public async Task<TeacherDto?> GetTeacherByIdAsync(string teacherId)
    {
        var teacher = await _teacherRepository.GetTeacherByIdAsync(teacherId);

        if (teacher is null)
            return null;

        var teacherDto = new TeacherDto(teacher);
        return teacherDto;
    }

    public async Task<List<TeacherDto>> GetTeachersAsync(int skip = 0, int take = 10)
    {
        var teachers = (await _teacherRepository.GetTeachersAsync(skip, take)).ConvertAll(s => new TeacherDto(s));
        return teachers;
    }

    #endregion
}