using GestionInventarioAvanzado.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionInventarioAvanzado.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        [Required, Range(0, int.MaxValue), Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
