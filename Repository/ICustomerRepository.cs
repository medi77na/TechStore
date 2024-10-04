using Microsoft.AspNetCore.Mvc;
using TechStore.Dtos;
using TechStore.Models;

namespace TechStore.Repository;

public interface ICustomerRepository
{
    Task<List<User>> GetAllCustomers();
    User GetCustomerById(int  id);
    void DeleteCustomer(int id);
    void UpdateCustomer(User model);
    Task CreateCustomer(User model);
}