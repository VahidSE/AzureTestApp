using System.ComponentModel.DataAnnotations;

namespace AzureTestApp.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Catageory { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime DayOfTransaction { get; set; } = DateTime.Now;
        public string TransactionType { get; set; }
    }

    public class Filter
    { 
    public int MonthFilter { get; set; } = DateTime.Now.Month;
    public int YearFilter { get; set; } = DateTime.Now.Year;

    }

    public class CatageoryAmount
    { 
       public string Catageory { get; set; }
       public double TotalAmount { get; set; }

    }
}
