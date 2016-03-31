namespace Apartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertToPrevCommit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WhyApplieds", "Other", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WhyApplieds", "Other");
        }
    }
}
