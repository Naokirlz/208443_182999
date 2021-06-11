namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaDataBreaches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataBreach",
                c => new
                    {
                        FuenteId = c.Int(nullable: false),
                        Texto = c.String(),
                    })
                .PrimaryKey(t => t.FuenteId)
                .ForeignKey("dbo.Fuentes", t => t.FuenteId)
                .Index(t => t.FuenteId);
            
            DropColumn("dbo.Fuentes", "ListString");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fuentes", "ListString", c => c.String());
            DropForeignKey("dbo.DataBreach", "FuenteId", "dbo.Fuentes");
            DropIndex("dbo.DataBreach", new[] { "FuenteId" });
            DropTable("dbo.DataBreach");
        }
    }
}
