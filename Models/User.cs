using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TechStore.Models;

[Table("users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("lastname")]
    public string? LastName { get; set; }

    [Column("adress")]
    public string? Adress { get; set; }

    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [Column("email")]
    public string? Email { get; set; }
    
    [Column("id_role")]
    public int Role_id { get; set; }

    [ForeignKey(nameof(Role_id))]
    public Role? Role { get; set; }
}