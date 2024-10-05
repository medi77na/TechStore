using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TechStore.Dtos;
using TechStore.Repository;
using TechStore.Models;

namespace TechStore.Controllers.Customer;

[ApiController]
[Route("api/[controller]")]
[Tags("Customer")]
public class CustomerPostController(ICustomerRepository customerRepository, IMapper mapper) : CustomerController(customerRepository, mapper)
{
    [HttpPost]
    public async Task<ActionResult<User>> CreateCustomer(CustomerDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = _mapper.Map<User>(model);
        user.Role_id = 2;

        await _customerRepository.Create(user);

        return Ok(user);
    }
}