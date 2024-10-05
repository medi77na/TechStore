using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Repository;

namespace TechStore.Services;

public class CategoryProductService(AppDbContext context) : GeneralServices(context), ICategoryProductRepository
{
    public async Task<bool> CheckExist(int id)
    {
        if (await _context.CategoryProducts.FindAsync(id) != null)
        {
            return true;
        }
        return false;
    }

    public async Task Create(CategoryProduct model)
    {
        await _context.CategoryProducts.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(CategoryProduct model)
    {
        _context.CategoryProducts.Remove(model);
        await _context.SaveChangesAsync();

    }

    public async Task<List<CategoryProduct>> GetAll()
    {
        return await _context.CategoryProducts.ToListAsync();
    }

    public async Task<CategoryProduct?> GetById(int id)
    {
        return await _context.CategoryProducts.FindAsync(id);
    }

    public async Task Update(CategoryProduct model)
    {
        _context.Entry(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}