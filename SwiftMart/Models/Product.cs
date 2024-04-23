using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SwiftMart.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public byte[]? ImageData { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
