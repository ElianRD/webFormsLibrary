using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria
    {
        //public Categoria()
        //{
        //    LibroCategorias = new HashSet<LibroCategoria>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(500)]
        public string Imagen { get; set; }

        // Navegación
        public virtual ICollection<LibroCategoria> LibroCategorias { get; set; }
    }
}
