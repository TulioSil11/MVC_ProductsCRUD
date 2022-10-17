using Microsoft.EntityFrameworkCore;
using IntermediateModels.Models;

namespace IntermediateModels.Infra.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }       

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
