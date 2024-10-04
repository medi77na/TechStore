using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Services;
public class CustomerRepository(AppDbContext context) : GeneralRepository(context), ICustomerRepository
{
    public async Task<bool> CheckExist(int id)
    {
        if (await _context.Users.FindAsync(id) == null)
        {
            return false;
        }
        return true;
    }

    public async Task CreateCustomer(User model)
    {
        await _context.Users.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomer(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<User>> GetAllCustomers()
    {
        return await _context.Users.ToListAsync();
    }

    public User GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCustomer(User model)
    {
        throw new NotImplementedException();
    }
}