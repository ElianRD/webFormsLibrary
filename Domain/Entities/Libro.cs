using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Libro
    {
        //public Libro()
        //{
        //    Estado = "disponible";
        //    LibroAutores = new HashSet<LibroAutor>();
        //    LibroCategorias = new HashSet<LibroCategoria>();
        //    DetallesVenta = new HashSet<DetalleVenta>();
        //    Carritos = new HashSet<Carrito>();
        //    Reseñas = new HashSet<Reseña>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [StringLength(13)]
        public string ISBN { get; set; }

        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public int? NumeroPaginas { get; set; }

        [StringLength(50)]
        public string Idioma { get; set; }

        [StringLength(500)]
        public string ImagenPortada { get; set; }

        [StringLength(20)]
        public string Estado { get; set; }

        public int EditorialId { get; set; }

        // Navegación
        [ForeignKey("EditorialId")]
        public virtual Editorial Editorial { get; set; }
        [StringLength(500)]
        public string FotoLibro { get; set; }

        public virtual ICollection<LibroAutor> LibroAutores { get; set; }
        public virtual ICollection<LibroCategoria> LibroCategorias { get; set; }
        public virtual ICollection<DetalleVenta> DetallesVenta { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
        public virtual ICollection<Reseña> Reseñas { get; set; }
    }
}