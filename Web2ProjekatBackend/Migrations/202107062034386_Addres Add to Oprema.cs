namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddresAddtoOprema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opremas", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Opremas", "Address");
        }
    }
}
