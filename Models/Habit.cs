namespace AzureTestApp.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string HabitType { get; set; } // e.g., "Workout", "Reading"
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class HabitList
    {
        public int Id { get; set; }
        public string HabitType { get; set; }
    }

}
