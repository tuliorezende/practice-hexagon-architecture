using Domain.Adapters;
using Domain.Entities;
using Domain.Services;

namespace Application.Services;

public class AcademicalHistoryManager : IAcademicalHistoryManager
{
    private readonly IStudentRepository _studentRepository;
    private readonly IAcademicalHistoryRepository _academicalHistoryRepository;

    public AcademicalHistoryManager(IStudentRepository studentRepository,
        IAcademicalHistoryRepository academicalHistoryRepository)
    {
        _studentRepository = studentRepository;
        _academicalHistoryRepository = academicalHistoryRepository;
    }

    public async Task<bool> AddAcademicalHistoryAsync(string studentId, AcademicalHistory academicalHistory)
    {
        var student = await _studentRepository.GetStudentByIdAsync(studentId);

        if (student is null)
            return false;

        student.AddAcademicalHistory(academicalHistory);
        await _studentRepository.UpdateStudentAsync(student);
        
        return await _academicalHistoryRepository.AddAcademicalHistory(academicalHistory);
    }
}