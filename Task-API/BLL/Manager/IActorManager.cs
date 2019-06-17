using System.Threading.Tasks;
using Task_API.DAL.Models;


namespace Task_API.BLL.Manager
{
    public interface IActorManager
    {
        Task<Actor> Register(Actor actor, string password);
        Task<Actor> Login(string Name,string password);
        Task<bool> ActorExists(string Name);
    }
}