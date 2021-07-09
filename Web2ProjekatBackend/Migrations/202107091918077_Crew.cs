namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Crew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ekipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazivEkipe = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Incidents", "EkipaId", c => c.Int(nullable: false));
            AddColumn("dbo.UserInfo", "EkipaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfo", "EkipaId");
            DropColumn("dbo.Incidents", "EkipaId");
            DropTable("dbo.Ekipe");
        }
    }
}
