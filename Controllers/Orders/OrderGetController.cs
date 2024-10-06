using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.Orders;

[ApiController]
[Route("api/[controller]")]
[Tags("Order")]
public class OrderGetController(IOrderRepository orderRepository) : OrderController(orderRepository)
{
    [HttpGet]
    public async Task<List<Order>> GetAllProducts()
    {
        return await _orderRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order?>> GetProductById(int id)
    {
        if (!await _orderRepository.CheckExist(id))
        {
            return NotFound();
        }
        return await _orderRepository.GetById(id);
    }
}