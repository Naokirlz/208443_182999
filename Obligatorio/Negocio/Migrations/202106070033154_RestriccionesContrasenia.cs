namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestriccionesContrasenia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contrasenia",
                c => new
                    {
                        ContraseniaId = c.Int(nullable: false, identity: true),
                        Sitio = c.String(nullable: false, maxLength: 25),
                        Usuario = c.String(nullable: false, maxLength: 25),
                        Notas = c.String(maxLength: 250),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                        CantidadVecesEncontradaVulnerable = c.Int(nullable: false),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ContraseniaId)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.Password",
                c => new
                    {
                        ContraseniaId = c.Int(nullable: false),
                        Clave = c.String(nullable: false),
                        Mayuscula = c.Boolean(nullable: false),
                        Minuscula = c.Boolean(nullable: false),
                        Numero = c.Boolean(nullable: false),
                        Especial = c.Boolean(nullable: false),
                        Largo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContraseniaId)
                .ForeignKey("dbo.Contrasenia", t => t.ContraseniaId)
                .Index(t => t.ContraseniaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Password", "ContraseniaId", "dbo.Contrasenia");
            DropForeignKey("dbo.Contrasenia", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.Password", new[] { "ContraseniaId" });
            DropIndex("dbo.Contrasenia", new[] { "Categoria_Id" });
            DropTable("dbo.Password");
            DropTable("dbo.Contrasenia");
        }
    }
}
