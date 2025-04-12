using Domain.Adapters;
using Domain.Entities;
using Domain.Services;

namespace Application.Services;

public class StudentManager : IStudentManager
{
    private readonly IStudentRepository _studentRepository;

    public StudentManager(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<string> CreateStudentAsync(Student student)
    {
        var studentId = await _studentRepository.CreateStudentAsync(student);
        return studentId;
    }

    public async Task<string> UpdateStudentAsync(Student student)
    {
        return "";
    }

    public async Task<Student> GetStudentByIdAsync(string studentId)
    {
        return null;
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync(int skip = 0, int take = 10)
    {
        var students = await _studentRepository.GetStudentsAsync(skip, take);
        return students;
    }
}