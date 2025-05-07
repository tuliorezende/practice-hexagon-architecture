using Domain.Courses.Dtos;
using Domain.Courses.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Course.Manage;

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
    /// Create a course
    /// </summary>
    /// <param name="courseDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CourseDto courseDto)
    {
        await _courseManager.CreateCourseAsync(courseDto);

        return Created();
    }
    
    /// <summary>
    /// Update a course
    /// </summary>
    /// <param name="courseId"></param>
    /// <param name="courseDto"></param>
    /// <returns></returns>
    [HttpPut("{courseId}")]
    public async Task<IActionResult> Put(string courseId, [FromBody] CourseDto courseDto)
    {
        await _courseManager.UpdateCourseAsync(courseId, courseDto);
        return Ok();
    }    
}