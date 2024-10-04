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
        await _customerRepository.DeleteCustomer(id);
        return Ok();
    }
}