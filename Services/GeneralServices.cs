using TechStore.Data;

namespace TechStore.Services;

public class GeneralServices
{
    protected readonly AppDbContext _context;
    protected GeneralServices(AppDbContext context)
    {
        _context = context;
    }
}