using Contracts.Student;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.DataServices;

namespace Presentation.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IAdminService _adminService;
    public StudentController(IAdminService adminService) : base() {
        _adminService  = adminService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            List<StudentDepartmentDto> students = _adminService.StudentService.GetAll();
            if (students.Count == 0) return NotFound("No Students found in DB");
            return Ok(students);
        }
        catch (Exception ex)
        {
            return StatusCode(505, ex.Message);
        }
    }

    [HttpGet("GetById/{id:int}")]
    public IActionResult GetbById(int id)
    {
        StudentDepartmentDto? student = _adminService.StudentService.GetById(id);
        if (student is null) return NotFound("Student with this Id not Exist");
        return Ok(student);
    }
    [HttpGet("GetByName/{name:alpha}")]
    public IActionResult GetbByName(string name)
    {
        try
        {
            List<StudentDto> students = _adminService.StudentService.GetByName(name);
            if (students.Count == 0) return NotFound("No Students with this Name are exist");
            return Ok(students);
        }
        catch (Exception ex)
        {
            return StatusCode(505, ex.Message);
        }
    }

    [HttpPost("Add")]
    public IActionResult Add(StudentCreateDto student)
    {
        try
        {
            _adminService.StudentService.Add(student.Name, student.Age,
                student.Address!, student.Image, student.DepartmentId);
            return Ok("Student is Added sucessfully");

        }
        catch (Exception ex)
        {
            return StatusCode(505, ex.Message);
        }
    }

    [HttpPut("Update")]
    public IActionResult Update(int id,
        Dictionary<Properties, string> newValues)
    {
        try
        {
            _adminService.StudentService.Update(id, newValues);
            return Ok("Student is Updates sucessfully");
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(505, ex.Message);
        }
    }

    [HttpDelete("Delete")]
    public IActionResult Delere(int id)
    {
        try
        {
            _adminService.StudentService.Delete(id);
            return Ok("Student is Deleted sucessfully");
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(505, ex.Message);
        }
    }

}
