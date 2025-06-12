using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Editorial
    {
        //public Editorial()
        //{
        //    Libros = new HashSet<Libro>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [StringLength(300)]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(300)]
        public string SitioWeb { get; set; }

        // Navegación
        public virtual ICollection<Libro> Libros { get; set; }
    }
}