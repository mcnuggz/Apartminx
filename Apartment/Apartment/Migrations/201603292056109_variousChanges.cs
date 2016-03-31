namespace Apartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class variousChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApartmentAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        StreetId = c.Int(nullable: false),
                        UnitNumberId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        PostalCodeId = c.Int(nullable: false),
                        RoomCountId = c.Int(nullable: false),
                        BathCountId = c.Int(nullable: false),
                        RentCostId = c.Int(),
                        Availability = c.Boolean(nullable: false),
                        ResidentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BathCounts", t => t.BathCountId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.PostalCodes", t => t.PostalCodeId, cascadeDelete: true)
                .ForeignKey("dbo.RentCosts", t => t.RentCostId)
                .ForeignKey("dbo.RoomCounts", t => t.RoomCountId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .ForeignKey("dbo.Streets", t => t.StreetId, cascadeDelete: true)
                .ForeignKey("dbo.UnitNumbers", t => t.UnitNumberId, cascadeDelete: true)
                .Index(t => t.SectionId)
                .Index(t => t.StreetId)
                .Index(t => t.UnitNumberId)
                .Index(t => t.CityId)
                .Index(t => t.PostalCodeId)
                .Index(t => t.RoomCountId)
                .Index(t => t.BathCountId)
                .Index(t => t.RentCostId);
            
            CreateTable(
                "dbo.BathCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostalCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentCosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Residents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        HasPets = c.Boolean(nullable: false),
                        petCount = c.Int(),
                        AddressId = c.Int(),
                        PetCostId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetCosts", t => t.PetCostId)
                .Index(t => t.PetCostId);
            
            CreateTable(
                "dbo.PetCosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Charge = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnitNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TenantInformationId = c.Int(nullable: false),
                        WorkHistoryId = c.Int(nullable: false),
                        CreditHistoryId = c.Int(nullable: false),
                        CriminalHistoryId = c.Int(nullable: false),
                        SpouseId = c.Int(nullable: false),
                        OtherOccupantsId = c.Int(nullable: false),
                        VehiclesId = c.Int(nullable: false),
                        WhyAppliedId = c.Int(nullable: false),
                        EmergencyContactId = c.Int(nullable: false),
                        AuthorizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authorizations", t => t.AuthorizationId, cascadeDelete: true)
                .ForeignKey("dbo.Cases", t => t.Id)
                .ForeignKey("dbo.CreditHistories", t => t.CreditHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.CriminalHistories", t => t.CriminalHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.EmergencyContacts", t => t.EmergencyContactId, cascadeDelete: true)
                .ForeignKey("dbo.OtherOccupants", t => t.OtherOccupantsId, cascadeDelete: true)
                .ForeignKey("dbo.Spouses", t => t.SpouseId, cascadeDelete: true)
                .ForeignKey("dbo.TenantInformations", t => t.TenantInformationId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehiclesId, cascadeDelete: true)
                .ForeignKey("dbo.WhyApplieds", t => t.WhyAppliedId, cascadeDelete: true)
                .ForeignKey("dbo.WorkHistories", t => t.WorkHistoryId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TenantInformationId)
                .Index(t => t.WorkHistoryId)
                .Index(t => t.CreditHistoryId)
                .Index(t => t.CriminalHistoryId)
                .Index(t => t.SpouseId)
                .Index(t => t.OtherOccupantsId)
                .Index(t => t.VehiclesId)
                .Index(t => t.WhyAppliedId)
                .Index(t => t.EmergencyContactId)
                .Index(t => t.AuthorizationId);
            
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        AcceptTerms = c.Boolean(nullable: false),
                        ESignature = c.String(nullable: false),
                        SpouseSignature = c.String(),
                        AdditionalComments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        ApplicationFilled = c.Boolean(nullable: false),
                        BackgroundStatus = c.Boolean(nullable: false),
                        CreditReportStatus = c.Boolean(nullable: false),
                        LeaseSigned = c.Boolean(nullable: false),
                        LeasePath = c.String(),
                        Status = c.Int(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreditHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankName = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        SocialSecurity = c.String(),
                        OtherComments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CriminalHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Evicted = c.Boolean(nullable: false),
                        EarlyMoveOut = c.Boolean(nullable: false),
                        Bankrupt = c.Boolean(nullable: false),
                        SuedForRent = c.Boolean(nullable: false),
                        SuedForDamage = c.Boolean(nullable: false),
                        RegisteredSexOffender = c.Boolean(nullable: false),
                        ArrestedForViolence = c.Boolean(nullable: false),
                        ArrestedForFelony = c.Boolean(nullable: false),
                        ArrestInformation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmergencyContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Relationship = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Name2 = c.String(),
                        Relationship2 = c.String(),
                        Phone2 = c.String(),
                        Name3 = c.String(),
                        Relationship3 = c.String(),
                        Phone3 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OtherOccupants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Relationship = c.String(),
                        Gender = c.Int(nullable: false),
                        Birthdate = c.String(),
                        IDNum = c.String(),
                        State = c.Int(nullable: false),
                        Name2 = c.String(),
                        Relationship2 = c.String(),
                        Gender2 = c.Int(nullable: false),
                        Birthdate2 = c.String(),
                        IDNum2 = c.String(),
                        State2 = c.Int(nullable: false),
                        Name3 = c.String(),
                        Relationship3 = c.String(),
                        Gender3 = c.Int(nullable: false),
                        Birthdate3 = c.String(),
                        IDNum3 = c.String(),
                        State3 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Spouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMarried = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        FormerNames = c.String(),
                        SpouseSecurity = c.String(),
                        SpouseDriverLicense = c.String(),
                        State = c.Int(nullable: false),
                        GovtId = c.String(),
                        Birthdate = c.String(),
                        Height = c.Int(),
                        Weight = c.Int(),
                        Gender = c.Int(nullable: false),
                        EyeColor = c.String(),
                        USCitizen = c.Boolean(nullable: false),
                        SpouseEmployed = c.Boolean(nullable: false),
                        Employer = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        WorkState = c.Int(nullable: false),
                        Zip = c.String(),
                        WorkPhone = c.String(),
                        Position = c.String(),
                        StartDate = c.String(),
                        GrossIncome = c.Decimal(precision: 18, scale: 2),
                        SupervisorName = c.String(),
                        SupervisorPhone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TenantInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        StreetAddress = c.String(),
                        DriversLicense = c.String(),
                        State = c.Int(nullable: false),
                        GovtIDCard = c.String(),
                        SocialSecurity = c.String(),
                        BirthDate = c.String(),
                        Height = c.String(),
                        Weight = c.Int(),
                        Gender = c.Int(nullable: false),
                        EyeColor = c.String(),
                        MartialStatus = c.Int(nullable: false),
                        IsCitizen = c.Boolean(nullable: false),
                        DoesSmoke = c.Boolean(nullable: false),
                        HasPet = c.Boolean(nullable: false),
                        PetDescription = c.String(),
                        CurrentAddress = c.String(),
                        CurrentCity = c.String(),
                        CurrentState = c.Int(nullable: false),
                        CurrentZip = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        RentCurrentAddress = c.Boolean(nullable: false),
                        ApartmentName = c.String(),
                        AptManagerName = c.String(),
                        AptManagerPhone = c.String(),
                        CurrentRent = c.Decimal(precision: 18, scale: 2),
                        MovedInDate = c.String(),
                        MoveOutReason = c.String(),
                        PreviousAddress = c.String(),
                        PreviousCity = c.String(),
                        PreviousState = c.Int(nullable: false),
                        PreviousZip = c.String(),
                        RentPrevious = c.Boolean(nullable: false),
                        PreviousAptName = c.String(),
                        PreviousAptManager = c.String(),
                        PreviousAptPhone = c.String(),
                        PreviousRent = c.Decimal(precision: 18, scale: 2),
                        DateMovedIn = c.String(),
                        DateMovedOut = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehilceDescription = c.String(),
                        Year = c.Int(),
                        LicenseNum = c.String(),
                        State = c.Int(nullable: false),
                        VehilceDescription2 = c.String(),
                        Year2 = c.Int(),
                        LicenseNum2 = c.String(),
                        State2 = c.Int(nullable: false),
                        VehilceDescription3 = c.String(),
                        Year3 = c.Int(),
                        LicenseNum3 = c.String(),
                        State3 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WhyApplieds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WasReferred = c.Boolean(nullable: false),
                        RentalAgency = c.String(),
                        LocalAgency = c.String(),
                        OtherPerson = c.String(),
                        NoReferral = c.Boolean(nullable: false),
                        OnInternet = c.Boolean(nullable: false),
                        StoppedBy = c.Boolean(nullable: false),
                        Newspaper = c.Boolean(nullable: false),
                        NewspaperName = c.String(),
                        RentalPublication = c.Boolean(nullable: false),
                        PublicaitonName = c.String(),
                        Other = c.Boolean(nullable: false),
                        OtherDetails = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PresentlyEmployed = c.Boolean(nullable: false),
                        Employer = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        ZipCode = c.String(),
                        WorkPhone = c.String(),
                        Position = c.String(),
                        GrossIncome = c.Decimal(precision: 18, scale: 2),
                        BeginDate = c.String(),
                        SupervisorName = c.String(),
                        SupervisorNumber = c.String(),
                        PreviouslyEmployed = c.Boolean(nullable: false),
                        PreviousEmployer = c.String(),
                        PrevAddress = c.String(),
                        PrevCity = c.String(),
                        PrevState = c.Int(nullable: false),
                        PrevZip = c.String(),
                        PrevWorkPhone = c.String(),
                        PrevPosition = c.String(),
                        PrevIncome = c.Decimal(precision: 18, scale: 2),
                        PrevStartDate = c.String(),
                        PrevEndDate = c.String(),
                        PrevSupervisor = c.String(),
                        PrevPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResidentApartmentAddresses",
                c => new
                    {
                        Resident_Id = c.Int(nullable: false),
                        ApartmentAddress_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resident_Id, t.ApartmentAddress_Id })
                .ForeignKey("dbo.Residents", t => t.Resident_Id, cascadeDelete: true)
                .ForeignKey("dbo.ApartmentAddresses", t => t.ApartmentAddress_Id, cascadeDelete: true)
                .Index(t => t.Resident_Id)
                .Index(t => t.ApartmentAddress_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applicants", "WorkHistoryId", "dbo.WorkHistories");
            DropForeignKey("dbo.Applicants", "WhyAppliedId", "dbo.WhyApplieds");
            DropForeignKey("dbo.Applicants", "VehiclesId", "dbo.Vehicles");
            DropForeignKey("dbo.Applicants", "TenantInformationId", "dbo.TenantInformations");
            DropForeignKey("dbo.Applicants", "SpouseId", "dbo.Spouses");
            DropForeignKey("dbo.Applicants", "OtherOccupantsId", "dbo.OtherOccupants");
            DropForeignKey("dbo.Applicants", "EmergencyContactId", "dbo.EmergencyContacts");
            DropForeignKey("dbo.Applicants", "CriminalHistoryId", "dbo.CriminalHistories");
            DropForeignKey("dbo.Applicants", "CreditHistoryId", "dbo.CreditHistories");
            DropForeignKey("dbo.Applicants", "Id", "dbo.Cases");
            DropForeignKey("dbo.Applicants", "AuthorizationId", "dbo.Authorizations");
            DropForeignKey("dbo.ApartmentAddresses", "UnitNumberId", "dbo.UnitNumbers");
            DropForeignKey("dbo.ApartmentAddresses", "StreetId", "dbo.Streets");
            DropForeignKey("dbo.ApartmentAddresses", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.ApartmentAddresses", "RoomCountId", "dbo.RoomCounts");
            DropForeignKey("dbo.Residents", "PetCostId", "dbo.PetCosts");
            DropForeignKey("dbo.ResidentApartmentAddresses", "ApartmentAddress_Id", "dbo.ApartmentAddresses");
            DropForeignKey("dbo.ResidentApartmentAddresses", "Resident_Id", "dbo.Residents");
            DropForeignKey("dbo.ApartmentAddresses", "RentCostId", "dbo.RentCosts");
            DropForeignKey("dbo.ApartmentAddresses", "PostalCodeId", "dbo.PostalCodes");
            DropForeignKey("dbo.ApartmentAddresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.ApartmentAddresses", "BathCountId", "dbo.BathCounts");
            DropIndex("dbo.ResidentApartmentAddresses", new[] { "ApartmentAddress_Id" });
            DropIndex("dbo.ResidentApartmentAddresses", new[] { "Resident_Id" });
            DropIndex("dbo.Applicants", new[] { "AuthorizationId" });
            DropIndex("dbo.Applicants", new[] { "EmergencyContactId" });
            DropIndex("dbo.Applicants", new[] { "WhyAppliedId" });
            DropIndex("dbo.Applicants", new[] { "VehiclesId" });
            DropIndex("dbo.Applicants", new[] { "OtherOccupantsId" });
            DropIndex("dbo.Applicants", new[] { "SpouseId" });
            DropIndex("dbo.Applicants", new[] { "CriminalHistoryId" });
            DropIndex("dbo.Applicants", new[] { "CreditHistoryId" });
            DropIndex("dbo.Applicants", new[] { "WorkHistoryId" });
            DropIndex("dbo.Applicants", new[] { "TenantInformationId" });
            DropIndex("dbo.Applicants", new[] { "Id" });
            DropIndex("dbo.Residents", new[] { "PetCostId" });
            DropIndex("dbo.ApartmentAddresses", new[] { "RentCostId" });
            DropIndex("dbo.ApartmentAddresses", new[] { "BathCountId" });
            DropIndex("dbo.ApartmentAddresses", new[] { "RoomCountId" });
            DropIndex("dbo.ApartmentAddresses", new[] { "PostalCodeId" });
            DropIndex("dbo.ApartmentAddresses", new[] { "CityId" });
            DropIndex("dbo.ApartmentAddresses", new[] { "UnitNumberId" });
            DropIndex("dbo.ApartmentAddresses", new[] { "StreetId" });
            DropIndex("dbo.ApartmentAddresses", new[] { "SectionId" });
            DropTable("dbo.ResidentApartmentAddresses");
            DropTable("dbo.WorkHistories");
            DropTable("dbo.WhyApplieds");
            DropTable("dbo.Vehicles");
            DropTable("dbo.TenantInformations");
            DropTable("dbo.Spouses");
            DropTable("dbo.OtherOccupants");
            DropTable("dbo.EmergencyContacts");
            DropTable("dbo.CriminalHistories");
            DropTable("dbo.CreditHistories");
            DropTable("dbo.Cases");
            DropTable("dbo.Authorizations");
            DropTable("dbo.Applicants");
            DropTable("dbo.UnitNumbers");
            DropTable("dbo.Streets");
            DropTable("dbo.Sections");
            DropTable("dbo.RoomCounts");
            DropTable("dbo.PetCosts");
            DropTable("dbo.Residents");
            DropTable("dbo.RentCosts");
            DropTable("dbo.PostalCodes");
            DropTable("dbo.Cities");
            DropTable("dbo.BathCounts");
            DropTable("dbo.ApartmentAddresses");
        }
    }
}
