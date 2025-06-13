namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        Biografia = c.String(maxLength: 1000),
                        FechaNacimiento = c.DateTime(),
                        Nacionalidad = c.String(maxLength: 100),
                        FotoPerfil = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LibroAutors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibroId = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autors", t => t.AutorId, cascadeDelete: true)
                .ForeignKey("dbo.Libroes", t => t.LibroId, cascadeDelete: true)
                .Index(t => t.LibroId)
                .Index(t => t.AutorId);
            
            CreateTable(
                "dbo.Libroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 200),
                        ISBN = c.String(maxLength: 13),
                        Descripcion = c.String(maxLength: 1000),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        FechaPublicacion = c.DateTime(),
                        NumeroPaginas = c.Int(),
                        Idioma = c.String(maxLength: 50),
                        ImagenPortada = c.String(maxLength: 500),
                        Estado = c.String(maxLength: 20),
                        EditorialId = c.Int(nullable: false),
                        FotoLibro = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Editorials", t => t.EditorialId, cascadeDelete: true)
                .Index(t => t.EditorialId);
            
            CreateTable(
                "dbo.Carritoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        LibroId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        FechaAgregado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libroes", t => t.LibroId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.LibroId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 200),
                        Contraseña = c.String(nullable: false, maxLength: 500),
                        PerfilId = c.Int(),
                        EmpleadoId = c.Int(),
                        ClienteId = c.Int(),
                        FechaRegistro = c.DateTime(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 20),
                        UltimoAcceso = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoId)
                .ForeignKey("dbo.Perfils", t => t.PerfilId)
                .Index(t => t.PerfilId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(maxLength: 20),
                        FechaNacimiento = c.DateTime(),
                        Genero = c.String(maxLength: 10),
                        FotoPerfil = c.String(maxLength: 500),
                        Ocupacion = c.String(maxLength: 100),
                        FechaRegistro = c.DateTime(),
                        EsClientePreferido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Tipo = c.String(nullable: false, maxLength: 20),
                        Calle = c.String(nullable: false, maxLength: 200),
                        Ciudad = c.String(nullable: false, maxLength: 100),
                        Estado = c.String(maxLength: 100),
                        CodigoPostal = c.String(maxLength: 10),
                        Pais = c.String(maxLength: 100),
                        EsPrincipal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(maxLength: 20),
                        FechaNacimiento = c.DateTime(),
                        Genero = c.String(maxLength: 10),
                        FotoPerfil = c.String(maxLength: 500),
                        CodigoEmpleado = c.String(nullable: false, maxLength: 20),
                        Cargo = c.String(nullable: false, maxLength: 100),
                        Departamento = c.String(maxLength: 100),
                        FechaContratacion = c.DateTime(nullable: false),
                        Salario = c.Decimal(precision: 18, scale: 2),
                        Horario = c.String(maxLength: 50),
                        SupervisorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleadoes", t => t.SupervisorId)
                .Index(t => t.SupervisorId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        EmpleadoProcesadorId = c.Int(),
                        FechaVenta = c.DateTime(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 20),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DireccionEnvioId = c.Int(nullable: false),
                        MetodoPago = c.String(maxLength: 50),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Direccions", t => t.DireccionEnvioId, cascadeDelete: true)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoProcesadorId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.UsuarioId)
                .Index(t => t.EmpleadoProcesadorId)
                .Index(t => t.DireccionEnvioId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.DetalleVentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VentaId = c.Int(nullable: false),
                        LibroId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libroes", t => t.LibroId, cascadeDelete: true)
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.VentaId)
                .Index(t => t.LibroId);
            
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 500),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reseña",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        LibroId = c.Int(nullable: false),
                        Calificacion = c.Int(nullable: false),
                        Comentario = c.String(maxLength: 1000),
                        FechaReseña = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libroes", t => t.LibroId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.LibroId);
            
            CreateTable(
                "dbo.UsuarioRols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        RolId = c.Int(nullable: false),
                        FechaAsignacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rols", t => t.RolId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 200),
                        Permisos = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Editorials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        Direccion = c.String(maxLength: 300),
                        Telefono = c.String(maxLength: 20),
                        Email = c.String(maxLength: 200),
                        SitioWeb = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LibroCategorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibroId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Libroes", t => t.LibroId, cascadeDelete: true)
                .Index(t => t.LibroId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 500),
                        Imagen = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibroCategorias", "LibroId", "dbo.Libroes");
            DropForeignKey("dbo.LibroCategorias", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.LibroAutors", "LibroId", "dbo.Libroes");
            DropForeignKey("dbo.Libroes", "EditorialId", "dbo.Editorials");
            DropForeignKey("dbo.Ventas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRols", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRols", "RolId", "dbo.Rols");
            DropForeignKey("dbo.Reseña", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Reseña", "LibroId", "dbo.Libroes");
            DropForeignKey("dbo.Usuarios", "PerfilId", "dbo.Perfils");
            DropForeignKey("dbo.Ventas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Ventas", "EmpleadoProcesadorId", "dbo.Empleadoes");
            DropForeignKey("dbo.Ventas", "DireccionEnvioId", "dbo.Direccions");
            DropForeignKey("dbo.DetalleVentas", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.DetalleVentas", "LibroId", "dbo.Libroes");
            DropForeignKey("dbo.Usuarios", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "SupervisorId", "dbo.Empleadoes");
            DropForeignKey("dbo.Direccions", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Carritoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Carritoes", "LibroId", "dbo.Libroes");
            DropForeignKey("dbo.LibroAutors", "AutorId", "dbo.Autors");
            DropIndex("dbo.LibroCategorias", new[] { "CategoriaId" });
            DropIndex("dbo.LibroCategorias", new[] { "LibroId" });
            DropIndex("dbo.UsuarioRols", new[] { "RolId" });
            DropIndex("dbo.UsuarioRols", new[] { "UsuarioId" });
            DropIndex("dbo.Reseña", new[] { "LibroId" });
            DropIndex("dbo.Reseña", new[] { "UsuarioId" });
            DropIndex("dbo.DetalleVentas", new[] { "LibroId" });
            DropIndex("dbo.DetalleVentas", new[] { "VentaId" });
            DropIndex("dbo.Ventas", new[] { "Usuario_Id" });
            DropIndex("dbo.Ventas", new[] { "DireccionEnvioId" });
            DropIndex("dbo.Ventas", new[] { "EmpleadoProcesadorId" });
            DropIndex("dbo.Ventas", new[] { "UsuarioId" });
            DropIndex("dbo.Empleadoes", new[] { "SupervisorId" });
            DropIndex("dbo.Direccions", new[] { "UsuarioId" });
            DropIndex("dbo.Usuarios", new[] { "ClienteId" });
            DropIndex("dbo.Usuarios", new[] { "EmpleadoId" });
            DropIndex("dbo.Usuarios", new[] { "PerfilId" });
            DropIndex("dbo.Carritoes", new[] { "LibroId" });
            DropIndex("dbo.Carritoes", new[] { "UsuarioId" });
            DropIndex("dbo.Libroes", new[] { "EditorialId" });
            DropIndex("dbo.LibroAutors", new[] { "AutorId" });
            DropIndex("dbo.LibroAutors", new[] { "LibroId" });
            DropTable("dbo.Categorias");
            DropTable("dbo.LibroCategorias");
            DropTable("dbo.Editorials");
            DropTable("dbo.Rols");
            DropTable("dbo.UsuarioRols");
            DropTable("dbo.Reseña");
            DropTable("dbo.Perfils");
            DropTable("dbo.DetalleVentas");
            DropTable("dbo.Ventas");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Direccions");
            DropTable("dbo.Clientes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Carritoes");
            DropTable("dbo.Libroes");
            DropTable("dbo.LibroAutors");
            DropTable("dbo.Autors");
        }
    }
}
