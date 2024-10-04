using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Services;
public class CustomerRepository(AppDbContext context) : GeneralRepository(context), ICustomerRepository
{
    public async Task CreateCustomer(User model)
    {
        await _context.Users.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public void DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllCustomers()
    {
        return await _context.Users.ToListAsync();
    }

    public User GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateCustomer(User model)
    {
        throw new NotImplementedException();
    }
}