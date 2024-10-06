using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Orders;

[ApiController]
[Route("api/[controller]")]
public class OrderController : GeneralController
{
    protected readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository, IMapper mapper) : base(mapper)
    {
        _orderRepository =  orderRepository;
    }

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository =  orderRepository;
    }
}