using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Services;
public class CustomerService(AppDbContext context) : GeneralServices(context), ICustomerRepository
{
    public async Task<bool> CheckExist(int id)
    {
        if (await _context.Users.FindAsync(id) == null)
        {
            return false;
        }
        return true;
    }

    public async Task Create(User model)
    {
        await _context.Users.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(User model)
    {
        _context.Users.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.Users.Where(u => u.Role_id == 2).ToListAsync();
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task Update(User model)
    {
        _context.Entry(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}