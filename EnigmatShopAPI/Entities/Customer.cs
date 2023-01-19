using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFUpskilling.Entities;

[Table(name: "m_customer")]
public class Customer
{
    [Key, Column(name: "id")]
    public Guid Id { get; set; }

    [Column(name: "customer_name", TypeName = "NVarchar(50)")]
    public string CustomerName { get; set; }

    [Column(name: "address", TypeName = "NVarchar(250)")]
    public string Address { get; set; }

    [Column(name: "mobile_phone", TypeName = "NVarchar(14)")]
    public string MobilePhone { get; set; }

    [Column(name: "email", TypeName = "NVarchar(50)")]
    public string Email { get; set; }
}