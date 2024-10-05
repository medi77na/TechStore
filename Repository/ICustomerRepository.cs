using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Models;

namespace TechStore.Repository;

public interface ICustomerRepository
{
    Task<List<User>> GetAllCustomers();
    Task<User> GetCustomerById(int  id);
    Task DeleteCustomer(int id);
    Task UpdateCustomer(User model);
    Task CreateCustomer(User model);
    Task<bool> CheckExist(int id);
}