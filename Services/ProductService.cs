using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Services;

public class ProductService(AppDbContext context) : GeneralServices(context), IProductRepository
{
    public async Task<bool> CheckExist(int id)
    {
        if (await _context.Products.FindAsync(id) == null)
        {
            return false;
        }
        return true;
    }

    public async Task Create(Product model)
    {
        await _context.Products.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product model)
    {
        _context.Products.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task Update(Product model)
    {
        _context.Entry(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckExistCategory(int id)
    {
        if (await _context.CategoryProducts.FindAsync(id)  != null)
        {
            return  true;
        }
        return false;
    }
}
