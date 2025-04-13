using Domain.Dto;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers;

/// <summary>
/// Endpoint to manage Students
/// </summary>
[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentManager _studentManager;
    private readonly IAcademicalHistoryManager _academicalHistoryManager;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public StudentsController(IStudentManager studentManager, IAcademicalHistoryManager academicalHistoryManager)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _studentManager = studentManager;
        _academicalHistoryManager = academicalHistoryManager;
    }

    #region Students Operations

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
        var updatedStudentId = await _studentManager.UpdateStudentAsync(studentDto);
        return Ok(updatedStudentId);
    }

    #endregion

    #region Academical History Operations

    /// <summary>
    /// Create an academical history entry on database
    /// </summary>
    /// <param name="studentId"></param>
    /// <param name="academicalHistory"></param>
    /// <returns></returns>
    [HttpPost("{studentId}/academicalHistory")]
    public async Task<IActionResult> PostAcademicalHistory(string studentId, AcademicalHistory academicalHistory)
    {
        await _academicalHistoryManager.AddAcademicalHistoryAsync(studentId, academicalHistory);
        return Created();
    }

    #endregion
}