using Domain.Adapters;
using Domain.Entities;

namespace Infra.Database.Memory.Repositories;

public class AcademicalHistoryRepository : IAcademicalHistoryRepository
{
    private static List<AcademicalHistory> _academicalHistory;

    public AcademicalHistoryRepository()
    {
        _academicalHistory = new List<AcademicalHistory>();
    }

    public async Task<bool> AddAcademicalHistory(AcademicalHistory academicalHistory)
    {
        _academicalHistory.Add(academicalHistory);
        return true;
    }
}