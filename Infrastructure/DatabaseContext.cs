using Microsoft.EntityFrameworkCore;
using RESTfulReference.Domain.Entities.Catalog;
using RESTfulReference.Domain.Entities.Taxes;

namespace RestfulReference.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<RPS> RPSs { get; set; }
        public DbSet<NFSe> Documents { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
