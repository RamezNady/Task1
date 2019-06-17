using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Task_API.DAL.TaskContext;
using System.Threading.Tasks;


namespace Task_API.BLL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DataContext _dbContext;
        private DbSet<TEntity> _set;


        public Repository(DataContext context)
        {
            _dbContext = context;
            _set = _dbContext.Set<TEntity>();
        }

   


        public async Task<List<TEntity>> GetAll()
        {
            return await _set.ToListAsync();
        }



        public  IQueryable<TEntity> GetAllQuerable()
        {
            return  _set;
        }


        public async Task<TEntity> GetByID(int id)
        {
            return await _set.FindAsync(id);
        }


        public async Task<bool> Add(TEntity entity)
        {
            await _set.AddAsync(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }


        public async Task<bool> Update(TEntity entity)
        {
             _set.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }


        public async Task<bool> Delete(TEntity entity)
        {
            _set.Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }


    }

}