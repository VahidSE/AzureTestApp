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

        public async Task<LoginResponse> GetToken(string username, string password)
        {
            string token = string.Empty;
            string url = _apiPathManagement.GetToken;

            var response = await client.PostAsJsonAsync(url, new { username, password });
            if (!response.IsSuccessStatusCode) 
                return null;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            token = result?.Token;
            if (token != "")
                result.Username = username;

            return result;
        }

        public class LoginResponse { 
            public string Token { get; set; } = "";
            public string Username { get; set; }
        }
    }
}
