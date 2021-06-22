namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptiontoINcidents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "Description", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incidents", "Description");
        }
    }
}
