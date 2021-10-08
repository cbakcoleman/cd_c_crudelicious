using Microsoft.EntityFrameworkCore;

namespace cd_c_crudelicious.Models
{
    public class DishContext : DbContext
    {
        public DishContext(DbContextOptions options) : base(options) { }
        public DbSet<Dish> Dishes {get;set;}
    }
}