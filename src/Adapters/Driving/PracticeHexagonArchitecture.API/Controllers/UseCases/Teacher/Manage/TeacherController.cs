using Domain.Courses.Dtos;
using Domain.Courses.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Teacher.Manage;

/// <summary>
/// Endpoint to manage Teachers
/// </summary>
[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherManager _teacherManager;

    public TeacherController(ITeacherManager teacherManager)
    {
        _teacherManager = teacherManager;
    }

    #region Teacher Operations

    /// <summary>
    /// Create a Teacher
    /// </summary>
    /// <param name="teacherDto">Teacher object to be created</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TeacherDto teacherDto)
    {
        await _teacherManager.CreateTeacherAsync(teacherDto);
        return Created();
    }

    /// <summary>
    /// Update a teacher
    /// </summary>
    /// <param name="teacherId">ID to be updated</param>
    /// <param name="teacherDto">New object information</param>
    /// <returns></returns>
    [HttpPut("{teacherId}")]
    public async Task<IActionResult> Put(string teacherId, [FromBody] TeacherDto teacherDto)
    {
        var updatedTeacherId = await _teacherManager.UpdateTeacherAsync(teacherId, teacherDto);
        return Ok(updatedTeacherId);
    }

    #endregion
}