namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeAgregaHistorial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistorialContrasenia",
                c => new
                    {
                        HistorialId = c.Int(nullable: false),
                        ContraseniaId = c.Int(nullable: false),
                        Clave = c.String(),
                    })
                .PrimaryKey(t => new { t.HistorialId, t.ContraseniaId })
                .ForeignKey("dbo.Historial", t => t.HistorialId, cascadeDelete: true)
                .Index(t => t.HistorialId);
            
            CreateTable(
                "dbo.Historial",
                c => new
                    {
                        HistorialId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.HistorialId);
            
            CreateTable(
                "dbo.HistorialTarjetas",
                c => new
                    {
                        HistorialId = c.Int(nullable: false),
                        NumeroTarjeta = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.HistorialId, t.NumeroTarjeta })
                .ForeignKey("dbo.Historial", t => t.HistorialId, cascadeDelete: true)
                .Index(t => t.HistorialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistorialContrasenia", "HistorialId", "dbo.Historial");
            DropForeignKey("dbo.HistorialTarjetas", "HistorialId", "dbo.Historial");
            DropIndex("dbo.HistorialTarjetas", new[] { "HistorialId" });
            DropIndex("dbo.HistorialContrasenia", new[] { "HistorialId" });
            DropTable("dbo.HistorialTarjetas");
            DropTable("dbo.Historial");
            DropTable("dbo.HistorialContrasenia");
        }
    }
}
