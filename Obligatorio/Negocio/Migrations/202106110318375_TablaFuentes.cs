﻿namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaFuentes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fuentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fuentes");
        }
    }
}
