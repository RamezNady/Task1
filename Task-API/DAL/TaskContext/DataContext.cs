using Task_API.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Task_API.DAL.TaskContext
{
    public class DataContext: DbContext

    {
        public DataContext(DbContextOptions<DataContext> option) 
            : base(option)
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}