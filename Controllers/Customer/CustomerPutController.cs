using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Repository;

namespace TechStore.Controllers.Customer;

[ApiController]
[Route("api/[controller]")]
[Tags("Customer")]
public class CustomerPutController(ICustomerRepository customerService, IMapper mapper) : CustomerController(customerService, mapper)
{
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CustomerDto model)
    {
        if (!ModelState.IsValid)
        {
            return  BadRequest(ModelState);
        }

        if (!await _customerRepository.CheckExist(id))
        {
            return NotFound();
        }

        var customer = await _customerRepository.GetCustomerById(id);

        if (customer.Role_id != 2)
        {
            return Unauthorized();

        }

        _mapper.Map(model, customer);

        await _customerRepository.UpdateCustomer(customer);

        return NoContent();
    }
}