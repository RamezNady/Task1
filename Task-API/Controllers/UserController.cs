using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_API.DAL.TaskContext;
using Task_API.DAL.Models;
using Task_API.BLL.Manager;


namespace Task_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET api/Users
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _userManager.Users();
        }

        
        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await _userManager.UserByID(id);
        }

        // POST api/Users
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            await _userManager.RegistUser(user);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User user)
        {
            User User = await _userManager.UserByID(id);
            User.Name = user.Name;
            User.State = user.State;
            await _userManager.UpdateUser(User);
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             User User =await _userManager.UserByID(id);
             if(User!=null){                 
             User.State=false;
             await _userManager.UpdateUser(User);
             return Ok();
             }
             else{
                 return NotFound();
             }
        }
    }
}
