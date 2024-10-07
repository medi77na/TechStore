using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.Employees;

[ApiController]
[Route("api/[controller]")]
[Tags("Employee")]
public class EmployeeGetController(IEmployeeRepository employeeRepository) : EmployeeController(employeeRepository)
{

    [HttpGet]
    public async Task<List<User>> GetAllCustomers()
    {
        return await _employeeRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetCustomerById(int id)
    {
        if (!await _employeeRepository.CheckExist(id))
        {
            return NotFound();
        }

        return Ok(await _employeeRepository.GetById(id));
    }

}