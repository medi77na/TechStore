using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Customer;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerRepository customerRepository, IMapper mapper) : GeneralController(mapper)
{
    protected readonly ICustomerRepository _customerRepository = customerRepository;
}