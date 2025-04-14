using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry { Id = 1, Title = "First Entry", Content = "This is my first entry", Created = new DateTime(2023, 1, 1) },
                new DiaryEntry { Id = 2, Title = "Second Entry", Content = "This is my second entry", Created = new DateTime(2023, 1, 2) },
                new DiaryEntry { Id = 3, Title = "Third Entry", Content = "This is my third entry", Created = new DateTime(2023, 1, 3) }
            );
        }
    }
}
