namespace Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarFotoAutor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Autors", "FotoPerfil", c => c.String(maxLength: 500));
            AddColumn("dbo.Libroes", "FotoLibro", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Libroes", "FotoLibro");
            DropColumn("dbo.Autors", "FotoPerfil");
        }
    }
}
