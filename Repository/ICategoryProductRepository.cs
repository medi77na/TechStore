using TechStore.Models;

namespace TechStore.Repository;
public interface ICategoryProductRepository
{
    Task CreateCategory(CategoryProduct model);
    Task UpdateCategory(CategoryProduct model);
    Task DeleteCategory(CategoryProduct model);
    Task<List<CategoryProduct>> GetAllCategories();
    Task<CategoryProduct?> GetCategoryProductById(int id);
    Task<bool> CheckExist(int id);
}