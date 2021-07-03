namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewOne2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserInfo", "IsAdminApproved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfo", "IsAdminApproved", c => c.Boolean(nullable: false));
        }
    }
}
