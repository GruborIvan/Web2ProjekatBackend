namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeResolutions : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Resolutions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        IdRes = c.Int(nullable: false, identity: true),
                        Cause = c.String(nullable: false),
                        SubCause = c.String(nullable: false),
                        Construction = c.String(nullable: false),
                        Material = c.String(nullable: false),
                        IncidentId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdRes);
            
        }
    }
}
