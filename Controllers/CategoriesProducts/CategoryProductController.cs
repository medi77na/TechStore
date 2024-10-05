using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.CategoriesProducts;

[ApiController]
[Route("api/[controller]")]
public class CategoryProductController : GeneralController
{
    protected readonly ICategoryProductRepository _categoryProductRepository;

    public CategoryProductController(ICategoryProductRepository categoryProductRepository, IMapper mapper) : base(mapper)
    {
        _categoryProductRepository = categoryProductRepository;
    }

    public CategoryProductController(ICategoryProductRepository categoryProductRepository)
    {
        _categoryProductRepository = categoryProductRepository;
    }
}