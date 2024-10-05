using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Customer;

[ApiController]
[Route("api/[controller]")]
[Tags("Customer")]
public class CustomerDeleteController(ICustomerRepository customerRepository) : CustomerController(customerRepository)
{
    [HttpDelete]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        if (!await _customerRepository.CheckExist(id))
        {
            return BadRequest();
        }

        var userFinded = await _customerRepository.GetById(id);

        if (userFinded.Role_id != 2)
        {
            return NotFound();
        }
        await _customerRepository.Delete(userFinded);
        return NoContent();
    }
}