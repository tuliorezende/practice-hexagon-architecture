using Domain.Entities;

namespace Domain.Adapters;

public interface IAcademicalHistoryRepository
{
    Task<bool> AddAcademicalHistory(AcademicalHistory academicalHistory);
}