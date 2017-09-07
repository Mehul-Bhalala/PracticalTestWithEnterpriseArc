using Practical.Data;
using Practical.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practical.Service
{

   public class UserServicesList: IUserServicesList
    {
        private readonly ApplicationContext _db;

        public UserServicesList(ApplicationContext db)
        {
            _db = db;
        }

        IEnumerable<UService> IUserServicesList.GetUServiceListById(long id)
        {
            return _db.UService.Where(service => service.UserServices.Any(us => us.UserId == id));
        }
    }
}
