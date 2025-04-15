using Domain.Entities.Students;

namespace Domain.Adapters;

public interface IStudentRepository
{
    Task<List<Student>> GetStudentsAsync(int skip = 0, int take = 10);

    Task<string> CreateStudentAsync(Student student);

    Task<Student?> GetStudentByIdAsync(string studentId);
    
    Task <string> UpdateStudentAsync(Student student);
}