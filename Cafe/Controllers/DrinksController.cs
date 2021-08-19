﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

using Cafe.Models;

namespace Cafe.Controllers
{
  public class PaginationModel
  {
    public List<Drink> Data { get; set; }
    public int Total { get; set; }
    public int PerPage { get; set; }
    public int Page { get; set; }

    public string PreviousPage { get; set; }
    public string NextPage { get; set; }
  }

  [Route("api/[controller]")]
  [ApiController]
  public class DrinksController : ControllerBase
  {
    private readonly CafeContext _db;
    public DrinksController(CafeContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<PaginationModel>> Get(string name, string description, string temp, int price, int page, int perPage)
    // public async Task<ActionResult<IEnumerable<Drink>>> Get(string name, string description, string temp, int price)
    {
      var query = _db.Drinks.AsQueryable();
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

      // return 2 items at a time
      List<Drink> drinks = await query.ToListAsync();
      // data, the items being returns
      // total, the total number of items before we did pagination
      // current "page", the slice you're in
      // the number of items per page

      if (perPage == 0) perPage = 2;

      int total = drinks.Count;
      // 5, page = 2 we get an error

      // startIndex = page * 2
      // endIndex = (page * 2) + 1

      List<Drink> drinksPage = new List<Drink>();

      if ((page * 2) + 1 < total)
      {
        drinksPage = drinks.GetRange(page * 2, 2);
      }

      if ((page * 2) + 1 == total)
      {
        drinksPage = drinks.GetRange(page * 2, 1);
      }

      return new PaginationModel()
      {
        Data = drinksPage,
        Total = total,
        PerPage = perPage,
        Page = page,
        PreviousPage = $"/api/drinks?page={page - 1}",
        NextPage = $"/api/drinks?page={page + 1}",
      };
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Drink>> GetDrink(int id)
    {
      Drink drink = await _db.Drinks.FindAsync(id);

      if (drink == null)
      {
        return NotFound();
      }

      return drink;
    }
    [HttpPost]
    public async Task<ActionResult<Drink>> Post(Drink drink)
    {
      _db.Drinks.Add(drink);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetDrink), new { id = drink.DrinkId }, drink);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Drink drink)
    {
      if (id != drink.DrinkId)
      {
        return BadRequest();
      }

      _db.Entry(drink).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DrinkExists(id))
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
    private bool DrinkExists(int id)
    {
      return _db.Drinks.Any(c => c.DrinkId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDrink(int id)
    {
      Drink drink = await _db.Drinks.FindAsync(id);
      if (drink == null)
      {
        return NotFound();
      }

      _db.Drinks.Remove(drink);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}