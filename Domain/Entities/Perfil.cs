using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Perfil
    {
        //public Perfil()
        //{
        //    Activo = true;
        //    Usuarios = new HashSet<Usuario>();
        //}

        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }

        // Navegación
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
