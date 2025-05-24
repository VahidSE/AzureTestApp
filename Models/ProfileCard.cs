namespace AzureTestApp.Models
{
    public class ProfileCard
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string ServiceOffering { get; set; } = "";
    }

    public class Tile
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }

    public class CatTile
    {
        public List<Tile> InstallationOrRepairServiceTiles { get; set; } = new List<Tile>();
       public List<Tile> HouseServicesTiles { get; set; } = new List<Tile>();
        public List<Tile> TravelServiceTiles { get; set; } = new List<Tile>();
        public List<Tile> FinanceServiceTiles { get; set; } = new List<Tile>();
        public List<Tile> EduServiceTiles { get; set; } = new List<Tile>();
        public List<Tile> WedFuncServiceTiles { get; set; } = new List<Tile>();
        public List<Tile> SoftwareServiceTiles { get; set; } = new List<Tile>();
        public List<Tile> WellbeingServiceTiles { get; set; } = new List<Tile>();
        public List<Tile> HospitalServiceTiles { get; set; } = new List<Tile>();
        public List<Tile> OtherServiceTiles { get; set; } = new List<Tile>();

    }

}
