using Domain.Courses.Entities;

namespace Domain.Courses.Ports.Out;

public interface ICourseRepository
{
    Task<List<Course>> GetCoursesAsync(int skip = 0, int take = 10);

    Task<string> CreateCourseAsync(Course course);

    Task<Course?> GetCourseByIdAsync(string courseId);

    Task<string> UpdateCourseAsync(string courseId, Course course);
}