using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models.DTO
{
    public class CreateProductCategoryDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Description { get; set; }
    }
}
