using TechStore.Models;

namespace TechStore.Repository;
public interface ICategoryProductRepository
{
    Task Create(CategoryProduct model);
    Task Update(CategoryProduct model);
    Task Delete(CategoryProduct model);
    Task<List<CategoryProduct>> GetAll();
    Task<CategoryProduct?> GetById(int id);
    Task<bool> CheckExist(int id);
}