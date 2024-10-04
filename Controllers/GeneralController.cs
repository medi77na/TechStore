using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TechStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeneralController(IMapper mapper) : ControllerBase
{
    protected readonly IMapper _mapper = mapper;
}
