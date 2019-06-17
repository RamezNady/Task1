using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task_API.DAL.TaskContext;


namespace Task_API.BLL.Repository
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAllQuerable();
        Task<TEntity> GetByID(int id);
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
    
}