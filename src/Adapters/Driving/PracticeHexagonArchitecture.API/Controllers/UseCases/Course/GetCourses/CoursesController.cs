using Domain.Courses.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Course.GetCourses;

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
    /// List courses
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(int skip = 0, int take = 10)
    {
        return Ok(await _courseManager.GetCoursesAsync(skip, take));
    }

    /// <summary>
    /// Get details from a specific fourse
    /// </summary>
    /// <param name="courseId"></param>
    /// <returns></returns>
    [HttpGet("{courseId}")]
    public async Task<IActionResult> Get(string courseId)
    {
        return Ok(_courseManager.GetCourseByIdAsync(courseId));
    }
}