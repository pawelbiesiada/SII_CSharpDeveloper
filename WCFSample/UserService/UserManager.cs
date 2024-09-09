using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    [ServiceContract]
    public interface IUserManager
    {
        [OperationContract]
        User GetUser();
    }

    public class UserManager : IUserManager
    {
        public User GetUser()
        {
            return new User
            {
                Id = 2,
                Name = "John",
                Password = "1234",
                IsActive = true
            };
        }
    }
}
