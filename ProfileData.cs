using AzureTestApp.Models;

namespace AzureTestApp
{
    public class ProfileData
    {
        public List<ProfileCard> GetCards()
        { 
            List<ProfileCard> profileCards = new List<ProfileCard>();
            profileCards.Add(new ProfileCard() { Id = 1, Name = "ABC", Description = "Nothing", PhoneNumber = "9876543210", ServiceOffering = "2" });
            profileCards.Add(new ProfileCard() { Id = 2, Name = "ABC", Description = "Nothing", PhoneNumber = "9876543210", ServiceOffering = "3" });
            profileCards.Add(new ProfileCard() { Id = 3, Name = "ABC", Description = "Nothing", PhoneNumber = "9876543210", ServiceOffering = "4" });
            profileCards.Add(new ProfileCard() { Id = 4, Name = "ABC", Description = "Nothing", PhoneNumber = "9876543210", ServiceOffering = "5" });
            profileCards.Add(new ProfileCard() { Id = 5, Name = "ABC", Description = "Nothing", PhoneNumber = "9876543210", ServiceOffering = "7" });
            profileCards.Add(new ProfileCard() { Id = 6, Name = "ABC", Description = "Nothing", PhoneNumber = "9876543210", ServiceOffering = "8" });
            profileCards.Add(new ProfileCard() { Id = 7, Name = "ABC", Description = "Nothing", PhoneNumber = "9876543210", ServiceOffering = "9" });
            profileCards.Add(new ProfileCard() { Id = 8, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "11" });
            profileCards.Add(new ProfileCard() { Id = 9, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "12" });
            profileCards.Add(new ProfileCard() { Id = 10, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "13" });
            profileCards.Add(new ProfileCard() { Id = 11, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "14" });
            profileCards.Add(new ProfileCard() { Id = 12, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "15" });
            profileCards.Add(new ProfileCard() { Id = 13, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "16" });
            profileCards.Add(new ProfileCard() { Id = 14, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "17" });
            profileCards.Add(new ProfileCard() { Id = 15, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "21" });
            profileCards.Add(new ProfileCard() { Id = 16, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "22" });
            profileCards.Add(new ProfileCard() { Id = 17, Name = "BCD", Description = "Something", PhoneNumber = "9876543210", ServiceOffering = "23" });
            profileCards.Add(new ProfileCard() { Id = 18, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "24" });
            profileCards.Add(new ProfileCard() { Id = 19, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "25" });
            profileCards.Add(new ProfileCard() { Id = 20, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "26" });
            profileCards.Add(new ProfileCard() { Id = 21, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "27" });
            profileCards.Add(new ProfileCard() { Id = 22, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "28" });
            profileCards.Add(new ProfileCard() { Id = 23, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "29" });
            profileCards.Add(new ProfileCard() { Id = 24, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "30" });
            profileCards.Add(new ProfileCard() { Id = 25, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "31" });
            profileCards.Add(new ProfileCard() { Id = 26, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "32" });
            profileCards.Add(new ProfileCard() { Id = 27, Name = "XYZ", Description = "Everything", PhoneNumber = "9876543210", ServiceOffering = "18" });

            return profileCards;
        }

        public Dictionary<string, Dictionary<string, string>> GetDropDownValues()
        {
            Dictionary<string, Dictionary<string, string>> dropdownValues = new Dictionary<string, Dictionary<string, string>>();
            dropdownValues.Add("-- Installation Or Repair --", new Dictionary<string, string> { 
                { "1", "AC" }, 
                { "2", "Washing Machine" } ,
                { "3", "Watches | Clocks" },
                { "4", "Mobile | Laptop"},
                { "5", "Bike | Car"}
            });
            dropdownValues.Add("-- House --", new Dictionary<string, string> {
                { "6", "Tailor | Iron" }, 
                { "7", "Gas" },
                { "8", "Water" },
                { "9", "Maid" },
                { "10", "Electrition" },
                { "11", "Plumber" },
                { "12", "Carpenter" },
                { "13", "Construction" },
                { "14", "UPS | Inverters | Generators" },
                { "15", "Welding" },
                { "16", "Internet Provider" },
                { "17", "Jewllery" }
            });
            dropdownValues.Add("-- Travel --", new Dictionary<string, string> { 
                { "18", "Book auto | Cab | Truck" }, 
                { "19", "Courier" } 
            });
            dropdownValues.Add("-- Finance --", new Dictionary<string, string> { 
                { "20", "Accounts" }
            });
            dropdownValues.Add("-- Education --", new Dictionary<string, string> { 
                { "21", "Tutions" }, 
                { "22", "Coaching center" } 
            });
            dropdownValues.Add("-- Wedding and Pgotography --", new Dictionary<string, string> { 
                { "23", "Event Management" }, 
                { "24", "Chef" },
                { "25", "Wedding cards" },
                { "26", "Video grapher" },
            });
            dropdownValues.Add("-- Software --", new Dictionary<string, string> { 
                { "27", "Website developer" }
            });
            dropdownValues.Add("-- Wellbeing --", new Dictionary<string, string> { 
                { "28", "SPA" }, 
                { "29", "Gym" } 
            });
            dropdownValues.Add("-- Hospital --", new Dictionary<string, string> { 
                { "30", "Clinic | Diagnostic center" }
            });
            dropdownValues.Add("-- Others --", new Dictionary<string, string> { 
                { "31", "Agriculture" }, 
                { "32", "Xerox" } 
            });
            return dropdownValues;
        }
    }
}
