using Domain.Courses.Dtos;
using Domain.Courses.Entities;
using Domain.Courses.Ports.In;
using Domain.Students.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers;

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

    /// <summary>
    /// Insert a class material in a specific course
    /// </summary>
    /// <param name="courseId"></param>
    /// <param name="classMaterialEntry"></param>
    /// <returns></returns>
    [HttpPost("{courseId}/classMaterial")]
    public async Task<IActionResult> PostClassMaterial(string courseId, ClassMaterialEntry classMaterialEntry)
    {
        await _courseManager.CreateClassMaterialAsync(courseId, classMaterialEntry);
        return Created();
    }
}