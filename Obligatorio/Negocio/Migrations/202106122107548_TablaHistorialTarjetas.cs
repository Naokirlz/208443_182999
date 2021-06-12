namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaHistorialTarjetas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistorialTarjetas",
                c => new
                    {
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumeroTarjeta = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Fecha, t.NumeroTarjeta })
                .ForeignKey("dbo.Historial", t => t.Fecha, cascadeDelete: true)
                .Index(t => t.Fecha);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistorialTarjetas", "Fecha", "dbo.Historial");
            DropIndex("dbo.HistorialTarjetas", new[] { "Fecha" });
            DropTable("dbo.HistorialTarjetas");
        }
    }
}
