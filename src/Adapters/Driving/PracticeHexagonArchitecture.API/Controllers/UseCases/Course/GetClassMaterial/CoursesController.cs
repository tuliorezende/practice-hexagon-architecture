using Domain.Courses.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Course.GetClassMaterial;

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
    /// List class materials from a specific course
    /// </summary>
    /// <param name="courseId"></param>
    /// <returns></returns>
    [HttpGet("{courseId}/classMaterial")]
    public async Task<IActionResult> GetClassMaterials(string courseId)
    {
        return Ok(await _courseManager.GetClassMaterialFromCourseAsync(courseId));
    }
}