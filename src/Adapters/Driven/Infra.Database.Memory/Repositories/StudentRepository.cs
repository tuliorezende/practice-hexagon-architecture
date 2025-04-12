using Domain.Adapters;
using Domain.Entities;

namespace Infra.Database.Memory.Repositories;

public class StudentRepository : IStudentRepository
{
    private static List<Student> _students;

    public StudentRepository()
    {
        _students = new List<Student>();
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync(int skip = 0, int take = 10)
    {
        return _students.Skip(skip).Take(take);
    }

    public async Task<string> CreateStudentAsync(Student student)
    {
        _students.Add(student);

        return student.Id;
    }
}