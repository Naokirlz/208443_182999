namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaDataBreachesKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DataBreach", "FuenteId", "dbo.Fuentes");
            DropPrimaryKey("dbo.DataBreach");
            AlterColumn("dbo.DataBreach", "Texto", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.DataBreach", new[] { "FuenteId", "Texto" });
            AddForeignKey("dbo.DataBreach", "FuenteId", "dbo.Fuentes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DataBreach", "FuenteId", "dbo.Fuentes");
            DropPrimaryKey("dbo.DataBreach");
            AlterColumn("dbo.DataBreach", "Texto", c => c.String());
            AddPrimaryKey("dbo.DataBreach", "FuenteId");
            AddForeignKey("dbo.DataBreach", "FuenteId", "dbo.Fuentes", "Id");
        }
    }
}
