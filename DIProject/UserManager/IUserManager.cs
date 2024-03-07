using DIProject.Model;

namespace DIProject.UserManager
{
    public interface IUserManager
    {
        bool AddUser(User user);
        bool RemoveUser(User user);

        User? GetUser(int id);
    }
}
