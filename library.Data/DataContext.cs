

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Libary
{
    public class DataContext:DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Borrow> borrows { get; set; }
        public DbSet<Customer> customers { get; set; }
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings"]);
        }

    }
}
