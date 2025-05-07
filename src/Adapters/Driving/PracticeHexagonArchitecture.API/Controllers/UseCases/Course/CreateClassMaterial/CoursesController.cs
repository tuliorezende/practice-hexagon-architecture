using Domain.Courses.Dtos;
using Domain.Courses.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Course.CreateClassMaterial;

/// <summary>
/// Endpoint to manage Courses
/// </summary>
[ApiController]
[Route("[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseManager _courseManager;

    public CoursesController(ICourseManager courseManager)
    {
        _courseManager = courseManager;
    }
    
    /// <summary>
    /// Insert a class material in a specific course
    /// </summary>
    /// <param name="courseId"></param>
    /// <param name="classMaterialEntryDto"></param>
    /// <returns></returns>
    [HttpPost("{courseId}/classMaterial")]
    public async Task<IActionResult> PostClassMaterial(string courseId, ClassMaterialEntryDto classMaterialEntryDto)
    {
        await _courseManager.CreateClassMaterialAsync(courseId, classMaterialEntryDto);
        return Created();
    }
}