using System.Collections.Generic;
using System.Threading.Tasks;
using Task_API.DAL.TaskContext;
using Task_API.DAL.Models;
using Task_API.BLL.Repository;

namespace Task_API.BLL.Manager
{
    public class UserManager:IUserManager
    {
        private UserRepository _UserRepository;
        public UserManager(DataContext context)
        {
            _UserRepository = new UserRepository(context);
        }




        public  async Task<List<User>> Users()
        {
            return await _UserRepository.GetAll();
        }



        public  async Task<User> UserByID(int id)
        {
            return await _UserRepository.GetByID(id);
        }


        
        public  async Task<bool> RegistUser(User user)
        {
            return await _UserRepository.Add(user);
        }



        public  async Task<bool> UpdateUser(User user)
        {
            return await _UserRepository.Update(user);
        }



        public async Task<bool> DeleteUser(User user)
        {
            return await _UserRepository.Delete(user);
        }
    }
}