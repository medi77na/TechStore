using System.ComponentModel.DataAnnotations;

namespace TechStore.Dtos;

public class EmployeeDto : UserDto
{
    [Required(ErrorMessage = "La contraseña es requerida")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "El rol es requerido")]
    public int Role_id { get; set; }
}