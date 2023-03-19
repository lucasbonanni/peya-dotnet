using core;
using Services.interfaces;

namespace Services.database.repositories
{
    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IEntityFrameworkDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public UserRepository(IEntityFrameworkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>A list of Users.</returns>
        public IEnumerable<User> GetUsers()
        {
            return this.dbContext.Users.ToList();
        }

        public User GetUser(Guid id)
        {
            return this.dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User CreateUser(User user)
        {
            user.TaskList = new TaskList();
            user.TaskList.Name = user.Name + " List";
            this.dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An User.</returns>
        public User UpdateUser(User user)
        {
            this.dbContext.Users.Update(user);
            dbContext.SaveChanges();
            return user;
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteUser(Guid id)
        {
            User user = this.dbContext.Users.FirstOrDefault(x => x.Id == id);
            this.dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }
    }
}
