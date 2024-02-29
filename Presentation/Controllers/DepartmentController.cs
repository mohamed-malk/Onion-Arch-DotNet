using Contracts.Department;
using Domain.Enums;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Persistence.Filters;
using Services.Abstraction.DataServices;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IAdminService _adminService;
    public DepartmentController(IAdminService adminService) : base()
    {
        _adminService = adminService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            List<DepartmentDto> departments = _adminService.DepartmentService.GetAll();
            if (departments.Count == 0) return NotFound("No Departments found in DB");
            return Ok(departments);
        }
        catch (Exception ex)
        {
            return StatusCode(505, ex.Message);
        }
    }

    [HttpGet("GetById/{id:int}")]
    public IActionResult GetbById(int id)
    {
        var department = _adminService.DepartmentService.GetById(id);
        if (department is null) return NotFound("Department with this Id not Exist");
        return Ok(department);
    }

    [HttpGet("GetByName/{name:alpha}")]
    public IActionResult GetbByName(string name)
    {
        try
        {
            var department = _adminService.DepartmentService.GetByName(name);
            if (department is null) return NotFound("No Department with this Name are exist");
            return Ok(department);
        }
        catch (Exception ex)
        {
            return StatusCode(505, ex.Message);
        }
    }

    [HttpPost("Add")]
    [DepartmentLocation]
    public IActionResult Add(DepartmenCreatetDto department)
    {
        try
        {
            _adminService.DepartmentService.Add(department.Name,
                department.Location!, department.Manager);
            return Ok("Department is Added sucessfully");
        }
        catch (AlreadyExistException ex)
        {
            return StatusCode(404, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(505, ex.Message);
        }
    }

    [HttpPut("Update")]
    [DepartmentLocation]
    public IActionResult Update(int id,
        Dictionary<Properties, string> newValues)
    {
        try
        {
            _adminService.DepartmentService.Update(id, newValues);
            return Ok("Department is Updates sucessfully");
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
            _adminService.DepartmentService.Delete(id);
            return Ok("Department is Deleted sucessfully");
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
