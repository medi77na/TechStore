using AutoMapper;
using TechStore.Dtos;
using TechStore.Models;

namespace TechStore.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerDto, User>();
        CreateMap<CategoryProductDto, CategoryProduct>();
        CreateMap<ProductDto, Product>();
        CreateMap<OrderDto, Order>();
        CreateMap<EmployeeDto, User>();
    }
}