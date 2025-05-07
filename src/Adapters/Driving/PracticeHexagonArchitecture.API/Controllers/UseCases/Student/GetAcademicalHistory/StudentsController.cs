using Domain.Students.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Student.GetAcademicalHistory;

/// <summary>
/// Endpoint to manage Students
/// </summary>
[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentManager _studentManager;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public StudentsController(IStudentManager studentManager)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _studentManager = studentManager;
    }

    /// <summary>
    /// Get Academical history from a student
    /// </summary>
    /// <param name="studentId"></param>
    /// <returns></returns>
    [HttpGet("{studentId}/academicalHistory")]
    public async Task<IActionResult> GetAcademicalHistory(string studentId)
    {
        var history = await _studentManager.GetAcademicalHistoryFromStudentAsync(studentId);

        if (history is null)
            return NoContent();

        return Ok(history);
    }
}