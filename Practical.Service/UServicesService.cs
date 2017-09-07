using Practical.Data;
using Practical.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Service
{
    public class UServicesService : IUServicesService
    {
        private IRepository<User> userRepository;
        private IRepository<UService> userviceRepository;

        public UServicesService(IRepository<User> userRepository, IRepository<UService> userviceRepository)
        {
            this.userRepository = userRepository;
            this.userviceRepository = userviceRepository;
        }

        public UService GetUService(long id)
        {
            return userviceRepository.Get(id);
        }


        IEnumerable<UService> IUServicesService.GetUServiceList(long id)
        {
            return userviceRepository.GetAll();
        }

        IEnumerable<UService> IUServicesService.GetUService()
        {
            return userviceRepository.GetAll();
        }
    }
}
