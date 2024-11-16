using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(250)]
        public string Description { get; set; }
    }
}
