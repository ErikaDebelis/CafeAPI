using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

using Cafe.Models;

namespace Cafe.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FoodsController : ControllerBase
  {
    private readonly CafeContext _db;
    public FoodsController(CafeContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<PaginationModel>> Get(string name, string description, string temp, int price, int page, int perPage)
    {
      var query = _db.Foods.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }
      if (temp != null)
      {
        query = query.Where(entry => entry.Temp == temp);
      }
      if (price != 0)
      {
        query = query.Where(entry => entry.Price == price);
      }

      List<Food> foods = await query.ToListAsync();

      if (perPage == 0) perPage = 2;

      int total = foods.Count;
      List<Food> foodsPage = new List<Food>();

      if (page < (total / perPage))
      {
        foodsPage = foods.GetRange(page * perPage, perPage);
      }

      if (page == (total / perPage))
      {
        foodsPage = foods.GetRange(page * perPage, total - (page * perPage));
      }

      return new PaginationModel()
      {
        FoodData = foodsPage,
        Total = total,
        PerPage = perPage,
        Page = page,
        PreviousPage = page == 0 ? $"/api/foods?page={page}" : $"/api/foods?page={page - 1}",
        NextPage = $"/api/foods?page={page + 1}",
      };
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Food>> GetFood(int id)
    {
      Food food = await _db.Foods.FindAsync(id);

      if (food == null)
      {
        return NotFound();
      }

      return food;
    }

    [HttpPost]
    public async Task<ActionResult<Food>> Post(Food food)
    {
      _db.Foods.Add(food);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetFood), new { id = food.FoodId }, food);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Food food)
    {
      if (id != food.FoodId)
      {
        return BadRequest();
      }

      _db.Entry(food).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!FoodExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool FoodExists(int id)
    {
      return _db.Foods.Any(c => c.FoodId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFood(int id)
    {
      Food food = await _db.Foods.FindAsync(id);
      if (food == null)
      {
        return NotFound();
      }

      _db.Foods.Remove(food);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}