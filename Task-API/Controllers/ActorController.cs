using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Task_API.DAL.TaskContext;
using Task_API.DAL.Models;
using Task_API.BLL.Manager;
using Task_API.DTO;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;



namespace Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {

        private ActorManager _actorManager;
        private IConfiguration _config;
        public ActorController(ActorManager actorManager,IConfiguration config)
        {
            _actorManager = actorManager;
            _config = config;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {            
            return new string[] { "value1", "value2" };
        }

        // POST 
        [HttpPost("register")] 
        public  async Task<IActionResult> Register([FromBody]ActorForRegisterDTO a){
            //validation
            if(!ModelState.IsValid) return BadRequest(ModelState);

            a.Name = a.Name.ToLower();
            if(await _actorManager.ActorExists(a.Name)) return BadRequest("aready Exit.");

            var newactor = new Actor();
            newactor.Name = a.Name;

            var CreaqtedActor = await _actorManager.Register(newactor,a.Password);
            return StatusCode(201);
  
        }


        [HttpPost("login")] 
        public  async Task<IActionResult> login(ActorForLoginDTO a){
                               
            Actor actor = await _actorManager.Login(a.Name.ToLower(),a.Password);

            if(actor == null) return Unauthorized(); 

            var claims = new []{
                new Claim(ClaimTypes.NameIdentifier,actor.ID.ToString()),
                new Claim(ClaimTypes.Name,actor.Name)
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSetting:Token").Value));

            var creds = new SigningCredentials(Key,SecurityAlgorithms.HmacSha512);

            var TokenDescriptor  = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var TokenHandler = new JwtSecurityTokenHandler();

            var Token = TokenHandler.CreateToken(TokenDescriptor);
            
            return Ok(new{token =TokenHandler.WriteToken(Token)});

        }




    }
}

