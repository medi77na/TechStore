using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.Customer;

[ApiController]
[Route("api/[controller]")]
[Tags("Customer")]
public class CustomerGetController(ICustomerRepository customerRepository, IMapper mapper) : CustomerController(customerRepository,mapper)
{
    [HttpGet]
    public async Task<List<User>> GetAllCustomers()
    {
        return await _customerRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetCustomerById(int id)
    {
        if (!await _customerRepository.CheckExist(id))
        {
            return NotFound();
        }

        var userFinded = await _customerRepository.GetById(id);

        if (userFinded.Role_id != 2)
        {
            return NotFound();
        }

        return Ok(userFinded);
    }
}