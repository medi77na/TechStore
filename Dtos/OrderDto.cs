using System.ComponentModel.DataAnnotations;

namespace TechStore.Dtos;

public class OrderDto
{
    [Required]
    [StringLength(50)]
    public string? State { get; set; }

    [Required]
    public int UserId { get; set; }
}