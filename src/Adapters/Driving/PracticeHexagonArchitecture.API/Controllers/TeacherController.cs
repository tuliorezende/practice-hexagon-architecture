using Domain.Dto;
using Domain.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers;

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
    /// List all Students
    /// </summary>
    /// <param name="skip">Elements to Skip</param>
    /// <param name="take">Elements quantity to return</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(int skip = 0, int take = 10)
    {
        return Ok(await _teacherManager.GetTeachersAsync(skip, take));
    }

    /// <summary>
    /// Get Teacher by id
    /// </summary>
    /// <param name="teacherId">Teacher ID</param>
    /// <returns></returns>
    [HttpGet("{teacherId}")]
    public async Task<IActionResult> Get(string teacherId)
    {
        var teacher = await _teacherManager.GetTeacherByIdAsync(teacherId);

        if (teacher is null)
            return NotFound("Teacher not found");

        return Ok(teacher);
    }

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