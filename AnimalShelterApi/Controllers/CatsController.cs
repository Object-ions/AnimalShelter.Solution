using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CatsController : ControllerBase
  {
    private readonly AnimalShelterApiContext _db;

    public CatsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    // GET api/cats
    [HttpGet]
    public ActionResult<IEnumerable<Dog>> Get(string name, string sex, int age, string personality, int minAge, int maxAge, int pageIndex, int pageSize)
    {
      IQueryable<Cat> query = _db.Cats.AsQueryable();

      if (name != null)
      {
        query = query.Where(e => e.Name == name);
      }

      if (sex != null)
      {
        query = query.Where(e => e.Sex == sex);
      }

      if (age != 0)
      {
        query = query.Where(e => e.Age == age);
      }

      if (minAge > 0)
      {
        query = query.Where(e => e.Age >= minAge);
      }

      if (maxAge != 0)
      {
        query = query.Where(e => e.Age <= maxAge);
      }

      if (personality != null)
      {
        query = query.Where(e => e.Personality == personality);
      }

      var paginatedResults = PaginationHelper.Paging(query, pageIndex, pageSize);

      return Ok(paginatedResults);
    }

    // GET api/cats/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Cat>> GetCat(int id)
    {
      Cat cat = await _db.Cats.FindAsync(id);

      if (cat == null)
      {
        return NotFound();
      }

      return cat;
    }

    // POST api/cats
    [HttpPost]
    public async Task<ActionResult<Cat>> Post(Cat cat)
    {
      _db.Cats.Add(cat);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetCat), new { id = cat.CatId }, cat);
    }

    // PUT: api/Cats/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCat(int id, Cat cat)
    {
      if (id != cat.CatId)
      {
        return BadRequest();
      }

      _db.Cats.Update(cat);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CatExists(id))
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

    private bool CatExists(int id)
    {
      return _db.Cats.Any(e => e.CatId == id);
    }

    // DELETE api/cats/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCat(int id)
    {
      Cat cat = await _db.Cats.FindAsync(id);
      if (cat == null)
      {
        return NotFound();
      }
      
      _db.Cats.Remove(cat);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}