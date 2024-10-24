using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;

namespace RepositoryPattern.Data
{
    public class AppDbContext :DbContext
    {

        public DbSet<User> Users { get; set; } 
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}
