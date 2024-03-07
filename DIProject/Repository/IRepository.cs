using DIProject.Model;

namespace DIProject.Repository
{
    public interface IRepository
    {
        int ExecuteNonQueryCommand(string command);
        User? GetUserCommand(int id);
    }
}