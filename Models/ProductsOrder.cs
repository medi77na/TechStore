using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Models;

[Table("products_orders")]
public class ProductsOrder
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("id_product")]
    public int ProductId { get; set; }

    [Column("id_order")]
    public int OrderId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? product { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order? order { get; set; }
}