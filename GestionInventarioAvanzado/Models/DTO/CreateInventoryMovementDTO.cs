using GestionInventarioAvanzado.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models.DTO
{
    public class CreateInventoryMovementDTO
    {

        [Required]
        public int ProductId { get; set; }

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
