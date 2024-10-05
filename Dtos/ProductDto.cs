using System.ComponentModel.DataAnnotations;

namespace TechStore.Dtos;

public class ProductDto
{
    [Required(ErrorMessage = "El nombre del producto es requerido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre del producto debe tener entre 2 y 100 caracteres.")]
    public string? Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "El precio es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
    public double Price { get; set; }

    [Required(ErrorMessage = "La cantidad es requerida.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "El ID de la categoría es requerido.")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID de la categoría debe ser mayor a 0.")]
    public int CategoryProductsId { get; set; }
}