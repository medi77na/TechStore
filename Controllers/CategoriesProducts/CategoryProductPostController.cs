using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.CategoriesProducts;

[ApiController]
[Route("api/[controller]")]
[Tags("CategoryProduct")]
public class CategoryProductPostController(ICategoryProductRepository categoryProductRepository, IMapper mapper) : CategoryProductController(categoryProductRepository, mapper)
{

    [HttpPost]
    public async Task<ActionResult> CreateCategory(CategoryProductDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();            
        }

        var category = _mapper.Map<CategoryProduct>(model);
        await _categoryProductRepository.Create(category);

        return Ok(category);
    }
}