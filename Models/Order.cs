using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Models;

[Table("orders")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("id_user")]
    public int UserId { get;  set; }

    [ForeignKey(nameof(UserId))]
    public User user  { get; set; }

}
