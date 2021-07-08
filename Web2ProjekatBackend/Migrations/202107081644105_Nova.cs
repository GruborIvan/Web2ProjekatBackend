namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nova : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Poruke", "Tip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Poruke", "Tip", c => c.String(nullable: false));
        }
    }
}
