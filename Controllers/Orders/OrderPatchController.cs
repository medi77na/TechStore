using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Orders;

[ApiController]
[Route("api/[controller]")]
[Tags("Order")]
public class OrderPatchController(IOrderRepository orderRepository) : OrderController(orderRepository)
{
    [HttpPatch]
    public async Task<ActionResult> UpdateState(int id, string state)
    {
        if (state != "pendiente" || state != "enviado"  || state != "entregado" )
        {
            return BadRequest("Estado inválido. estados válidos:  pendiente, enviado, entregado");

        }

        if (!await _orderRepository.CheckExist(id))
        {
            return NotFound();
        }

        var order = await _orderRepository.GetById(id);

        order.State = state;

        await _orderRepository.Update(order);

        return Ok(order);
    }
}