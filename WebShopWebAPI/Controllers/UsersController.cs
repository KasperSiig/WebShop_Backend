using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.ApplicationService;
using WebShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _UserService;

        public UsersController(IUserService userService)
        {
            _UserService = userService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _UserService.GetUserById(id);
            user.PasswordHash = null; //because we dont like to send hashed passwords over the inthernet when it is not needed
            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post([FromBody]User user)
        {
            if (user.Customer == null){

                if(user.Employee == null){
                    return BadRequest("A user needs to have a Customer or a Employee");
                }
                else
                {
                    var returnedUser = _UserService.CreateEmployee(user);
                    returnedUser.PasswordHash = null;
                    return Ok(returnedUser);
                }

            }
            else
            {
                if (user.Employee == null)
                {

                    var returnedUser = _UserService.CreateCustomer(user);
                    returnedUser.PasswordHash = null;
                    return Ok(returnedUser);
                }
                else
                {
                    return BadRequest("A user needs to have either a Customer or a Employee");
                }
            }
        }

        // POST api/users/login
        [HttpPost("login")]
        public ActionResult<User> PostLogin([FromBody]User user)
        {
            if (user.Username == null || user.PasswordHash == null){
                return BadRequest("The user should have a username and password");
            }

            User logInUser = _UserService.Login(user);

            logInUser.PasswordHash = null;

            return Ok(logInUser);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody]User user)
        {
            user.Id = id;
            var returnedUser = _UserService.Update(user);

            returnedUser.PasswordHash = null;

            return Ok(returnedUser);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {

            var returnedUser = _UserService.Delete(new User() { Id = id });

            returnedUser.PasswordHash = null;

            return Ok(returnedUser);
        }

    }
}

