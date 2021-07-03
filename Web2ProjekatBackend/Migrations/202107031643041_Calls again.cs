namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Callsagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pozivi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Razlog = c.String(nullable: false, maxLength: 255),
                        Komentar = c.String(nullable: false, maxLength: 255),
                        Kvar = c.String(nullable: false, maxLength: 255),
                        UsernameKor = c.String(maxLength: 255),
                        IncidentId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pozivi");
        }
    }
}
