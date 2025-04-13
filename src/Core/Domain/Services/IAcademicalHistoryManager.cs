using Domain.Entities;

namespace Domain.Services;

public interface IAcademicalHistoryManager
{
    Task<bool> AddAcademicalHistoryAsync(string studentId, AcademicalHistory academicalHistory);
}