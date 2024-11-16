using GestionInventarioAvanzado.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required, Range(0, int.MaxValue), Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
