namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminapprove : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfo", "IsAdminApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfo", "IsAdminApproved");
        }
    }
}
