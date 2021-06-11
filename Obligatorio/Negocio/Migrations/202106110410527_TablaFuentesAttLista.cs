namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaFuentesAttLista : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fuentes", "ListString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fuentes", "ListString");
        }
    }
}
