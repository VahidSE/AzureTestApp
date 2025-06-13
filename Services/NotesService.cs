using AzureTestApp.Models;

namespace AzureTestApp.Services
{
    public class NotesService
    {
        HttpClient client;
        IConfiguration _configuration;
        private readonly string? apiURL;

        public NotesService(AppDbContext databaseContext, HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            _configuration = configuration;
            apiURL = _configuration["ApiUrl"];
        }

        public async Task<List<Notes>> GetAllNotes()
        {
            List<Notes> tasks = new List<Notes>();
            string url = $"{apiURL}/api/Notes/Tasks";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadFromJsonAsync<List<Notes>>();
            }
            return tasks;
        }

        public async Task AddNotes(Notes item)
        {
            string url = $"{apiURL}/api/Notes/AddTask";
            var response = await client.PostAsJsonAsync(url, item);
            if (response.IsSuccessStatusCode) { }
        }

        public async Task updateNotes(int id, Notes item)
        {
            string url = $"{apiURL}/api/Notes/UpdateTask?id={id}";
            var response = await client.PutAsJsonAsync(url, item);
            if (response.IsSuccessStatusCode) { }
        }
    }
}
