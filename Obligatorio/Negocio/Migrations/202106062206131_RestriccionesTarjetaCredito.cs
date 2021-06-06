namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestriccionesTarjetaCredito : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TarjetaCredito", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.TarjetaCredito", new[] { "Categoria_Id" });
            RenameColumn(table: "dbo.TarjetaCredito", name: "Categoria_Id", newName: "IdCategoria");
            AlterColumn("dbo.TarjetaCredito", "Nombre", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.TarjetaCredito", "Tipo", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.TarjetaCredito", "Numero", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.TarjetaCredito", "Codigo", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.TarjetaCredito", "Nota", c => c.String(maxLength: 250));
            AlterColumn("dbo.TarjetaCredito", "IdCategoria", c => c.Int(nullable: false));
            CreateIndex("dbo.TarjetaCredito", "IdCategoria");
            AddForeignKey("dbo.TarjetaCredito", "IdCategoria", "dbo.Categoria", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TarjetaCredito", "IdCategoria", "dbo.Categoria");
            DropIndex("dbo.TarjetaCredito", new[] { "IdCategoria" });
            AlterColumn("dbo.TarjetaCredito", "IdCategoria", c => c.Int());
            AlterColumn("dbo.TarjetaCredito", "Nota", c => c.String());
            AlterColumn("dbo.TarjetaCredito", "Codigo", c => c.String());
            AlterColumn("dbo.TarjetaCredito", "Numero", c => c.String());
            AlterColumn("dbo.TarjetaCredito", "Tipo", c => c.String());
            AlterColumn("dbo.TarjetaCredito", "Nombre", c => c.String());
            RenameColumn(table: "dbo.TarjetaCredito", name: "IdCategoria", newName: "Categoria_Id");
            CreateIndex("dbo.TarjetaCredito", "Categoria_Id");
            AddForeignKey("dbo.TarjetaCredito", "Categoria_Id", "dbo.Categoria", "Id");
        }
    }
}
