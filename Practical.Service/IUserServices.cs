using Practical.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Practical.Service
{
    public interface IUserServices
    {
        IEnumerable<User> GetUsers();

        IEnumerable<User> GetUsers(long id);
        User GetUser(long id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
    }
}
