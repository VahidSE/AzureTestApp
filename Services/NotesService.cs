using AzureTestApp.Models;

namespace AzureTestApp.Services
{
    public class NotesService
    {
        HttpClient client;
        private readonly ApiPathManagement _apiPathManagement;

        public NotesService(HttpClient client, ApiPathManagement apiPathManagement)
        {
            this.client = client;
            this._apiPathManagement = apiPathManagement;
        }

        public async Task<List<Notes>> GetAllNotes()
        {
            List<Notes> tasks = new List<Notes>();
            string url = _apiPathManagement.GetAllNotes;
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadFromJsonAsync<List<Notes>>();
            }
            return tasks;
        }

        public async Task AddNotes(Notes item)
        {
            string url = _apiPathManagement.AddNotes;
            var response = await client.PostAsJsonAsync(url, item);
            if (response.IsSuccessStatusCode) { }
        }

        public async Task updateNotes(int id, Notes item)
        {
            string url = _apiPathManagement.updateNotes(id);
            var response = await client.PutAsJsonAsync(url, item);
            if (response.IsSuccessStatusCode) { }
        }
    }
}
