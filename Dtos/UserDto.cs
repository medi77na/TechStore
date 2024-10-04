using System.ComponentModel.DataAnnotations;

namespace TechStore.Dtos;

public class UserDto
{
    [Required(ErrorMessage = "El nombre  es requerido.")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "El apellido es requerido.")]
    public string? LastName { get; set; }
    
    [Required(ErrorMessage = "El teléfono es requerido")]
    public string? PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "El email es requerido")]
    public string? Email { get; set; }
}