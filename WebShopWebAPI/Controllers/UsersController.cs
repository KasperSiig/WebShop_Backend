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
            return Ok(_UserService.GetUserById(id));
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
                    return Ok(_UserService.CreateEmployee(user));
                }

            }
            else
            {
                if (user.Employee == null)
                {
                    return Ok(_UserService.CreateCustomer(user));
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
            User logInUser = _UserService.Login(user);
            logInUser.PasswordHash = null;
            return Ok(_UserService.Login(user));
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody]User user)
        {
            user.Id = id;
            return Ok(_UserService.Update(user));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            return Ok(_UserService.Delete(new User() { Id = id }));
        }

    }
}

