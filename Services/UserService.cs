using core;
using Services.interfaces;

namespace Services
{
    /// <summary>
    /// The user service.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Creates the.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An User.</returns>
        public User Create(User user)
        {
            return this.userRepository.CreateUser(user);
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns>A list of Users.</returns>
        public IEnumerable<User> GetAll()
        {
            return userRepository.GetUsers();
        }

        /// <summary>
        /// Gets the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An User.</returns>
        public User Get(Guid id)
        {
            return this.userRepository.GetUser(id);
        }

        /// <summary>
        /// Deletes the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An User.</returns>
        public void Delete(Guid id)
        {
            this.userRepository.DeleteUser(id);
        }
    }
}
