namespace Web2ProjekatBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Opremachange2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opremas", "CoordinateX", c => c.Double(nullable: false));
            AddColumn("dbo.Opremas", "CoordinateY", c => c.Double(nullable: false));
            DropColumn("dbo.Opremas", "Coordinates");
            DropColumn("dbo.Opremas", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Opremas", "Address", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Opremas", "Coordinates", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Opremas", "CoordinateY");
            DropColumn("dbo.Opremas", "CoordinateX");
        }
    }
}
