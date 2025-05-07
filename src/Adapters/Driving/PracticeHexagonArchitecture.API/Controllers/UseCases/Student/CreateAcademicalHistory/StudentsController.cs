using Domain.Students.Dtos;
using Domain.Students.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers.UseCases.Student.CreateAcademicalHistory;

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
    /// Create an academical history entry on database
    /// </summary>
    /// <param name="studentId"></param>
    /// <param name="academicalHistoryEntryDto"></param>
    /// <returns></returns>
    [HttpPost("{studentId}/academicalHistory")]
    public async Task<IActionResult> PostAcademicalHistory(string studentId,
        AcademicalHistoryEntryDto academicalHistoryEntryDto)
    {
        var created =
            await _studentManager.CreateAcademicalHistoryAsyncEntryAsync(studentId, academicalHistoryEntryDto);

        if (!created)
            return new NoContentResult();

        return Created();
    }
}