using Domain.Courses.Entities;
using Domain.Courses.Ports.Out;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.SqlServer.Courses.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _dbContext;

    public CourseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Course>> GetCoursesAsync(int skip = 0, int take = 10)
    {
        var coursesEntities = await _dbContext.Courses.Skip(skip).Take(take).ToListAsync();

        var courses = coursesEntities.ConvertAll(c => Course.Load(
            c.Id, c.Name, c.Description, c.Discipline, c.StartDate, c.EndDate, c.TeacherId
        ));

        return courses;
    }

    public async Task<string> CreateCourseAsync(Course course)
    {
        var courseEntity = new Entities.Course
        {
            Id = course.Id,
            Name = course.Name,
            Description = course.Description,
            Discipline = course.Discipline,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
            TeacherId = course.TeacherId
        };

        _dbContext.Courses.Add(courseEntity);
        await _dbContext.SaveChangesAsync();

        return course.Id;
    }

    public async Task<Course?> GetCourseByIdAsync(string courseId)
    {
        var courseEntity =
            await _dbContext.Courses.Include(c => c.Materials).FirstOrDefaultAsync(c => c.Id == courseId);

        if (courseEntity is null)
            return null;

        var course = Course.Load(
            courseEntity.Id, courseEntity.Name, courseEntity.Description, courseEntity.Discipline,
            courseEntity.StartDate, courseEntity.EndDate, courseEntity.TeacherId,
            courseEntity.Materials.ConvertAll(m => ClassMaterialEntry.Load(m.Id, m.Name, m.Description, m.Url))
        );

        return course;
    }

    public async Task<string> UpdateCourseAsync(string courseId, Course course)
    {
        var entityToUpdate = await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

        if (entityToUpdate is null)
            return null;

        entityToUpdate.Update(courseId, course);
        _dbContext.Courses.Update(entityToUpdate);

        await _dbContext.SaveChangesAsync();

        return courseId;
    }

    public async Task<string> CreateClassMaterialEntryAsync(Course course, ClassMaterialEntry classMaterialEntry)
    {
        var classMaterialEntryEntity = new Entities.ClassMaterialEntry
        {
            Id = classMaterialEntry.Id,
            Description = classMaterialEntry.Description,
            Name = classMaterialEntry.Name,
            Url = classMaterialEntry.Url,
        };

        var courseEntity = await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);

        if (courseEntity is null)
            return null;

        courseEntity.Materials.Add(classMaterialEntryEntity);

        _dbContext.ClassMaterialEntry.Add(classMaterialEntryEntity);
        _dbContext.Courses.Update(courseEntity);

        await _dbContext.SaveChangesAsync();

        return classMaterialEntry.Id;
    }
}