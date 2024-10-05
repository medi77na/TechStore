using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Repository;

namespace TechStore.Controllers.CategoriesProducts;

[ApiController]
[Route("api/[controller]")]
[Tags("CategoryProduct")]
public class CategoryProductPutController(ICategoryProductRepository categoryProductRepository, IMapper mapper) : CategoryProductController(categoryProductRepository, mapper)
{
    [HttpPut]
    public async Task<ActionResult> UpdateCategory(int id, CategoryProductDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!await _categoryProductRepository.CheckExist(id))
        {
            return NotFound();
        }

        var category = await _categoryProductRepository.GetById(id);

        _mapper.Map(model, category);

        await _categoryProductRepository.Update(category);

        return Ok(category);
    }
}