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
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            List<UserV1> users = new List<UserV1>();
            var user1 = new UserV1
            {
                UserId = 1,
                UserName = "Ronny Willims",
                Age = 35
            };

            var user2 = new UserV1
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
        public IActionResult GetV1([FromRoute] int userId)
        {
            var user = new UserV1
            {
                UserId = userId,
                UserName = "Ronny Willims",
                Age = 35

            };
            return Ok(user);
        }

        // GET api/<UsersController>/5
        [HttpGet("{userId}")]
        [MapToApiVersion("2.0")]
        public IActionResult GetV2([FromRoute] int userId)
        {
            var user = new UserV2
            {
                UserId = userId,
                UserName = "Ronny Willims",
                UserEmail= "RonnyWillims@gmail.com",
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
