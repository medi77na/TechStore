using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data;

public class AppDbContext(DbContextOptions options) :  DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role>? Roles { get; set; }
    public  DbSet<Order>? Orders { get; set; }
    public  DbSet<Product>? Products { get; set; }
    public  DbSet<ProductsOrder>? ProductsOrders { get; set; }
    public  DbSet<CategoryProduct>? CategoryProducts { get; set; }
}
