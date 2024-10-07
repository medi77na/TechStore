using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Employees;

[ApiController]
[Route("api/[controller]")]
[Tags("Employee")]
public class EmployeeDeleteController(IEmployeeRepository employeeRepository) : EmployeeController(employeeRepository)
{
    [Authorize]
    [HttpDelete]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        if (!await _employeeRepository.CheckExist(id))
        {
            return BadRequest();
        }

        var userFinded = await _employeeRepository.GetById(id);
        
        await _employeeRepository.Delete(userFinded);
        return NoContent();
    }

}