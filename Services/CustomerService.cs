using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<User> GetCustomerById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task UpdateCustomer(User model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "El cliente no puede ser nulo.");
        }

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