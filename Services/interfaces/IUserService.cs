using core;

namespace Services
{
    /// <summary>
    /// The user service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns>A list of Users.</returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Creates the.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An User.</returns>
        User Create(User user);

        User Get(Guid user);


        void Delete(Guid id);
    }
}