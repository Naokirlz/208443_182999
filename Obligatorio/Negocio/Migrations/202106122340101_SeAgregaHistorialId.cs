namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeAgregaHistorialId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HistorialContrasenia", "Fecha", "dbo.Historial");
            DropForeignKey("dbo.HistorialTarjetas", "Fecha", "dbo.Historial");
            DropIndex("dbo.HistorialContrasenia", new[] { "Fecha" });
            DropIndex("dbo.HistorialTarjetas", new[] { "Fecha" });
            RenameColumn(table: "dbo.HistorialContrasenia", name: "Fecha", newName: "HistorialId");
            RenameColumn(table: "dbo.HistorialTarjetas", name: "Fecha", newName: "HistorialId");
            DropPrimaryKey("dbo.Historial");
            DropPrimaryKey("dbo.HistorialContrasenia");
            DropPrimaryKey("dbo.HistorialTarjetas");
            AddColumn("dbo.Historial", "HistorialId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.HistorialContrasenia", "HistorialId", c => c.Int(nullable: false));
            AlterColumn("dbo.HistorialTarjetas", "HistorialId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Historial", "HistorialId");
            AddPrimaryKey("dbo.HistorialContrasenia", new[] { "HistorialId", "ContraseniaId" });
            AddPrimaryKey("dbo.HistorialTarjetas", new[] { "HistorialId", "NumeroTarjeta" });
            CreateIndex("dbo.HistorialContrasenia", "HistorialId");
            CreateIndex("dbo.HistorialTarjetas", "HistorialId");
            AddForeignKey("dbo.HistorialTarjetas", "HistorialId", "dbo.Historial", "HistorialId", cascadeDelete: true);
            AddForeignKey("dbo.HistorialContrasenia", "HistorialId", "dbo.Historial", "HistorialId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistorialContrasenia", "HistorialId", "dbo.Historial");
            DropForeignKey("dbo.HistorialTarjetas", "HistorialId", "dbo.Historial");
            DropIndex("dbo.HistorialTarjetas", new[] { "HistorialId" });
            DropIndex("dbo.HistorialContrasenia", new[] { "HistorialId" });
            DropPrimaryKey("dbo.HistorialTarjetas");
            DropPrimaryKey("dbo.HistorialContrasenia");
            DropPrimaryKey("dbo.Historial");
            AlterColumn("dbo.HistorialTarjetas", "HistorialId", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HistorialContrasenia", "HistorialId", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Historial", "HistorialId");
            AddPrimaryKey("dbo.HistorialTarjetas", new[] { "Fecha", "NumeroTarjeta" });
            AddPrimaryKey("dbo.HistorialContrasenia", new[] { "Fecha", "ContraseniaId" });
            AddPrimaryKey("dbo.Historial", "Fecha");
            RenameColumn(table: "dbo.HistorialTarjetas", name: "HistorialId", newName: "Fecha");
            RenameColumn(table: "dbo.HistorialContrasenia", name: "HistorialId", newName: "Fecha");
            CreateIndex("dbo.HistorialTarjetas", "Fecha");
            CreateIndex("dbo.HistorialContrasenia", "Fecha");
            AddForeignKey("dbo.HistorialTarjetas", "Fecha", "dbo.Historial", "Fecha", cascadeDelete: true);
            AddForeignKey("dbo.HistorialContrasenia", "Fecha", "dbo.Historial", "Fecha", cascadeDelete: true);
        }
    }
}
