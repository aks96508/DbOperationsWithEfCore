using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)   
        {
                
        }

        DbSet<Book> Books { get; set; } 
    }
}
