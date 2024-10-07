using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Employees;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : GeneralController
{
    protected readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper) : base(mapper)
    {
        _employeeRepository = employeeRepository;
    }

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
}