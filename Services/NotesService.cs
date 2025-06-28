using AzureTestApp.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace AzureTestApp.Services
{
    public class NotesService
    {
        HttpClient client;
        private readonly ApiPathManagement _apiPathManagement;
        private readonly ProtectedSessionStorage _session;
        public NotesService(HttpClient client, ApiPathManagement apiPathManagement, ProtectedSessionStorage session)
        {
            this.client = client;
            this._apiPathManagement = apiPathManagement;
            _session = session;
        }

        private async void SetClientWithHeader()
        {
            //var tokenResult = await _session.GetAsync<string>("authToken");
            //var token = tokenResult.Success ? tokenResult.Value : null;
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _session.Token);
        }

        public async Task<List<Notes>> GetAllNotes()
        {
            SetClientWithHeader();
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
            SetClientWithHeader();
            string url = _apiPathManagement.AddNotes;
            var response = await client.PostAsJsonAsync(url, item);
            if (response.IsSuccessStatusCode) { }
        }

        public async Task updateNotes(int id, Notes item)
        {
            SetClientWithHeader();
            string url = _apiPathManagement.updateNotes(id);
            var response = await client.PutAsJsonAsync(url, item);
            if (response.IsSuccessStatusCode) { }
        }
    }
}
