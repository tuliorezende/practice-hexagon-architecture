using Domain.Courses.Dtos;
using Domain.Courses.Entities;
using Domain.Courses.Ports.In;
using Domain.Courses.Ports.Out;

namespace Application.Courses.Services;

public class CourseManager : ICourseManager
{
    private readonly ICourseRepository _courseRepository;
    private readonly ITeacherManager _teacherManager;

    public CourseManager(ICourseRepository courseRepository, ITeacherManager teacherManager)
    {
        _courseRepository = courseRepository;
        _teacherManager = teacherManager;
    }

    public async Task<string> UpdateCourseAsync(string courseId, CourseDto courseDto)
    {
        TeacherDto teacher = null;

        if (courseDto.TeacherId is not null)
            teacher = await _teacherManager.GetTeacherByIdAsync(courseDto.TeacherId);

        var course = new Course(courseDto, teacher);

        var updatedId = await _courseRepository.UpdateCourseAsync(courseId, course);

        return updatedId;
    }

    public async Task<string> CreateCourseAsync(CourseDto courseDto)
    {
        TeacherDto teacher = null;

        if (courseDto.TeacherId is not null)
            teacher = await _teacherManager.GetTeacherByIdAsync(courseDto.TeacherId);

        var course = new Course(courseDto, teacher);

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

    public async Task<bool> CreateClassMaterialAsync(string courseId, ClassMaterialEntryDto classMaterialEntryDto)
    {
        var course = await _courseRepository.GetCourseByIdAsync(courseId);

        if (course is null)
            return false;

        var classMaterialEntry = new ClassMaterialEntry(classMaterialEntryDto);

        course.AddMaterial(classMaterialEntry);

        await _courseRepository.UpdateCourseAsync(courseId, course);
        return true;
    }

    public async Task<List<ClassMaterialEntryDto>> GetClassMaterialFromCourseAsync(string courseId)
    {
        var course = await _courseRepository.GetCourseByIdAsync(courseId);

        if (course is null)
            return null;

        return course.Materials.ConvertAll(c => new ClassMaterialEntryDto(c));
    }
}