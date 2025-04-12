using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services;

public interface IStudentManager
{
    Task<string> CreateStudentAsync(Student student);
    
    Task<string> UpdateStudentAsync(Student student);
    
    Task<Student> GetStudentByIdAsync(string studentId);
    
    Task<IEnumerable<Student>> GetStudentsAsync(int skip = 0, int take = 10);
}