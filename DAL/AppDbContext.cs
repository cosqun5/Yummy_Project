using Microsoft.EntityFrameworkCore;
using YummyMvc.Models;

namespace YummyMvc.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProducIngredient> producIngredients { get; set; }

    }
}
