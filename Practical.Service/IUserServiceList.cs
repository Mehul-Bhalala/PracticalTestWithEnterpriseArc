using Practical.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Service
{
  public  interface IUserServicesList
    {
        IEnumerable<UService> GetUServiceListById(long id);
    }
}
