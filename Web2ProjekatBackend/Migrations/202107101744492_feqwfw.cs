namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feqwfw : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nalozi", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Planovi", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.SafetyDocuments", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Nalozi", "NalogType");
            DropColumn("dbo.Planovi", "DocumentType");
            DropColumn("dbo.SafetyDocuments", "SafetyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SafetyDocuments", "SafetyType", c => c.Int(nullable: false));
            AddColumn("dbo.Planovi", "DocumentType", c => c.Int(nullable: false));
            AddColumn("dbo.Nalozi", "NalogType", c => c.Int(nullable: false));
            DropColumn("dbo.SafetyDocuments", "Type");
            DropColumn("dbo.Planovi", "Type");
            DropColumn("dbo.Nalozi", "Type");
        }
    }
}
