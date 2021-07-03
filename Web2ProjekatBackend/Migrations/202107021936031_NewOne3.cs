namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewOne3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfo", "IsAdminApproved", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfo", "IsAdminApproved");
        }
    }
}
