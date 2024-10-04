using TechStore.Data;

namespace TechStore.Services;

public class GeneralRepository
{
    protected readonly AppDbContext _context;
    protected GeneralRepository(AppDbContext context)
    {
        _context = context;
    }
}