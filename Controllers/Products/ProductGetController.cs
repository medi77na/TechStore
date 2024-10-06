using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
[Tags("Product")]
public class ProductGetController(IProductRepository productRepository, IMapper mapper) : ProductController(productRepository, mapper)
{
    [HttpGet]
    public async Task<List<Product>> GetAllProducts()
    {
        return await _productRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> GetProductById(int id)
    {
        if (!await _productRepository.CheckExist(id))
        {
            return NotFound();
        }
        return await _productRepository.GetById(id);
    }
}