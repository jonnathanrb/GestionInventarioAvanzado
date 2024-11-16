﻿using System.ComponentModel.DataAnnotations;

namespace GestionInventarioAvanzado.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Adress { get; set; }

        [MaxLength(300)]
        public string Email { get; set; }

        [MaxLength(25)]
        public string PhoneNumber { get; set; }

        // Auditoría
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
