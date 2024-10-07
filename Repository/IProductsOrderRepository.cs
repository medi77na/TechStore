using TechStore.Models;

namespace TechStore.Repository;

public interface IProductsOrderRepository
{
    Task<List<ProductsOrder>> GetAll();
    Task<ProductsOrder> GetById(int id);
    Task<List<ProductsOrder>> GetByOrderId(int id);
    Task Delete(ProductsOrder model);
    Task Update(ProductsOrder model);
    Task Create(ProductsOrder model);
    Task<bool> CheckExist(int id);
    Task<bool> CheckExistProduct(int id);
    Task<bool> CheckExistCategory(int id);
}