using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Autor
    {
        //public Autor()
        //{
        //    LibroAutores = new HashSet<LibroAutor>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [StringLength(1000)]
        public string Biografia { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [StringLength(100)]
        public string Nacionalidad { get; set; }
        [StringLength(500)]
        public string FotoPerfil { get; set; }

        // Navegación
        public virtual ICollection<LibroAutor> LibroAutores { get; set; }
    }
}
