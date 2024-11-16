using GestionInventarioAvanzado.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models
{
    public class InventoryMovement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public MovementType MovementType { get; set; }
        public DateTime Date { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }
    }
}
