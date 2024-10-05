using TechStore.Models;

namespace TechStore.Repository;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task<Product> GetById(int id);
    Task Delete(Product model);
    Task Update(Product model);
    Task Create(Product model);
    Task<bool> CheckExist(int id);
    Task<bool> CheckExistCategory(int id);
}