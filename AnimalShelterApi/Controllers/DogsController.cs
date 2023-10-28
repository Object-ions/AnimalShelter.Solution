using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DogsController : ControllerBase
  {
    private readonly AnimalShelterApiContext _db;

    public DogsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    // GET api/dogs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dog>>> Get(string name, string sex, int age, string personality)
    {
       IQueryable<Dog> query = _db.Dogs.AsQueryable();

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

      return await query.ToListAsync();
    }

    // GET api/dogs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Dog>> GetDog(int id)
    {
      Dog dog = await _db.Dogs.FindAsync(id);

      if (dog == null)
      {
        return NotFound();
      }

      return dog;
    }
    
    // POST api/dogs
    [HttpPost]
    public async Task<ActionResult<Dog>> Post(Dog dog)
    {
      _db.Dogs.Add(dog);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetDog), new { id = dog.DogId }, dog);
    }

    // PUT api/dogs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDog(int id, Dog dog)
    {
    if (id != dog.DogId)
    {
      return BadRequest();
    }

    _db.Dogs.Update(dog);

    try
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!DogExists(id))
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

    private bool DogExists(int id)
    {
      return _db.Dogs.Any(e => e.DogId == id);
    }

    // DELETE api/dogs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDog(int id)
    {
      Dog dog = await _db.Dogs.FindAsync(id);
      if (dog == null)
      {
        return NotFound();
      }

      _db.Dogs.Remove(dog);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}