using Domain.Courses.Dtos;
using Domain.Courses.Entities;
using Domain.Courses.Ports.In;
using Domain.Courses.Ports.Out;

namespace Application.Courses.Services;

public class CourseManager : ICourseManager
{
    private readonly ICourseRepository _courseRepository;

    public CourseManager(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<string> UpdateCourseAsync(string courseId, CourseDto courseDto)
    {
        var course = new Course(courseDto);

        var updatedId = await _courseRepository.UpdateCourseAsync(courseId, course);

        return updatedId;
    }

    public async Task<string> CreateCourseAsync(CourseDto courseDto)
    {
        var course = new Course(courseDto);

        var courseId = await _courseRepository.CreateCourseAsync(course);
        return courseId;
    }

    public async Task<CourseDto?> GetCourseByIdAsync(string courseId)
    {
        var course = await _courseRepository.GetCourseByIdAsync(courseId);

        if (course is null)
            return null;

        var courseDto = new CourseDto(course);
        return courseDto;
    }

    public async Task<List<CourseDto>> GetCoursesAsync(int skip = 0, int take = 10)
    {
        var courses = (await _courseRepository.GetCoursesAsync(skip, take)).ConvertAll(c => new CourseDto(c));
        return courses;
    }

    public async Task<bool> CreateClassMaterialAsync(string courseId, ClassMaterialEntry classMaterialEntry)
    {
        var course = await _courseRepository.GetCourseByIdAsync(courseId);

        if (course is null)
            return false;

        course.AddMaterial(classMaterialEntry);

        await _courseRepository.UpdateCourseAsync(courseId, course);
        return true;
    }

    public async Task<List<ClassMaterialEntry>> GetClassMaterialFromCourseAsync(string courseId)
    {
        var course = await _courseRepository.GetCourseByIdAsync(courseId);

        if (course is null)
            return null;

        return course.Materials;
    }
}