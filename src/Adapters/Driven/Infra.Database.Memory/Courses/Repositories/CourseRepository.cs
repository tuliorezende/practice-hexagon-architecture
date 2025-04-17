using Domain.Courses.Entities;
using Domain.Courses.Ports.Out;

namespace Infra.Database.Memory.Courses.Repositories;

public class CourseRepository : ICourseRepository
{
    
    private static List<Course> _courses;

    public CourseRepository()
    {
        _courses = new List<Course>();
    }    
    public async Task<List<Course>> GetCoursesAsync(int skip = 0, int take = 10)
    {
        return _courses.Skip(skip).Take(take).ToList();
    }

    public async Task<string> CreateCourseAsync(Course course)
    {
        _courses.Add(course);

        return course.Id;
    }

    public async Task<Course?> GetCourseByIdAsync(string courseId)
    {
        return _courses.FirstOrDefault(s => s.Id == courseId);
    }

    public async Task<string> UpdateCourseAsync(string courseId, Course course)
    {
        var courseToUpdate = _courses.FirstOrDefault(s => s.Id == courseId);

        if (courseToUpdate == null)
            return null;

        var indexToUpdate = _courses.IndexOf(courseToUpdate);

        _courses[indexToUpdate] = courseToUpdate.DeepClone(courseId, course);

        return courseId;
    }
}