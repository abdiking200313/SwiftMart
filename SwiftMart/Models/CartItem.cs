using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwiftMart.Models;

[Table("CartItem")]
public partial class CartItem
{
    [Key]
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("CartItems")]
    public virtual Product? Product { get; set; }
}
