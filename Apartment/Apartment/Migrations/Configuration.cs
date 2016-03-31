namespace Apartment.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApartmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApartmentContext context)
        {

            new List<UnitNumber>
            {
                new UnitNumber {Id = 1, Unit = "1A" },
                new UnitNumber {Id = 2, Unit = "1B" },
                new UnitNumber {Id = 3, Unit = "1C" },
                new UnitNumber {Id = 4, Unit = "1D" },
                new UnitNumber {Id = 5, Unit = "2A" },
                new UnitNumber {Id = 6, Unit = "2B" },
                new UnitNumber {Id = 7, Unit = "2C" },
                new UnitNumber {Id = 8, Unit = "2D" },
            }.ForEach(i => context.Units.AddOrUpdate(i));

            new List<Section>
            {
                new Section { Id = 1, Number = 333 },
                new Section { Id = 2, Number = 555 },
                new Section { Id = 3, Number = 691 },
                new Section { Id = 4, Number = 402 }
            }.ForEach(i => context.Sections.AddOrUpdate(i));

            new List<Street>
            {
                new Street {Id = 1, Name = "Python Ave" },
                new Street {Id = 2, Name = "Sea Sharp Street" },
                new Street {Id = 3, Name = "Javascript Court" },
                new Street {Id = 4, Name = "Totally Real Lane" }
            }.ForEach(i => context.Streets.AddOrUpdate(i));

            new List<PostalCode>
            {
                new PostalCode {Id = 1, Zip = "53202" }
            }.ForEach(i => context.ZipCodes.AddOrUpdate(i));

            new List<City>
            {
                new City {Id= 1, Name="Milwaukee" }
            }.ForEach(i => context.City.AddOrUpdate(i));

            new List<PetCost>
            {
                new PetCost {Id = 1, Name = "Pet Fee", Charge = 25M }
            }.ForEach(i => context.PetCosts.AddOrUpdate(i));

            new List<RoomCount>
            {
                new RoomCount {Id = 1, Count = 1 },
                new RoomCount {Id = 2, Count = 2 },
                new RoomCount {Id = 3, Count = 3 }
            }.ForEach(i => context.RoomCounts.AddOrUpdate(i));

            new List<BathCount>
            {
                new BathCount {Id = 1, Count = 1 },
                new BathCount {Id = 2, Count = 1.5 },
                new BathCount {Id = 3, Count = 2 }
            }.ForEach(i => context.BathCount.AddOrUpdate(i));

            new List<RentCost>
            {
                new RentCost {Id = 1, RentAmount = 800M },
                new RentCost {Id = 2, RentAmount = 900M },
                new RentCost {Id = 3, RentAmount = 1050M },
                new RentCost {Id = 4, RentAmount = 850M }

            }.ForEach(i => context.Costs.AddOrUpdate(i));

            new List<ApartmentAddress>
            {
                new ApartmentAddress { Id = 1, SectionId = 1, StreetId = 1, UnitNumberId = 1, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 1, BathCountId = 1, RentCostId = 1, Availability = true },
                new ApartmentAddress { Id = 2, SectionId = 1, StreetId = 1, UnitNumberId = 2, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 1, BathCountId = 1, RentCostId = 1, Availability = false, ResidentId = 1 },
                new ApartmentAddress { Id = 3, SectionId = 1, StreetId = 1, UnitNumberId = 3, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 1, RentCostId = 4, Availability = false, ResidentId = 2 },
                new ApartmentAddress { Id = 4, SectionId = 1, StreetId = 1, UnitNumberId = 4, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 1, RentCostId = 4, Availability = false, ResidentId = 3 },
                new ApartmentAddress { Id = 5, SectionId = 1, StreetId = 1, UnitNumberId = 5, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 2, RentCostId = 2, Availability = true },
                new ApartmentAddress { Id = 6, SectionId = 1, StreetId = 1, UnitNumberId = 6, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 2, RentCostId = 2, Availability = true },
                new ApartmentAddress { Id = 7, SectionId = 1, StreetId = 1, UnitNumberId = 7, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 3, BathCountId = 3, RentCostId = 3, Availability = false, ResidentId = 4 },
                new ApartmentAddress { Id = 8, SectionId = 1, StreetId = 1, UnitNumberId = 8, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 3, BathCountId = 3, RentCostId = 3, Availability = false, ResidentId = 5 },

                new ApartmentAddress { Id = 9, SectionId = 2, StreetId = 2, UnitNumberId = 1, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 1, BathCountId = 1, RentCostId = 1, Availability = true },
                new ApartmentAddress { Id = 10, SectionId = 2, StreetId = 2, UnitNumberId = 2, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 1, BathCountId = 1, RentCostId = 1, Availability = false, ResidentId = 6 },
                new ApartmentAddress { Id = 11, SectionId = 2, StreetId = 2, UnitNumberId = 3, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 1, RentCostId = 4, Availability = false, ResidentId = 7 },
                new ApartmentAddress { Id = 12, SectionId = 2, StreetId = 2, UnitNumberId = 4, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 1, RentCostId = 4, Availability = false, ResidentId = 8 },
                new ApartmentAddress { Id = 13, SectionId = 2, StreetId = 2, UnitNumberId = 5, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 2, RentCostId = 2, Availability = false, ResidentId = 9 },
                new ApartmentAddress { Id = 14, SectionId = 2, StreetId = 2, UnitNumberId = 6, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 2, RentCostId = 2, Availability = false, ResidentId = 10 },
                new ApartmentAddress { Id = 15, SectionId = 2, StreetId = 2, UnitNumberId = 7, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 3, BathCountId = 3, RentCostId = 3, Availability = true },
                new ApartmentAddress { Id = 16, SectionId = 2, StreetId = 2, UnitNumberId = 8, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 3, BathCountId = 3, RentCostId = 3, Availability = false, ResidentId = 11 },

                new ApartmentAddress { Id = 17, SectionId = 3, StreetId = 3, UnitNumberId = 1, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 1, BathCountId = 1, RentCostId = 1, Availability = false, ResidentId = 12 },
                new ApartmentAddress { Id = 18, SectionId = 3, StreetId = 3, UnitNumberId = 2, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 1, BathCountId = 1, RentCostId = 1, Availability = true },
                new ApartmentAddress { Id = 19, SectionId = 3, StreetId = 3, UnitNumberId = 3, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 1, RentCostId = 4, Availability = false, ResidentId = 13 },
                new ApartmentAddress { Id = 20, SectionId = 3, StreetId = 3, UnitNumberId = 4, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 1, RentCostId = 4, Availability = false, ResidentId = 14 },
                new ApartmentAddress { Id = 21, SectionId = 3, StreetId = 3, UnitNumberId = 5, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 2, RentCostId = 2, Availability = false, ResidentId = 15 },
                new ApartmentAddress { Id = 22, SectionId = 3, StreetId = 3, UnitNumberId = 6, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 2, RentCostId = 2, Availability = true },
                new ApartmentAddress { Id = 23, SectionId = 3, StreetId = 3, UnitNumberId = 7, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 3, BathCountId = 3, RentCostId = 3, Availability = false, ResidentId = 16 },
                new ApartmentAddress { Id = 24, SectionId = 3, StreetId = 3, UnitNumberId = 8, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 3, BathCountId = 3, RentCostId = 3, Availability = false, ResidentId = 17 },

                new ApartmentAddress { Id = 25, SectionId = 4, StreetId = 4, UnitNumberId = 1, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 1, BathCountId = 1, RentCostId = 1, Availability = false, ResidentId = 18 },
                new ApartmentAddress { Id = 26, SectionId = 4, StreetId = 4, UnitNumberId = 2, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 1, BathCountId = 1, RentCostId = 1, Availability = true },
                new ApartmentAddress { Id = 27, SectionId = 4, StreetId = 4, UnitNumberId = 3, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 1, RentCostId = 4, Availability = false, ResidentId = 19 },
                new ApartmentAddress { Id = 28, SectionId = 4, StreetId = 4, UnitNumberId = 4, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 1, RentCostId = 4, Availability = true },
                new ApartmentAddress { Id = 29, SectionId = 4, StreetId = 4, UnitNumberId = 5, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 2, RentCostId = 2, Availability = false, ResidentId = 20 },
                new ApartmentAddress { Id = 30, SectionId = 4, StreetId = 4, UnitNumberId = 6, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 2, BathCountId = 2, RentCostId = 2, Availability = false, ResidentId = 21 },
                new ApartmentAddress { Id = 31, SectionId = 4, StreetId = 4, UnitNumberId = 7, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 3, BathCountId = 3, RentCostId = 3, Availability = false, ResidentId = 22 },
                new ApartmentAddress { Id = 32, SectionId = 4, StreetId = 4, UnitNumberId = 8, CityId = 1, State = States.Wisconsin, PostalCodeId = 1, RoomCountId = 3, BathCountId = 3, RentCostId = 3, Availability = true }

            }.ForEach(i => context.Addresses.AddOrUpdate(i));

            new List<Resident>
            {
                new Resident { Id = 1, FirstName = "Rickey", LastName = "Pratt", PhoneNumber = "414-599-6933", Email = "FestiveFang@gmail.com", HasPets = false, petCount = 0,       PetCostId = 1},
                new Resident { Id = 2, FirstName = "Gilberto", LastName = "Ellis", PhoneNumber = "414-430-9530	", Email = "FourSheer@gmail.com", HasPets = false, petCount = 0,     PetCostId = 1 },
                new Resident { Id = 3, FirstName = "Kerry", LastName = "Holt", PhoneNumber = "414-788-1285", Email = "FunnyLuda@gmail.com", HasPets = false, petCount = 0,           PetCostId = 1 },
                new Resident { Id = 4, FirstName = "Claudia", LastName = "Christensen", PhoneNumber = "414-483-4034", Email = "Gabicspo@gmail.com", HasPets = true, petCount = 1,    PetCostId = 1 },
                new Resident { Id = 5, FirstName = "Mindy", LastName = "Stevenson", PhoneNumber = "414-751-0317", Email = "GorgeousTricked@gmail.com", HasPets = true, petCount = 3, PetCostId = 1 },
                new Resident { Id = 6, FirstName = "Lorena", LastName = "Greer", PhoneNumber = "414-499-6740", Email = "HelloBigg@gmail.com", HasPets = true, petCount = 1,           PetCostId = 1 },
                new Resident { Id = 7, FirstName = "Jeanette", LastName = "Ortega", PhoneNumber = "414-727-1076", Email = "Hincharak@gmail.com", HasPets = true, petCount = 1,        PetCostId = 1 },
                new Resident { Id = 8, FirstName = "Fredrick", LastName = "Parks", PhoneNumber = "414-741-7065", Email = "HockeyWithpain@gmail.com", HasPets = false, petCount = 0,   PetCostId = 1 },
                new Resident { Id = 9, FirstName = "Shannon", LastName = "Stanley", PhoneNumber = "414-984-7329", Email = "Holdarsk@gmail.com", HasPets = true, petCount = 3, PetCostId = 1 },

                new Resident { Id = 10, FirstName = "Willie", LastName = "Crawford", PhoneNumber = "414-196-8099", Email = "IonAquatic@gmail.com", HasPets = true, petCount = 2, AddressId = 14, PetCostId = 1 },
                new Resident { Id = 11, FirstName = "Kathryn", LastName = "Crawford", PhoneNumber = "414-661-3527", Email = "HottGlimmer@gmail.com", HasPets = true, petCount = 2, AddressId = 16, PetCostId = 1 },
                new Resident { Id = 12, FirstName = "Tyler", LastName = "Pierce", PhoneNumber = "414-645-7801", Email = "IwantNarrative@gmail.com", HasPets = true, petCount = 1, AddressId = 17, PetCostId = 1 },
                new Resident { Id = 13, FirstName = "Kent", LastName = "Lyons", PhoneNumber = "414-922-4828", Email = "JuzInspiring@gmail.com", HasPets = true, petCount = 1, AddressId = 19, PetCostId = 1 },
                new Resident { Id = 14, FirstName = "Natasha", LastName = "Morrison", PhoneNumber = "414-997-6979", Email = "Kaiseizer@gmail.com", HasPets = true, petCount = 2, AddressId = 20, PetCostId = 1 },
                new Resident { Id = 15, FirstName = "Glenn", LastName = "Keller", PhoneNumber = "414-983-2854", Email = "Kennearch@gmail.com", HasPets = true, petCount = 3, AddressId = 21, PetCostId = 1 },
                new Resident { Id = 16, FirstName = "Lula", LastName = "Riley", PhoneNumber = "414-903-3721", Email = "KixSteen@gmail.com", HasPets = false, petCount = 0, AddressId = 23, PetCostId = 1 },
                new Resident { Id = 17, FirstName = "Antoinette", LastName = "Saunders", PhoneNumber = "414-181-9303", Email = "Kooliohexa@gmail.com", HasPets = true, petCount = 3, AddressId = 24, PetCostId = 1 },
                new Resident { Id = 18, FirstName = "Chester", LastName = "Harris", PhoneNumber = "414-614-1502", Email = "KoolLatest@gmail.com", HasPets = false, petCount = 0, AddressId = 25, PetCostId = 1 },
                new Resident { Id = 19, FirstName = "Rudolph", LastName = "Cummings", PhoneNumber = "414-609-4919", Email = "LatestFaith@gmail.com", HasPets = false, petCount = 0, AddressId = 27, PetCostId = 1 },
                new Resident { Id = 20, FirstName = "Aubrey", LastName = "Floyd", PhoneNumber = "414-991-6891", Email = "Ledgerskul@gmail.com", HasPets = false, petCount = 0, AddressId = 29, PetCostId = 1 },
                new Resident { Id = 21, FirstName = "Ginger", LastName = "Maxwell", PhoneNumber = "414-665-0255", Email = "Letdotabl@gmail.com", HasPets = true, petCount = 3, AddressId = 30, PetCostId = 1 },
                new Resident { Id = 22, FirstName = "Jimmy", LastName = "Ward", PhoneNumber = "414-944-2456", Email = "LexLeventis@gmail.com", HasPets = false, petCount = 0, AddressId = 31, PetCostId = 1 }
            }.ForEach(i => context.Residents.AddOrUpdate(i));
        }
    }
}
