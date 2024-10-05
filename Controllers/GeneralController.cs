using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TechStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeneralController : ControllerBase
{
    protected readonly IMapper _mapper;

    //Constructor with parameters
    public GeneralController(IMapper mapper)
    {
        _mapper = mapper;
    }

    //Constructor empty
    public GeneralController(){ }
}