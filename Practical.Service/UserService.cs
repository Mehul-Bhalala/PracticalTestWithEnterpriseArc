using Practical.Data;
using Practical.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Service
{
    public class UserService:IUserServices
    {
        private IRepository<User> userRepository;
        private IRepository<UService> userviceRepository;

        public UserService(IRepository<User> userRepository, IRepository<UService> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userviceRepository = userProfileRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }


        public User GetUser(long id)
        {
            return userRepository.Table().FirstOrDefault(c => c.Id == id); 
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {            
            UService uservice = userviceRepository.Table().FirstOrDefault(c => c.Id == id);
            userviceRepository.Remove(uservice);
            User user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }
    }
}
