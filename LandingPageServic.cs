using AzureTestApp.Models;

namespace AzureTestApp
{
    public class LandingPageServic
    {
        //Id, Service Catageory, Status
        //Id, Service, Description, SerCatId, SerIcon, Status
        public CatTile GetAllServices()
        {
            CatTile catTiles = new CatTile();
            //Installation and Repair services
            //AC installation/repair, Washing machine repair, Watches or Clocks repair, Mobile or Laptop repair, Bike or Car repair
            catTiles.InstallationOrRepairServiceTiles.Add(new Tile() { Title = "AC installation or service", Description = "Chill in the room", Link = "/services/1" });
            catTiles.InstallationOrRepairServiceTiles.Add(new Tile() { Title = "Washing machine", Description = "I will wash for you", Link = "/services/2" });
            catTiles.InstallationOrRepairServiceTiles.Add(new Tile() { Title = "Watches or Cloeck repair", Description = "Look at me", Link = "/services/3" });
            catTiles.InstallationOrRepairServiceTiles.Add(new Tile() { Title = "Mobile or Laptop technicians", Description = "I am your daily companion", Link = "/services/4" });
            catTiles.InstallationOrRepairServiceTiles.Add(new Tile() { Title = "Bike or Car Service", Description = "Let's go for a ride", Link = "/services/5" });


            //House services
            //Tailor, Gas, Water, Maid, Electrician, Plumber, Carpenter, Construction, Inverters or batteries, Welding shop 
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "Tailor", Description = "Get your clothes stricthes", Link = "/services/6" });
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "GAS", Description = "Call and let the dishes run", Link = "/services/7" });
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "Water", Description = "we got your back", Link = "/services/8" });
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "Maid", Description = "Let me take care", Link = "/services/9" });
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "Electrition", Description = "Let me light-up surroundings", Link = "/services/10" });
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "Plumber", Description = "Let me fix leakages", Link = "/services/11" });
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "Carpenter", Description = "Let me design beds, doors, chairs", Link = "/services/12" });
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "Construction", Description = "I have great construction ideas", Link = "/services/13" });
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "Batteries or Inverters", Description = "I am a power house", Link = "/services/14" });
            catTiles.HouseServicesTiles.Add(new Tile() { Title = "Iron shop or welding", Description = "Let me melt", Link = "/services/15" });

            //Travel services
            //Auto, Car, Trucks and Courier
            catTiles.TravelServiceTiles.Add(new Tile() { Title = "Drivers", Description = "I have auto, cab, trucks", Link = "/services/16" });
            catTiles.TravelServiceTiles.Add(new Tile() { Title = "Courier", Description = "Give me your package", Link = "/services/17" });

            //Financial services
            //Accounts
            catTiles.FinanceServiceTiles.Add(new Tile() { Title = "Accounts Services", Description = "Can I calculate?", Link = "/services/18" });

            //Educational services
            //Tution or Coaching Center
            catTiles.EduServiceTiles.Add(new Tile() { Title = "Tutions", Description = "Learn from experts", Link = "/services/19" });
            catTiles.EduServiceTiles.Add(new Tile() { Title = "Coaching Center", Description = "Learn something new", Link = "/services/20" });

            //Wedding services or functions
            //Event Management, Chef, Photo grapher and video editor
            catTiles.WedFuncServiceTiles.Add(new Tile() { Title = "Event Management", Description = "People will be in wow feeling", Link = "/services/21" });
            catTiles.WedFuncServiceTiles.Add(new Tile() { Title = "Chef", Description = "Delicious!", Link = "/services/22" });
            catTiles.WedFuncServiceTiles.Add(new Tile() { Title = "Wedding Services", Description = "I will organise", Link = "/services/23" });
            catTiles.WedFuncServiceTiles.Add(new Tile() { Title = "Video editors", Description = "Memories stay!", Link = "/services/24" });

            //Software services
            //Website designers, developers
            catTiles.SoftwareServiceTiles.Add(new Tile() { Title = "Website developer", Description = "Run your business", Link = "/services/25" });

            //Wellbeing services
            //Gym, SPA
            catTiles.WellbeingServiceTiles.Add(new Tile() { Title = "SPA", Description = "Take care of your body", Link = "/services/26" });
            catTiles.WellbeingServiceTiles.Add(new Tile() { Title = "Gym", Description = "Get into a shape", Link = "/services/27" });

            //Hospital services
            //Clinic, Diagnostic centers, Meditation
            catTiles.HospitalServiceTiles.Add(new Tile() { Title = "Clinic or Diagnostic center", Description = "Health is wealth", Link = "/services/28" });

            //Others
            //Aggrriculture, Xerox, ISP, Jwellery, etc
            catTiles.OtherServiceTiles.Add(new Tile() { Title = "Agriculture", Description = "Corps and farmers are backbone", Link = "/services/29" });
            catTiles.OtherServiceTiles.Add(new Tile() { Title = "Xerox", Description = "I have your copy", Link = "/services/30" });
            catTiles.OtherServiceTiles.Add(new Tile() { Title = "Internet Provider", Description = "Connect with world", Link = "/services/31" });
            catTiles.OtherServiceTiles.Add(new Tile() { Title = "Jewellery", Description = "Let's get catch attention", Link = "/services/32" });
            return catTiles;
        }
    }
}
