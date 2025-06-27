using AzureTestApp.Models;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace AzureTestApp.Services
{
    //This class going to be modified further to work with all services
    public class HttpClientService
    {
        HttpClient client;
        ApiPathManagement _apiPathManagement;
        public HttpClientService(HttpClient httpClient, ApiPathManagement apiPathManagement) 
        {
            client = httpClient;
            _apiPathManagement = apiPathManagement;
        }

        public async Task<HttpClient> GetToken(string username, string password)
        {
            string token = string.Empty;
            string url = _apiPathManagement.GetToken;

            var response = await client.PostAsJsonAsync(url, new { username, password });
            if (!response.IsSuccessStatusCode) 
                return null;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            token = result?.Token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return client;
        }

        private class LoginResponse { public string Token { get; set; } = ""; }
    }
}
