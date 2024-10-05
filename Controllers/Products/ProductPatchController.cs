using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
[Tags("Product")]
public class ProductPatchController(IProductRepository productRepository) : ProductController(productRepository)
{
    [HttpPatch]
    public async Task<ActionResult> UpdateStockQuantity(int id, int quantity)
    {
        if (quantity < 0)
        {
            return BadRequest("Cantidad no válida");
        }

        if (!await _productRepository.CheckExist(id))
        {
            return NotFound();
        }

        var product = await _productRepository.GetById(id);

        product.Quantity = quantity;

        await _productRepository.Update(product);

        return Ok(product);
    } 
}