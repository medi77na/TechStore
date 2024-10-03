using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Models;

[Table("products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("price")]
    public double Price { get; set; }
    
    [Column("quantity")]
    public int Quantity { get; set; }
    
    [Column("id_category_products")]
    public int CategoryProductsId { get; set; }

    [ForeignKey(nameof(CategoryProductsId))]
    public CategoryProduct? categoryProducts  { get; set; }
}
