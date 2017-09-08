using Practical.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Service
{
    public interface IUServicesService
    {
        UService GetUService(long id);
        IEnumerable<UService> GetUService();
        List<UService> GetUserServices(long userId);
    }
}
