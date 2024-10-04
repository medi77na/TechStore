using System.ComponentModel.DataAnnotations;

namespace TechStore.Dtos;

public class CustomerDto : UserDto
{
    [Required(ErrorMessage = "La dirección es requerida")]
    public string? Adress { get; set; }
}