using System.ComponentModel.DataAnnotations;

namespace TechStore.Dtos;

public class ProductOrderDto
{
    [Required(ErrorMessage = "La cantidad es requerida.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "El ID del producto es requerido.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "El ID de la orden es requerida.")]
    public int OrderId { get; set; }
}