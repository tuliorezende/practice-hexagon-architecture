using Domain.Dto;
using Domain.Entities.Students;

namespace Domain.Services;

public interface IStudentManager
{
    Task<string> CreateStudentAsync(StudentDto studentDto);

    Task<string> UpdateStudentAsync(StudentDto studentDto);

    Task<StudentDto?> GetStudentByIdAsync(string studentId);

    Task<List<StudentDto>> GetStudentsAsync(int skip = 0, int take = 10);

    Task<bool> CreateAcademicalHistoryAsyncEntryAsync(string studentId, AcademicalHistory academicalHistory);

    Task<List<AcademicalHistory>> GetAcademicalHistoryFromStudentAsync(string studentId);
}