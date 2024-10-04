using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.Customer;

[ApiController]
[Route("api/[controller]")]
public class CustomerGetController(ICustomerRepository customerRepository, IMapper mapper) : CustomerController(customerRepository,mapper)
{
    [HttpGet]
    public async Task<List<User>> GetAllCustomers()
    {
        return await _customerRepository.GetAllCustomers();
    }
}