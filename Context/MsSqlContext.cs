using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class MsSqlContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
         
        public MsSqlContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HOME-PC;Database=bookstore;Trusted_Connection=True;");
        }
    }
}