using DIProject.Logging;
using DIProject.Model;
using DIProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIProject.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly IRepository _dbRepository;
        private readonly ILogger _logger;

        public UserManager(IRepository repository, ILogger logger)
        {
            _dbRepository = repository;
            _logger = logger;
        }

        public bool AddUser(User user)
        {
            _logger.LogDebug($"Adding new user {user.Id}:{user.Name}");
            try
            {
                var affectedRows = _dbRepository.ExecuteNonQueryCommand($"INSERT INTO Users VALUES {user.ToString()}");
                _logger.LogDebug($"User {user.Id}:{user.Name} added.");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return false;
        }

        public User? GetUser(int id)
        {
            _logger.LogDebug($"Getting user with id {id}");
            try
            {
                var user = _dbRepository.GetUserCommand(id);
                
                if(user != null)
                {                   
                    _logger.LogDebug($"User {user.Id}:{user.Name} retrieved.");
                    return user;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            _logger.LogWarning($"User {id} was not found.");
            return null;
        }

        public bool RemoveUser(User user)
        {
            _logger.LogDebug($"Deleting user {user.Id}:{user.Name}");
            try
            {
                var affectedRows = _dbRepository.ExecuteNonQueryCommand($"DELETE FROM Users VALUES {user.ToString()}");
                _logger.LogDebug($"User {user.Id}:{user.Name} removed.");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return false;
        }
    }
}
