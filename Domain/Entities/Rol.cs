using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rol
    {
        //public Rol()
        //{
        //    UsuarioRoles = new HashSet<UsuarioRol>();
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        [StringLength(1000)]
        public string Permisos { get; set; }

        // Navegación
        public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; }
    }
}
