using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace PracticeHexagonArchitecture.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentManager _studentManager;

    public StudentsController(IStudentManager studentManager)
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
    /// Create a Student
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(Student student)
    {
        return Ok(await _studentManager.CreateStudentAsync(student));
    }
}