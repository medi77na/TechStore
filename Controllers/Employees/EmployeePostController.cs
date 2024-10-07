using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.Employees;

[ApiController]
[Route("api/[controller]")]
[Tags("Employee")]
public class EmployeePostController(IEmployeeRepository employeeRepository, IMapper mapper) : EmployeeController(employeeRepository, mapper)
{

    [HttpPost]
    public async Task<ActionResult<User>> CreateCustomer(EmployeeDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = _mapper.Map<User>(model);

        // Create PasswordHasher<User> instance
        var passwordHasher = new PasswordHasher<User>();

        // Hash the password and assign it to the user's Password property
        user.Password = passwordHasher.HashPassword(user, model.Password);

        await _employeeRepository.Create(user);

        return Ok(user);
    }
}