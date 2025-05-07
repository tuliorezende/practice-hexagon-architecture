using Domain.Courses.Dtos;
using Domain.Courses.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Teacher.GetTeachers;

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
    /// List all Teachers
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
    
    #endregion
}