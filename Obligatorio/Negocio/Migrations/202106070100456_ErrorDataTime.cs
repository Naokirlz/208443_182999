namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorDataTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contrasenia", "FechaUltimaModificacion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contrasenia", "FechaUltimaModificacion", c => c.DateTime(nullable: false));
        }
    }
}
