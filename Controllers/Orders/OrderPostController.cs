using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.Orders;

[ApiController]
[Route("api/[controller]")]
[Tags("Order")]
public class OrderPostController(IOrderRepository orderRepository, IMapper mapper) : OrderController(orderRepository, mapper)
{
    [HttpPost]
    public async Task<ActionResult> CreateProduct(OrderDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        if (!await _orderRepository.CheckExistUser(model.UserId))
        {
            return BadRequest("El usuario no existe");
        }

        var  order = mapper.Map<Order>(model);
        order.Date = DateOnly.FromDateTime(DateTime.Now);

        await _orderRepository.Create(order);

        return Ok(order);
    }
}