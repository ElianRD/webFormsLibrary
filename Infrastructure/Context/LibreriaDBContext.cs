using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class LibreriaDbContext : DbContext
    {
        public LibreriaDbContext() : base("name=LibreriaDbContext") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Reseña> Reseñas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venta>()
                .HasRequired(v => v.Usuario)
                .WithMany() // o .WithMany(u => u.Ventas) si tienes una colección en Usuario
                .HasForeignKey(v => v.UsuarioId)
                .WillCascadeOnDelete(false); // <--- esta es la parte clave

            base.OnModelCreating(modelBuilder);
        }
    }
}
