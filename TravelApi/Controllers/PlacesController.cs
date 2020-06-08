using TravelApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TravelApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlacesController : ControllerBase
  {
    private TravelApiContext _db;

    public PlacesController(TravelApiContext db)
    {
      _db = db;
    }

    // GET api/places
    [HttpGet]
    public ActionResult<IEnumerable<Place>> Get(int rating, string city, string country) // binds query parameter to this string description
    {
      var query = _db.Places.AsQueryable(); // returns all Places in database as a queryable LINQ object
      if (city == null && country == null && rating == 0)
      {
        return _db.Places.ToList();
      }

      if (rating > 0)
      {
        query = query.Where(entry => entry.Rating == rating);
        Console.WriteLine("we are in ratings");
      }
      
      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
        Console.WriteLine("we are in city");
      }

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
        Console.WriteLine("we are in country");
      }

      return query.ToList(); 
    }
    // GET api/places/5
    [HttpGet("{id}")] //returns existing api entry
    public ActionResult<Place> Get(int id)
    {
      return _db.Places.FirstOrDefault(entry => entry.PlaceId == id);
    }
    
    // POST api/places
    [HttpPost] // adds new api entry
    public void Post([FromBody] Place place)
    {
      _db.Places.Add(place);
      _db.SaveChanges();
    }

    // PUT api/places/5
    [HttpPut("{id}")] // edits existing api entry
    public void Put(int id, [FromBody] Place place)
    {
      place.PlaceId = id;
      _db.Entry(place).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/places/5
    [HttpDelete("{id}")] // deletes existing api entry
    public void Delete(int id)
    {
      var placeToDelete = _db.Places.FirstOrDefault(entry => entry.PlaceId == id);
      _db.Places.Remove(placeToDelete);
      _db.SaveChanges();
    }
  }
}