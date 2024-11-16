using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models.DTO
{
    public class CreateProviderDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Adress { get; set; }

        [MaxLength(300)]
        public string Email { get; set; }

        [MaxLength(25)]
        public string PhoneNumber { get; set; }
    }
}
