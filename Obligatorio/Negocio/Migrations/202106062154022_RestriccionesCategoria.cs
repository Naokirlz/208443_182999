namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestriccionesCategoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TarjetaCredito",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        Numero = c.String(),
                        Codigo = c.String(),
                        Vencimiento = c.DateTime(nullable: false),
                        Nota = c.String(),
                        CantidadVecesEncontradaVulnerable = c.Int(nullable: false),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            AlterColumn("dbo.Categoria", "Nombre", c => c.String(nullable: false, maxLength: 15));
            CreateIndex("dbo.Categoria", "Nombre", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TarjetaCredito", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.TarjetaCredito", new[] { "Categoria_Id" });
            DropIndex("dbo.Categoria", new[] { "Nombre" });
            AlterColumn("dbo.Categoria", "Nombre", c => c.String());
            DropTable("dbo.TarjetaCredito");
        }
    }
}
