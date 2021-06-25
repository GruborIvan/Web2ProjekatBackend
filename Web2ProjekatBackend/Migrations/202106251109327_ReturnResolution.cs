namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturnResolution : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cause = c.String(nullable: false),
                        SubCause = c.String(nullable: false),
                        Construction = c.String(nullable: false),
                        Material = c.String(nullable: false),
                        IncidentId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Resolutions");
        }
    }
}
