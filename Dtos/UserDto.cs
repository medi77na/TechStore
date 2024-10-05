using System.ComponentModel.DataAnnotations;

namespace TechStore.Dtos;

public class UserDto
{
    [Required(ErrorMessage = "El nombre es requerido.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "El apellido es requerido.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "El teléfono es requerido")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos.")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string? Email { get; set; }
}