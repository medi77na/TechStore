using TechStore.Models;

namespace TechStore.Repository;

public interface IOrderRepository
{
    Task<List<Order>> GetAll();
    Task<Order> GetById(int id);
    Task Delete(Order model);
    Task Update(Order model);
    Task Create(Order model);
    Task<bool> CheckExist(int id);
    Task<bool> CheckExistUser(int id);
}