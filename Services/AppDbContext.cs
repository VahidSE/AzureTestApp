using AzureTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureTestApp.Services
{  
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Expenses> Tbl_Expenses { get; set; }
    }
}
