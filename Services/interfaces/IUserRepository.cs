using core;

namespace Services.interfaces
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        void DeleteUser(Guid id);
        User GetUser(Guid id);
        IEnumerable<User> GetUsers();
    }
}