namespace Apartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResidentApartmentViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApartmentAddress_Id = c.Int(),
                        Resident_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApartmentAddresses", t => t.ApartmentAddress_Id)
                .ForeignKey("dbo.Residents", t => t.Resident_Id)
                .Index(t => t.ApartmentAddress_Id)
                .Index(t => t.Resident_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResidentApartmentViewModels", "Resident_Id", "dbo.Residents");
            DropForeignKey("dbo.ResidentApartmentViewModels", "ApartmentAddress_Id", "dbo.ApartmentAddresses");
            DropIndex("dbo.ResidentApartmentViewModels", new[] { "Resident_Id" });
            DropIndex("dbo.ResidentApartmentViewModels", new[] { "ApartmentAddress_Id" });
            DropTable("dbo.ResidentApartmentViewModels");
        }
    }
}
