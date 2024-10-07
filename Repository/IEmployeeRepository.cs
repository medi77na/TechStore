using TechStore.Models;

namespace TechStore.Repository;

public interface IEmployeeRepository
{
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task<User> GetByEmail(string email);
    Task Delete(User model);
    Task Update(User model);
    Task Create(User model);
    Task<bool> CheckExist(int id);
}