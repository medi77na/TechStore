using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Seeders;

public class RoleSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role {Id = 4, Name = "Ventas"},
            new Role { Id = 5, Name = "Atención al cliente"},
            new  Role {Id = 6, Name = "Inventario"},
            new Role { Id = 9, Name = "Administrador"},
            new Role { Id = 15, Name = "Gerente"}
        );
    }
}