using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFUpskilling.Entities;

[Table(name: "m_product")]
public class Product
{
    [Key, Column(name: "id")] public Guid Id { get; set; }

    [Column(name: "product_name", TypeName = "NVarchar(50)")]
    public string ProductName { get; set; }

    [Column(name: "product_price")] public long ProductPrice { get; set; }
    [Column(name: "stock")] public int Stock { get; set; }
}