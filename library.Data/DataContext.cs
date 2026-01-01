

using Microsoft.EntityFrameworkCore;

namespace Libary
{
    public class DataContext:DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Borrow> borrows { get; set; }
        public DbSet<Customer> customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Library_Db");
        }

    }
}
