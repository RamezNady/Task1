using Task_API.DAL.TaskContext;
using Task_API.DAL.Models;

namespace Task_API.BLL.Repository
{
    public class ActorRepository: Repository<Actor>
    {
        public ActorRepository(DataContext context) : base(context)
        {
        }
        
        
    }
}