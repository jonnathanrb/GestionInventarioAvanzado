using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models.DTO
{
    public class CreateProductDTO
    {

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(250)]
        public string Description { get; set; }

        [Required, StringLength(25)]
        public string SKU { get; set; }

        [Required, Range(0, double.MaxValue), Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }  // Precio de venta

        [Required, Range(0, double.MaxValue), Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }   // Precio de compra

        [Required, Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }  // Cantidad en stock

        [Required, Range(0, int.MaxValue)]
        public int ReorderQuantity { get; set; }    // Cantidad mínima que debe haber antes de enviar una alerta por falta de stock

        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        public int ProviderId { get; set; }
    }
}
