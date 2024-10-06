using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Repository;

namespace TechStore.Controllers.Orders;

[ApiController]
[Route("api/[controller]")]
[Tags("Order")]
public class OrderPutController(IOrderRepository orderRepository, IMapper mapper) : OrderController(orderRepository, mapper)
{
        [HttpPut]
    public async Task<ActionResult> UpdateCategory(int id, OrderDto model)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        if (!await _orderRepository.CheckExist(id))
        {
            return NotFound();
        }

        if (!await _orderRepository.CheckExistUser(model.UserId))
        {
            return BadRequest("El usuario no existe.");
        }
        var order = await _orderRepository.GetById(id);

        _mapper.Map(model, order);

        await _orderRepository.Update(order);

        return Ok(order);
    }
}