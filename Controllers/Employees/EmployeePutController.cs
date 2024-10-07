using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Repository;

namespace TechStore.Controllers.Employees;

[ApiController]
[Route("api/[controller]")]
[Tags("Employee")]
public class EmployeePutController(IEmployeeRepository employeeRepository, IMapper mapper) : EmployeeController(employeeRepository, mapper)
{

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, EmployeeDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _employeeRepository.CheckExist(id))
        {
            return NotFound();
        }

        var customer = await _employeeRepository.GetById(id);

        _mapper.Map(model, customer);

        await _employeeRepository.Update(customer);

        return NoContent();
    }
}