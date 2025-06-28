using AzureTestApp.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Headers;

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

        public async Task<List<Notes>> GetAllNotes()
        {
            var tokenResult = await _session.GetAsync<string>("authToken");
            var token = tokenResult.Success ? tokenResult.Value : null;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResult.Value);

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
            var tokenResult = await _session.GetAsync<string>("authToken");
            var token = tokenResult.Success ? tokenResult.Value : null;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResult.Value);


            string url = _apiPathManagement.AddNotes;
            var response = await client.PostAsJsonAsync(url, item);
            if (response.IsSuccessStatusCode) { }
        }

        public async Task updateNotes(int id, Notes item)
        {
            var tokenResult = await _session.GetAsync<string>("authToken");
            var token = tokenResult.Success ? tokenResult.Value : null;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResult.Value);

            string url = _apiPathManagement.updateNotes(id);
            var response = await client.PutAsJsonAsync(url, item);
            if (response.IsSuccessStatusCode) { }
        }
    }
}
