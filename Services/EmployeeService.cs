using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Services;

public class EmployeeService(AppDbContext context) : GeneralServices(context), IEmployeeRepository
{
    public async Task<bool> CheckExist(int id)
    {
        var employee = await _context.Users.FindAsync(id);

        if ( employee == null)
        {
            return false;
        }

        if (employee.Role_id == 2)
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
        return await _context.Users.Where(u => u.Role_id != 2).ToListAsync();
    }

    public Task<User> GetByEmail(string email)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
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