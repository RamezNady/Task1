using System.Threading.Tasks;
using Task_API.DAL.TaskContext;
using Task_API.DAL.Models;
using Task_API.BLL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Task_API.BLL.Manager
{
    public class ActorManager
    {

        private ActorRepository _ActorRepository;
        public ActorManager(DataContext context)
        {
            _ActorRepository = new ActorRepository(context);
        }



///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<Actor> Register(Actor actor, string password)
        {
            
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password,out passwordHash, out passwordSalt);
            actor.PasswordHash = passwordHash;
            actor.PasswordSalt = passwordSalt;
            
            await _ActorRepository.Add(actor);
            
            return actor;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }




///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<Actor> Login(string Name, string password)
        {
            var actor = await _ActorRepository.GetAllQuerable().Where(x=>x.Name==Name).SingleOrDefaultAsync();   

            if(actor==null) return null;
            if(!VerifyPasswordHash(password,actor.PasswordHash,actor.PasswordSalt)) return null;
        
            return actor;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var resultHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < resultHash.Length; i++)
                {
                    if (resultHash[i]!=passwordHash[i]) return false;
                }
                return true;
            
            }        
            
        }





///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<bool> ActorExists(string Name)
        {
            //if(await _ActorRepository.Actors.AnyAsync(x=>x.Name == Name)) 
            //    return true;
            //return false;
            if( await _ActorRepository.GetAllQuerable().Where(x=>x.Name==Name).SingleOrDefaultAsync() == null)
            {
                return false;
            }
            return true;

        }
    
    
    
    }
}