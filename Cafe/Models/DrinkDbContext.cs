using Microsoft.EntityFrameworkCore;

namespace Cafe.Models
{
    public class DrinkDbContext : DbContext
    {
        public DrinkDbContext(DbContextOptions<DrinkDbContext> options)
        : base(options) { }
        public DbSet<Drink> Drinks { get; set; }
    }
}