using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Services;

public class OrderService(AppDbContext context) : GeneralServices(context), IOrderRepository
{
    public async Task<bool> CheckExist(int id)
    {
        if (await _context.Orders.FindAsync(id) == null)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> CheckExistUser(int id)
    {
        if (await _context.Users.FindAsync(id) == null)
        {
            return false;
        }
        return true;
    }

    public async Task Create(Order model)
    {
        await _context.Orders.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Order model)
    {
        _context.Orders.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAll()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetById(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task Update(Order model)
    {
        _context.Entry(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}