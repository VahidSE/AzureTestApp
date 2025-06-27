using System.Net.Http.Headers;

namespace AzureTestApp.Services
{
    //It is going to delete
    public class AuthService
    {
        private readonly HttpClient _http;
        private string? _token;

        public AuthService(HttpClient http) => _http = http;

        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:50211/api/auth/login", new { username, password });
            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            _token = result?.Token;

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            return true;
        }

        public void Logout()
        {
            _token = null;
            _http.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<string?> GetSecureData()
        {
            return await _http.GetStringAsync("https://localhost:50211/data");
        }

        private class LoginResponse { public string Token { get; set; } = ""; }
    }

}
