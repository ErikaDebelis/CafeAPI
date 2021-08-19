using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Temp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.DrinkId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Temp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "DrinkId", "Description", "Name", "Price", "Temp" },
                values: new object[,]
                {
                    { 1, "This full-bodied dark roast coffee with bold, robust flavors showcases our roasting and blending artistry— an essential blend of balanced and lingering flavors.", "Hot Coffee", 3, "Hot" },
                    { 2, "Handcrafted in small batches daily, slow-steeped in cool water for 20 hours. Made from our custom blend of beans grown to steep long and cold for a super-smooth flavor.", "Iced Coffee", 4, "Cold" },
                    { 3, "Our dark, rich espresso combined with milk and served over ice. A perfect milk-forward cooldown.", "Iced Latte", 5, "Cold" },
                    { 4, "Smooth and creamy matcha sweetened just right and served with steamed milk. This favorite will transport your senses to pure green delight.", "Matcha Latte", 3, "Hot" },
                    { 5, "This boldly refreshing iced tea is made with a combination of our peach-flavored green tea and lemonade, and hand-shaken with ice.", "Iced Peach Green Tea", 2, "Cold" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Description", "Name", "Price", "Temp" },
                values: new object[,]
                {
                    { 1, "Sizzling applewood-smoked bacon, melty aged Gouda and a Parmesan frittata layered on an artisan roll for extra-smoky breakfast goodness.", "Breakfast Sandwich", 5, "Hot" },
                    { 2, "Thick-sliced turkey and melted provolone cheese stacked on a ciabatta roll, then topped with our signature basil pesto and arugula and tomato.", "Turkey Pesto Panini", 7, "Hot" },
                    { 3, "Cilantro lime brown rice and quinoa, arugula, grape tomatoes, Kalamata olives, cucumbers, hummus, lemon tahini dressing, feta and Greek yogurt.", "Mediterranean Bowl", 8, "Cold" },
                    { 4, "Chicken, arugula, romaine, baby kale, grape tomatoes, red onions, toasted pecan pieces, Gorgonzola and apple chips tossed in sweet white balsamic vinaigrette.", "Fuji Salad", 8, "Cold" },
                    { 5, "Freshly baked bagel topped with sesame seeds, poppy seeds, dried garlic, toasted onion & kosher salt. Toasted to perfection and topped with a generous amount of cream cheese", "Bagel", 3, "Hot" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
