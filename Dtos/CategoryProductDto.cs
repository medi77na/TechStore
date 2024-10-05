using System.ComponentModel.DataAnnotations;

namespace TechStore.Dtos;

public class CategoryProductDto
{
    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Description { get; set; }
}