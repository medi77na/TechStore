using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Orders;

[ApiController]
[Route("api/[controller]")]
[Tags("Order")]
public class OrderDeleteController(IOrderRepository orderRepository) : OrderController(orderRepository)
{
    [HttpDelete]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        if (!await _orderRepository.CheckExist(id))
        {
            return NotFound();
        }
        await _orderRepository.Delete(await _orderRepository.GetById(id));

        return NoContent();
    }
}