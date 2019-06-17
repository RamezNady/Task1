using Task_API.DAL.TaskContext;
using Task_API.DAL.Models;


namespace Task_API.BLL.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DataContext context) : base(context)
        {

        }        
    }
}