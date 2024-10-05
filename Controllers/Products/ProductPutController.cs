using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Repository;

namespace TechStore.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
[Tags("Product")]
public class ProductPutController(IProductRepository productRepository, IMapper mapper) : ProductController(productRepository, mapper)
{
    [HttpPut]
    public async Task<ActionResult> UpdateCategory(int id, ProductDto model)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        if (!await _productRepository.CheckExist(id))
        {
            return NotFound();
        }

        if (!await _productRepository.CheckExistCategory(model.CategoryProductsId))
        {
            return BadRequest("La categoría no existe.");
        }
        var product = await _productRepository.GetById(id);

        _mapper.Map(model, product);

        await _productRepository.Update(product);

        return Ok(product);
    }
}