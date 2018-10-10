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
    public class EmployeesController : Controller
    {
        private readonly IUserService _UserService;

        public EmployeesController(IUserService userService)
        {
            _UserService = userService;
        }

        /*
        // GET: api/values
        [HttpGet] 
        public IEnumerable<string> Get()
        {
            return null;
        }
        */



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
            return Ok(_UserService.CreateEmployee(user));
        }

        // POST api/values
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
            return Ok(_UserService.Delete(new User(){Id = id}));
        }
    }
}
