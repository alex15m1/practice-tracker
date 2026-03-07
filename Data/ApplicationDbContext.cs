using Microsoft.EntityFrameworkCore;
using PracticeTracker.Models;

namespace PracticeTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PracticeEntry> PracticeEntries { get; set;}
    }
}