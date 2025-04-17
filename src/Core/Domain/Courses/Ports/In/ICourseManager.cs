using Domain.Courses.Dtos;
using Domain.Courses.Entities;

namespace Domain.Courses.Ports.In;

public interface ICourseManager
{
    Task<string> CreateCourseAsync(CourseDto studentDto);

    Task<string> UpdateCourseAsync(string courseId, CourseDto studentDto);

    Task<CourseDto?> GetCourseByIdAsync(string courseId);

    Task<List<CourseDto>> GetCoursesAsync(int skip = 0, int take = 10);

    Task<bool> CreateClassMaterialAsync(string course, ClassMaterialEntry classMaterialEntry);

    Task<List<ClassMaterialEntry>> GetClassMaterialFromCourseAsync(string courseId);
}