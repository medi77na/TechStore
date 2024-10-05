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

    public async Task CreateCustomer(User model)
    {
        await _context.Users.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomer(User model)
    {
        _context.Users.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllCustomers()
    {
        return await _context.Users.Where(u => u.Role_id == 2).ToListAsync();
    }

    public async Task<User> GetCustomerById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task UpdateCustomer(User model)
    {
        try
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al actualizar el cliente en la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al actualizar el cliente.", ex);
        }
    }
}