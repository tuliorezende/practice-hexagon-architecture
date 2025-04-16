using Domain.Students.Dtos;
using Domain.Students.Entities;

namespace Domain.Students.Ports.In;

public interface IStudentManager
{
    Task<string> CreateStudentAsync(StudentDto studentDto);

    Task<string> UpdateStudentAsync(string studentId, StudentDto studentDto);

    Task<StudentDto?> GetStudentByIdAsync(string studentId);

    Task<List<StudentDto>> GetStudentsAsync(int skip = 0, int take = 10);

    Task<bool> CreateAcademicalHistoryAsyncEntryAsync(string studentId, AcademicalHistoryEntry academicalHistoryEntry);

    Task<List<AcademicalHistoryEntry>> GetAcademicalHistoryFromStudentAsync(string studentId);
}