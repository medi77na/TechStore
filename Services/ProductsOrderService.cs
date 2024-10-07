using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Repository;
using TechStore.Services;

namespace TechStore.Service;

public class ProductsOrderService(AppDbContext context) : GeneralServices(context), IProductsOrderRepository
{
    public async Task<bool> CheckExist(int id)
    {
        if (await _context.ProductsOrders.FindAsync(id) == null)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> CheckExistCategory(int id)
    {
        if (await _context.CategoryProducts.FindAsync(id) == null)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> CheckExistProduct(int id)
    {
        if (await _context.Products.FindAsync(id) == null)
        {
            return false;
        }
        return true;
    }

    public async Task Create(ProductsOrder model)
    {
        await _context.ProductsOrders.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(ProductsOrder model)
    {
        _context.ProductsOrders.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ProductsOrder>> GetAll()
    {
        return await _context.ProductsOrders.ToListAsync();
    }

    public async Task<ProductsOrder> GetById(int id)
    {
        return await _context.ProductsOrders.FindAsync(id);
    }

    public async Task<List<ProductsOrder>> GetByOrderId(int id)
    {
        return await _context.ProductsOrders.Where(p => p.OrderId == id).ToListAsync();
    }

    public async Task Update(ProductsOrder model)
    {
        _context.Entry(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}