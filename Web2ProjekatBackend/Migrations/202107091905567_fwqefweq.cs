namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fwqefweq : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Ekipe");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ekipe",
                c => new
                    {
                        IdEkipe = c.String(nullable: false, maxLength: 128),
                        NazivEkipe = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdEkipe);
            
        }
    }
}
