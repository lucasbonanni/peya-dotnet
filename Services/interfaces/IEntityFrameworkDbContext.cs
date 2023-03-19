using core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Services.interfaces
{
    public interface IEntityFrameworkDbContext : IDisposable
    {
         DbSet<TaskList> TaskLists { get; set; }
         DbSet<TaskItem> TaskItems { get; set; }
         DbSet<User> Users { get; set; }
        DatabaseFacade Database { get; }

        int SaveChanges();
        void InitializeDatabase();
    }
}
