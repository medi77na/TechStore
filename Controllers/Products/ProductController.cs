using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repository;

namespace TechStore.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductController : GeneralController
{

    protected readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository, IMapper mapper) : base(mapper)
    {
        _productRepository = productRepository;
    }

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


}