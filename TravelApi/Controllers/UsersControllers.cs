using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TravelApi.Services;
using TravelApi.Models;
using System;


namespace TravelApi.Controllers
{
  [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private TravelApiContext _db;
        
        private IUserService _userService;

        public UsersController(TravelApiContext db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            Console.WriteLine($"||||||||||||||||||||||||||||||||||||||||||||We are inside Users Controller anonymous allowed {userParam.Username} and {userParam.Password}");
            var user = _userService.Authenticate(userParam.Username, userParam.Password);
            
            Console.WriteLine($"|||||||||||||||||||||||||||||||||||||||||||| value for the user variable is = {user}");
            if (user == null)
                return BadRequest(new { message = "Definitely not the correct username or password" });

            return Ok(user);
        }

        // [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);
        }
    }
}