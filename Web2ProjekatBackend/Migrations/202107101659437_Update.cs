namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrioAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        address = c.String(nullable: false, maxLength: 255),
                        prio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PrioAddress");
        }
    }
}
