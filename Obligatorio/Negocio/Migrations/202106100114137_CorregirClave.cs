namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorregirClave : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Password", "Clave", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Password", "Clave", c => c.String());
        }
    }
}
