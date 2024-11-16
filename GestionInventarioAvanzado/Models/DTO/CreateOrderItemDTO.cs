using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models.DTO
{
    public class CreateOrderItemDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required, Range(0, double.MaxValue), Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required, Range(0, double.MaxValue), Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}
