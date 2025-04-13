using Domain.Dto;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services;

public interface IStudentManager
{
    Task<string> CreateStudentAsync(StudentDto studentDto);
    
    Task<string> UpdateStudentAsync(Student student);
    
    Task<StudentDto?> GetStudentByIdAsync(string studentId);
    
    Task<List<StudentDto>> GetStudentsAsync(int skip = 0, int take = 10);
}