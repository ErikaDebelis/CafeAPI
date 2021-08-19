using System.ComponentModel.DataAnnotations;

namespace Cafe
{
  public class Food
  {
    public int FoodId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Temp { get; set; }
    public int Price { get; set; }
  }
}
