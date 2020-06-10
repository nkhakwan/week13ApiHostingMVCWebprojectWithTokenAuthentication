using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelApi.Models;


namespace TravelApi.Controllers
{
  [Authorize]
  [Produces("application/json")]
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
      Console.WriteLine("We are inside places controller");
      var query = _db.Places.AsQueryable(); // returns all Places in database as a queryable LINQ object
      if (city == null && country == null && rating == 0)
      {
        return _db.Places.ToList();
      }

      if (rating > 0)
      {
        query = query.Where(entry => entry.Rating == rating);
        // Console.WriteLine("we are in ratings");
      }
      
      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
        // Console.WriteLine("we are in city");
      }

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
        // Console.WriteLine("we are in country");
      }

      return query.ToList(); 
    }
    // GET api/places/5
    [HttpGet("{id}")] //returns existing api entry
    public ActionResult<Place> Get(int id)
    {
      return _db.Places.FirstOrDefault(entry => entry.PlaceId == id);
    }
    
    /// <summary>
    /// Creates a Place.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Places
    ///     {
    ///        "placeId": 1,
    ///        "City": "Seattle",
    ///        "Country": "United States",
    ///        "Description": "Always damp. Great bartenders."
    ///        "Rating": 8/10 (would get rained on again)
    ///     }
    ///
    /// </remarks>
    /// <param name="place"></param>
    /// <returns>A newly created place</returns>
    /// <response code="201">Returns the newly created place</response>
    /// <response code="400">If the place is null</response>
    // POST api/places
    [HttpPost] // adds new api entry
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Deletes a specific place.
    /// </summary>
    /// <param name="id"></param>
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