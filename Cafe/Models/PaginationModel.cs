using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Cafe.Models
{
  public class PaginationModel
  {
    public List<Drink> DrinkData { get; set; }
    public List<Food> FoodData { get; set; }
    public int Total { get; set; }
    public int PerPage { get; set; }
    public int Page { get; set; }
    public string PreviousPage { get; set; }
    public string NextPage { get; set; }
  }
}