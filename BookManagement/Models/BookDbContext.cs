using Microsoft.EntityFrameworkCore;

namespace BookManagement.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
