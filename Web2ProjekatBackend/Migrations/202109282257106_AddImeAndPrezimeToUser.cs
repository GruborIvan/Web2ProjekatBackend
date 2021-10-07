namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImeAndPrezimeToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfo", "Ime", c => c.String());
            AddColumn("dbo.UserInfo", "Prezime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfo", "Prezime");
            DropColumn("dbo.UserInfo", "Ime");
        }
    }
}
