
using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.CategoriesProducts
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("CategoryProduct")]
    public class CategoryProductDeleteController(ICategoryProductRepository categoryProductRepository) : CategoryProductController(categoryProductRepository)
    {

        [HttpDelete]
        public async Task<ActionResult> DeleteCategoryProduct(int id)
        {
            if (!await _categoryProductRepository.CheckExist(id))
            {
                return NotFound();
            }
            await _categoryProductRepository.Delete(await _categoryProductRepository.GetById(id));

            return NoContent();
        }
    }
}