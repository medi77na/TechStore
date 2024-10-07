using System.ComponentModel.DataAnnotations;

namespace TechStore.Dtos;

public class AuthDto
{
    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida")]
    public string? Password { get; set; }
}