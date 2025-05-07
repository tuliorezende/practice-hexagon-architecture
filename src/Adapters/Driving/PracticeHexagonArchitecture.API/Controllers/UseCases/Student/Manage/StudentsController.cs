using Domain.Students.Dtos;
using Domain.Students.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Student.Manage;

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
    /// Create a Student
    /// </summary>
    /// <param name="studentDto">Student object to be created</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentDto studentDto)
    {
        await _studentManager.CreateStudentAsync(studentDto);
        return Created();
    }
    
    /// <summary>
    /// Update a student
    /// </summary>
    /// <param name="studentId">ID to be updated</param>
    /// <param name="studentDto">New object information</param>
    /// <returns></returns>
    [HttpPut("{studentId}")]
    public async Task<IActionResult> Put(string studentId, [FromBody] StudentDto studentDto)
    {
        var updatedStudentId = await _studentManager.UpdateStudentAsync(studentId, studentDto);
        return Ok(updatedStudentId);
    }
}