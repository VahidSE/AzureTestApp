using AzureTestApp.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Threading.Tasks;

namespace AzureTestApp.Services
{
    public class HabitService
    {
        HttpClient client;
        private readonly ApiPathManagement _apiPathManagement;
        private readonly ProtectedSessionStorage _session;
        public HabitService(HttpClient client, ApiPathManagement apiPathManagement, ProtectedSessionStorage session)
        {
            this.client = client;
            _apiPathManagement = apiPathManagement;
            _session = session;
        }

        private async void SetClientWithHeader()
        {
            //var tokenResult = await _session.GetAsync<string>("authToken");
            //var token = tokenResult.Success ? tokenResult.Value : null;
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _session.Token);
        }

        public async Task<List<Habit>> GetAllHabits()
        {
            SetClientWithHeader();
            List<Habit> tasks = new List<Habit>();
            string url = _apiPathManagement.GetAllHabits;
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadFromJsonAsync<List<Habit>>();
            }
            return tasks;
        }

        public async Task<List<HabitList>> GetAllHabitsList()
        {
            SetClientWithHeader();
            List<HabitList> tasks = new List<HabitList>();
            string url = _apiPathManagement.GetAllHabitsList;
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
            SetClientWithHeader();
            string url = _apiPathManagement.AddHabit;
            var response = await client.PostAsJsonAsync(url, habitsList);
            if (response.IsSuccessStatusCode) 
            { 

            }
        }
        public async Task HabitLog(Habit habit)
        {
            SetClientWithHeader();
            string url = _apiPathManagement.HabitLog;
            var response = await client.PostAsJsonAsync(url, habit);
            if (response.IsSuccessStatusCode)
            {

            }
        }
        public async Task<List<Habit>> GetStreak(int month)
        {
            SetClientWithHeader();
            List<Habit> tasks = new List<Habit>();
            string url = _apiPathManagement.GetStreak(month);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadFromJsonAsync<List<Habit>>();
            }
            return tasks;
        }

        public async Task UpdateHabit(int id, Habit habit)
        {
            SetClientWithHeader();
            string url = _apiPathManagement.UpdateHabit(id);
            var response = await client.PutAsJsonAsync(url, habit);
            if (response.IsSuccessStatusCode) 
            {

            }
        }
    }
}
