﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionInventarioAvanzado.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required, Range(0, double.MaxValue), Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required, Range(0, double.MaxValue), Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

    }
}
