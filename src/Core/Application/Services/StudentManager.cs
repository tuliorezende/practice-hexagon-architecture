using Domain.Students.Dtos;
using Domain.Students.Entities;
using Domain.Students.Ports;
using Domain.Students.Ports.In;
using Domain.Students.Ports.Out;

namespace Application.Services;

public class StudentManager : IStudentManager
{
    private readonly IStudentRepository _studentRepository;

    public StudentManager(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    #region Student Crud Operations

    public async Task<string> CreateStudentAsync(StudentDto studentDto)
    {
        var student = new Student(studentDto);

        var studentId = await _studentRepository.CreateStudentAsync(student);
        return studentId;
    }

    public async Task<string> UpdateStudentAsync(string studentId, StudentDto studentDto)
    {
        var student = new Student(studentDto);

        var updatedId = await _studentRepository.UpdateStudentAsync(studentId, student);

        return updatedId;
    }

    public async Task<StudentDto?> GetStudentByIdAsync(string studentId)
    {
        var student = await _studentRepository.GetStudentByIdAsync(studentId);

        if (student is null)
            return null;

        var studentDto = new StudentDto(student);
        return studentDto;
    }

    public async Task<List<StudentDto>> GetStudentsAsync(int skip = 0, int take = 10)
    {
        var students = (await _studentRepository.GetStudentsAsync(skip, take)).ConvertAll(s => new StudentDto(s));
        return students;
    }

    #endregion

    #region Academical History Operations

    public async Task<bool> CreateAcademicalHistoryAsyncEntryAsync(string studentId,
        AcademicalHistoryEntry academicalHistoryEntry)
    {
        var student = await _studentRepository.GetStudentByIdAsync(studentId);

        if (student is null)
            return false;

        student.AddAcademicalHistory(academicalHistoryEntry);

        await _studentRepository.UpdateStudentAsync(studentId, student);

        return true;
    }

    public async Task<List<AcademicalHistoryEntry>> GetAcademicalHistoryFromStudentAsync(string studentId)
    {
        var student = await _studentRepository.GetStudentByIdAsync(studentId);

        if (student is null)
            return null;

        return student.AcademicalHistory;
    }

    #endregion
}