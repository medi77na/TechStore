using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Customer;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : GeneralController
{
    protected readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository, IMapper mapper) : base(mapper)
    {
        _customerRepository = customerRepository;
    }

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
}