using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Controllers.CategoriesProducts;

[ApiController]
[Route("api/[controller]")]
[Tags("CategoryProduct")]
public class CategoryProductGetController(ICategoryProductRepository categoryProductRepository) : CategoryProductController(categoryProductRepository)
{
    [HttpGet]
    public async Task<List<CategoryProduct>> GetAllCategories()
    {
        return await _categoryProductRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async  Task<ActionResult<CategoryProduct?>> GetCategoryById(int id)
    {
        if (!await _categoryProductRepository.CheckExist(id))
        {
            return NotFound();
        }
        return await _categoryProductRepository.GetById(id);
    }
}