using AzureTestApp.Models;
using System.Threading.Tasks;

namespace AzureTestApp.Services
{
    public class HabitService
    {
        HttpClient client;
        IConfiguration _configuration;
        private readonly string? apiURL;

        public HabitService(AppDbContext databaseContext, HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            _configuration = configuration;
            apiURL = _configuration["ApiUrl"];
        }

        public async Task<List<Habit>> GetAllHabits()
        {
            List<Habit> tasks = new List<Habit>();
            string url = $"{apiURL}/api/Habit/AllHabits";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadFromJsonAsync<List<Habit>>();
            }
            return tasks;
        }

        public async Task<List<HabitList>> GetAllHabitsList()
        {
            List<HabitList> tasks = new List<HabitList>();
            string url = $"{apiURL}/api/Habit/AllHabitsList";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadFromJsonAsync<List<HabitList>>();
            }
            tasks = tasks.DistinctBy(x => x.HabitType).ToList();
            return tasks;
        }

        public async Task AddHabit(HabitList habitsList)
        {
            string url = $"{apiURL}/api/Habit/AddHabit";
            var response = await client.PostAsJsonAsync(url, habitsList);
            if (response.IsSuccessStatusCode) 
            { 

            }
        }
        public async Task HabitLog(Habit habit)
        {
            string url = $"{apiURL}/api/Habit/HabitLog";
            var response = await client.PostAsJsonAsync(url, habit);
            if (response.IsSuccessStatusCode)
            {

            }
        }
        public async Task<List<Habit>> GetStreak(int month)
        {
            List<Habit> tasks = new List<Habit>();
            string url = $"{apiURL}/ api/Habit/GetStreak?month={month}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadFromJsonAsync<List<Habit>>();
            }
            return tasks;
        }

        public async Task UpdateHabit(int id, Habit habit)
        {
            string url = $"{apiURL}/api/Habit/UpdateTask?Id={id}";
            var response = await client.PutAsJsonAsync(url, habit);
            if (response.IsSuccessStatusCode) 
            { }
        }
    }
}
