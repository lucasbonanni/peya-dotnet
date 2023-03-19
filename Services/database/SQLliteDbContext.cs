using core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.interfaces;

namespace Services.database
{
    /// <summary>
    /// The SQLlite db context.
    /// </summary>
    public class SQLliteDbContext : DbContext, IEntityFrameworkDbContext
    {

        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }
        Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade Database { get => base.Database; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLliteDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SQLliteDbContext(DbContextOptions<SQLliteDbContext> options) : base(options)
        {
            
        }

        /// <summary>
        /// Ons the configuring.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Todo.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.TaskList)
                .WithMany(tl => tl.Tasks)
                .HasForeignKey(t => t.id);
            modelBuilder.Entity<User>()
                .HasOne(u => u.TaskList);
        }

        public void InitializeDatabase()
        {
            base.Database.Migrate();
        }
    }

    public static class DabaseInitializer
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            using (var dbContext = serviceProvider.GetService<IEntityFrameworkDbContext>()) // IEntityFrameworkDbContext
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
