using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contact { get; set; }
        public string Direction { get; set; }

    }
}
