using AzureTestApp.Services;
using Microsoft.Extensions.Configuration;

namespace AzureTestApp.Models
{
    /// <summary>
    /// It contains all API URL's at one place. It is easy to modify, if any change occurs in future.
    /// </summary>
    public class ApiPathManagement
    {
        private readonly IConfiguration _configuration;
        public ApiPathManagement(IConfiguration configuration)
        {
            _configuration = configuration;          
        }
        public string apiURL => _configuration["ApiUrl"];

        #region HttpClientService
        public string GetToken => $"{apiURL}/api/Door/GetToken";

        #endregion

        #region ExpenseService
        public string GetAllTransactionsByMonth(int month, int year) => $"{apiURL}/api/Purse/GetTxByMonth?month={month}&year={year}";
        public string GetTotalByMonth(int month, int year) => $"{apiURL}/api/Purse/GetTotalByMonth?month={month}&year={year}";
        public string GetByCatageory(int month, int year) => $"{apiURL}/api/Purse/GetCatageoryWiseByMonth?month={month}&year={year}";
        public string AddTransaction => $"{apiURL}/api/Purse/AddTx";
        public string UpdateTransaction(int id) => $"{apiURL}/api/Purse/UpdateTx?id={id}";
        public string DeleteTransaction(int Id) => $"{apiURL}/api/Purse/DeleteTx?txId={Id}";

        #endregion

        #region HabitService
        public string GetAllHabits => $"{apiURL}/api/Habit/AllHabits";
        public string GetAllHabitsList => $"{apiURL}/api/Habit/AllHabitsList";
        public string AddHabit => $"{apiURL}/api/Habit/AddHabit";
        public string HabitLog => $"{apiURL}/api/Habit/HabitLog";
        public string GetStreak(int month) => $"{apiURL}/api/Habit/GetStreak?month={month}";
        public string UpdateHabit(int id) => $"{apiURL}/api/Habit/UpdateTask?Id={id}";
        #endregion

        #region NotesService
        public string GetAllNotes => $"{apiURL}/api/Notes/Tasks";
        public string AddNotes => $"{apiURL}/api/Notes/AddTask";
        public string updateNotes(int id) => $"{apiURL}/api/Notes/UpdateTask?id={id}";
        #endregion
    }
}
