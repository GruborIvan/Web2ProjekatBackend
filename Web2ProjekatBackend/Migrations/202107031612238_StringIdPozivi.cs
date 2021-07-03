namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringIdPozivi : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Pozivi");
            AlterColumn("dbo.Pozivi", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pozivi", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Pozivi");
            AlterColumn("dbo.Pozivi", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Pozivi", "Id");
        }
    }
}
