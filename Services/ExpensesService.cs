using AzureTestApp.Models;
using System.Collections.Generic;


namespace AzureTestApp.Services
{
    public class ExpensesService
    {
        HttpClient client;
        //public Expenses formData = new Expenses();
        private AppDbContext _databaseContext;
        public ExpensesService(AppDbContext databaseContext, HttpClient client)
        {
            _databaseContext = databaseContext;
            this.client = client;
        }
        public async Task<List<Expenses>> GetAllTransactionsByMonth(int month, int year)
        {
            List < Expenses > expenses = new List<Expenses> ();
            string url = $"http://localhost:3344/api/Purse/GetTxByMonth?month={month}&year={year}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                expenses = await response.Content.ReadFromJsonAsync<List<Expenses>>();
            }
            return expenses;

            //return _databaseContext.Tbl_Expenses.Where(tx => tx.DayOfTransaction.Month == month && tx.DayOfTransaction.Year == year).ToList();
        }

        public async Task<double> GetTotalByMonth(int month, int year)
        {
            Double total = 0;
            string url = $"http://localhost:3344/api/Purse/GetTotalByMonth?month={month}&year={year}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                total = await response.Content.ReadFromJsonAsync<Double>();
            }
            return total;
            //return _databaseContext.Tbl_Expenses.Where(tx => tx.DayOfTransaction.Month == month && tx.DayOfTransaction.Year == year).Sum(x => x.Amount);
        }

        public async Task<List<CatageoryAmount>> GetByCatageory(int month, int year)
        {
            List<CatageoryAmount> catAmount = new List<CatageoryAmount>();
            string url = $"http://localhost:3344/api/Purse/GetCatageoryWiseByMonth?month={month}&year={year}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                catAmount = await response.Content.ReadFromJsonAsync<List<CatageoryAmount>>();
            }
            return catAmount;
            //return _databaseContext.Tbl_Expenses
            //    .Where(tx => tx.DayOfTransaction.Month == month && tx.DayOfTransaction.Year == year)
            //    .GroupBy(x=> x.Catageory)
            //    .Select(g => new CatageoryAmount { Catageory = g.Key, TotalAmount = g.Sum(x=> x.Amount)}).ToList();
        }



        public async Task AddTransaction(Expenses expenses)
        {
            string url = "http://localhost:3344/api/Purse/AddTx";
            var response = await client.PostAsJsonAsync(url, expenses);
            if (response.IsSuccessStatusCode)
            {

            }
            //_databaseContext.Tbl_Expenses.Add(expenses);
            //_databaseContext.SaveChanges();
        }

        public async Task<Expenses> GetTransactionbyId(int Id)
        {
           var result = _databaseContext.Tbl_Expenses.Where(x=> x.Id == Id).FirstOrDefault();
            return result;
        }

        public async Task DeleteTransaction(int Id)
        { 
        
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
            for (int m = 1; m <= 12; m++)
            {
                if (m == 1)
                    monthDict.Add(m, "January");
                if (m == 2)
                    monthDict.Add(m, "February");
                if (m == 3)
                    monthDict.Add(m, "March");
                if (m == 4)
                    monthDict.Add(m, "April");
                if (m == 5)
                    monthDict.Add(m, "May");
                if (m == 6)
                    monthDict.Add(m, "June");
                if (m == 7)
                    monthDict.Add(m, "July");
                if (m == 8)
                    monthDict.Add(m, "August");
                if (m == 9)
                    monthDict.Add(m, "September");
                if (m == 10)
                    monthDict.Add(m, "October");
                if (m == 11)
                    monthDict.Add(m, "November");
                if (m == 12)
                    monthDict.Add(m, "December");
            }
            return monthDict;
        }

        public void UpdateTransaction() 
        {
        
        }


    }
}
