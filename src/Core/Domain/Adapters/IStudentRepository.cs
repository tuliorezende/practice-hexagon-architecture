using Domain.Entities;

namespace Domain.Adapters;

public interface IStudentRepository
{
    Task<List<Student>> GetStudentsAsync(int skip = 0, int take = 10);

    Task<string> CreateStudentAsync(Student student);
}