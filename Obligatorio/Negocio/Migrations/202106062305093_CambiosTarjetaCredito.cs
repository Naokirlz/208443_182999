namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosTarjetaCredito : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TarjetaCredito", "IdCategoria", "dbo.Categoria");
            DropIndex("dbo.TarjetaCredito", new[] { "IdCategoria" });
            RenameColumn(table: "dbo.TarjetaCredito", name: "IdCategoria", newName: "Categoria_Id");
            AlterColumn("dbo.TarjetaCredito", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.TarjetaCredito", "Categoria_Id");
            AddForeignKey("dbo.TarjetaCredito", "Categoria_Id", "dbo.Categoria", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TarjetaCredito", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.TarjetaCredito", new[] { "Categoria_Id" });
            AlterColumn("dbo.TarjetaCredito", "Categoria_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.TarjetaCredito", name: "Categoria_Id", newName: "IdCategoria");
            CreateIndex("dbo.TarjetaCredito", "IdCategoria");
            AddForeignKey("dbo.TarjetaCredito", "IdCategoria", "dbo.Categoria", "Id", cascadeDelete: true);
        }
    }
}
