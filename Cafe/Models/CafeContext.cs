using Microsoft.EntityFrameworkCore;

namespace Cafe.Models
{
  public class CafeContext : DbContext
  {
    public CafeContext(DbContextOptions<CafeContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Drink>()
        .HasData(
          new Drink { DrinkId = 1, Name = "Hot Coffee", Description = "This full-bodied dark roast coffee with bold, robust flavors showcases our roasting and blending artistry— an essential blend of balanced and lingering flavors.", Temp = "Hot", Price = 3 },
          new Drink { DrinkId = 2, Name = "Iced Coffee", Description = "Handcrafted in small batches daily, slow-steeped in cool water for 20 hours. Made from our custom blend of beans grown to steep long and cold for a super-smooth flavor.", Temp = "Cold", Price = 4 },
          new Drink { DrinkId = 3, Name = "Iced Latte", Description = "Our dark, rich espresso combined with milk and served over ice. A perfect milk-forward cooldown.", Temp = "Cold", Price = 5 },
          new Drink { DrinkId = 4, Name = "Matcha Latte", Description = "Smooth and creamy matcha sweetened just right and served with steamed milk. This favorite will transport your senses to pure green delight.", Temp = "Hot", Price = 3 },
          new Drink { DrinkId = 5, Name = "Iced Passionfruit Green Tea", Description = "This boldly refreshing iced tea is made with a combination of our peach-flavored green tea and lemonade, and hand-shaken with ice.", Temp = "Cold", Price = 2 }
        );
      builder.Entity<Food>()
        .HasData(
          new Food { FoodId = 1, Name = "Breakfast Sandwich", Description = "Sizzling applewood-smoked bacon, melty aged Gouda and a Parmesan frittata layered on an artisan roll for extra-smoky breakfast goodness.", Temp = "Hot", Price = 5 },
          new Food { FoodId = 2, Name = "Turkey Pesto Panini", Description = "Thick-sliced turkey and melted provolone cheese stacked on a ciabatta roll, then topped with our signature basil pesto and arugula and tomato.", Temp = "Hot", Price = 7 },
          new Food { FoodId = 3, Name = "Mediterranean Bowl", Description = "Cilantro lime brown rice and quinoa, arugula, grape tomatoes, Kalamata olives, cucumbers, hummus, lemon tahini dressing, feta and Greek yogurt.", Temp = "Cold", Price = 8 },
          new Food { FoodId = 4, Name = "Fuji Salad", Description = "Chicken, arugula, romaine, baby kale, grape tomatoes, red onions, toasted pecan pieces, Gorgonzola and apple chips tossed in sweet white balsamic vinaigrette.", Temp = "Cold", Price = 8 },
          new Food { FoodId = 5, Name = "Bagel", Description = "Freshly baked bagel topped with sesame seeds, poppy seeds, dried garlic, toasted onion & kosher salt. Toasted to perfection and topped with a generous amount of cream cheese", Temp = "Hot", Price = 3 }
        );
    }

    public DbSet<Drink> Drinks { get; set; }
    public DbSet<Food> Foods { get; set; }
  }
}