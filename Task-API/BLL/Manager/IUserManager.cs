using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_API.DAL.TaskContext;
using Task_API.DAL.Models;
using Task_API.BLL.Manager;



namespace Task_API.BLL.Manager
{
    public interface IUserManager
    {
        Task<List<User>> Users();
        Task<User> UserByID(int id);
        Task<bool> RegistUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);

    }
}