using AzureTestApp.Models;
using System.Collections.Generic;

namespace AzureTestApp.Services
{
    public class ExpensesService
    {
        HttpClient client;
        private AppDbContext _databaseContext;
        IConfiguration _configuration;
        private readonly string? apiURL;

        public ExpensesService(AppDbContext databaseContext, HttpClient client, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            this.client = client;
            _configuration = configuration;
            apiURL = _configuration["ApiUrl"];
        }
        public async Task<List<Expenses>> GetAllTransactionsByMonth(int month, int year)
        {
            List<Expenses> expenses = new List<Expenses>();
            string url = $"{apiURL}/api/Purse/GetTxByMonth?month={month}&year={year}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                expenses = await response.Content.ReadFromJsonAsync<List<Expenses>>();
            }
            return expenses;
        }
        public async Task<double> GetTotalByMonth(int month, int year)
        {
            Double total = 0;
            string url = $"{apiURL}/api/Purse/GetTotalByMonth?month={month}&year={year}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                total = await response.Content.ReadFromJsonAsync<Double>();
            }
            return total;
        }
        public async Task<List<CatageoryAmount>> GetByCatageory(int month, int year)
        {
            List<CatageoryAmount> catAmount = new List<CatageoryAmount>();
            string url = $"{apiURL}/api/Purse/GetCatageoryWiseByMonth?month={month}&year={year}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                catAmount = await response.Content.ReadFromJsonAsync<List<CatageoryAmount>>();
            }
            return catAmount;
        }
        public async Task AddTransaction(Expenses expenses)
        {
            string url = $"{apiURL}/api/Purse/AddTx";
            var response = await client.PostAsJsonAsync(url, expenses);
            if (response.IsSuccessStatusCode){}
        }
        public async Task<Expenses> GetTransactionbyId(int Id)
        {
            var result = _databaseContext.Tbl_Expenses.Where(x => x.Id == Id).FirstOrDefault();
            return result;
        }
        public async Task UpdateTransaction(int id, Expenses expenses)
        {
            string url = $"{apiURL}/api/Purse/UpdateTx?id={id}";
            var response = await client.PutAsJsonAsync(url, expenses);
            if (response.IsSuccessStatusCode) { }
        }
        public async Task DeleteTransaction(int Id)
        {
            string url = $"{apiURL}/api/Purse/DeleteTx?txId={Id}";
            var response = await client.PutAsync(url, null);
            if (response.IsSuccessStatusCode) { }
        }
        public List<int> GetYears()
        {
            List<int> years = new List<int>();
            int Year = DateTime.Now.Year;
            for (int yr = 2024; yr <= Year; yr++)
            {
                years.Add(yr);
            }
            return years;
        }
        public Dictionary<int, string> GetMonths()
        {
            Dictionary<int, string> monthDict = new Dictionary<int, string>();
            monthDict.Add(1, "January");
            monthDict.Add(2, "February");
            monthDict.Add(3, "March");
            monthDict.Add(4, "April");
            monthDict.Add(5, "May");
            monthDict.Add(6, "June");
            monthDict.Add(7, "July");
            monthDict.Add(8, "August");
            monthDict.Add(9, "September");
            monthDict.Add(10, "October");
            monthDict.Add(11, "November");
            monthDict.Add(12, "December");
            return monthDict;
        }
        public Dictionary<string, string> GetCatageories()
        {
            Dictionary<string, string> catDict = new Dictionary<string, string>();
            catDict.Add("EMI", "EMI");
            catDict.Add("House", "House");
            catDict.Add("Transport", "Transport");
            catDict.Add("SuperMarket", "SuperMarket");
            catDict.Add("Online", "Online");
            catDict.Add("Subscriptions", "Subscriptions");
            catDict.Add("CreditCard", "CreditCard");
            catDict.Add("Rice", "Rice");
            catDict.Add("Others", "Others");
            return catDict;
        }
        public Dictionary<string, string> GetTransactionType()
        {
            Dictionary<string, string> TxTypeDict = new Dictionary<string, string>();
            TxTypeDict.Add("Debited", "Debited");
            TxTypeDict.Add("Credited", "Credited");
            return TxTypeDict;
        }
    }
}
