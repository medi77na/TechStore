using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
[Tags("Product")]
public class ProductDeleteController(IProductRepository productRepository) : ProductController(productRepository)
{

    [HttpDelete]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        if (!await _productRepository.CheckExist(id))
        {
            return NotFound();
        }
        await _productRepository.Delete(await _productRepository.GetById(id));

        return NoContent();
    }

}