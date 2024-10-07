using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechStore.Config;
using TechStore.Dtos;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IEmployeeRepository employeeRepository, IConfiguration configuration) : GeneralController
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IConfiguration _configuration = configuration;

    private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

    [HttpPost]
    public async Task<ActionResult> Login(AuthDto model)
    {
        var employee = await _employeeRepository.GetByEmail(model.Email);
        if (employee == null)
        {
            return NotFound("usuario no encontrado.");
        }

        // Verify the password using the password hasher.
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(employee, employee.Password, model.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            return BadRequest("Contraseña Incorrecta.");
        }

        var token = JWT.GenerateJwtToken(_configuration);

        return Ok(token);
    }
}