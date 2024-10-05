using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
[Tags("Product")]
public class ProductPostController(IProductRepository productRepository, IMapper mapper) : ProductController(productRepository, mapper)
{
    [HttpPost]
    public async Task<ActionResult> CreateProduct(ProductDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        if (await _productRepository.CheckExistCategory(model.CategoryProductsId))
        {
            return  BadRequest("La categoría no existe");

        }

        await _productRepository.Create(_mapper.Map<Product>(model));

        return Ok();
    }
}