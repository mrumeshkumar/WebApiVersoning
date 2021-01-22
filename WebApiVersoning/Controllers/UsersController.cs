using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiVersoning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            List<User> users = new List<User>();
            var user1 = new User
            {
                UserId = 1,
                UserName = "Ronny Willims",
                Age = 35
            };

            var user2 = new User
            {
                UserId = 2,
                UserName = "Jony Willims",
                Age = 39
            };
            users.Add(user1);
            users.Add(user2);

            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{userId}")]
        public IActionResult Get([FromRoute] int userId)
        {
            var user = new User
            {
                UserId = userId,
                UserName = "Ronny Willims",
                Age = 35

            };
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
