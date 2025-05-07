using Domain.Students.Dtos;
using Domain.Students.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Student.GetStudents;

/// <summary>
/// Endpoint to manage Students
/// </summary>
[ApiController]
[Route("[controller]")]
public class StudentsController : Controller
{
    private readonly IStudentManager _studentManager;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public StudentsController(IStudentManager studentManager)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _studentManager = studentManager;
    }

    /// <summary>
    /// List all Students
    /// </summary>
    /// <param name="skip">Elements to Skip</param>
    /// <param name="take">Elements quantity to return</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(int skip = 0, int take = 10)
    {
        return Ok(await _studentManager.GetStudentsAsync(skip, take));
    }

    /// <summary>
    /// Get Student by id
    /// </summary>
    /// <param name="studentId">Student ID</param>
    /// <returns></returns>
    [HttpGet("{studentId}")]
    public async Task<IActionResult> Get(string studentId)
    {
        var student = await _studentManager.GetStudentByIdAsync(studentId);

        if (student is null)
            return NotFound("Student not found");

        return Ok(student);
    }
}