namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Izmenapotrosaca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Potrosaci", "IdEkipe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Potrosaci", "IdEkipe");
        }
    }
}
