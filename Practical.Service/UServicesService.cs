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
        private IRepository<Practical.Data.UserService> userServiceRepository;
        private IRepository<UService> userviceRepository;

        public UServicesService(IRepository<Practical.Data.UserService> userServiceRepository, IRepository<UService> userviceRepository)
        {
            this.userServiceRepository = userServiceRepository;
            this.userviceRepository = userviceRepository;
        }

        public List<UService> GetUserServices(long userId)
        {
            return userServiceRepository.Table().Where(c => c.UserId == userId).Select(c => c.Service).ToList();
        }

        public UService GetUService(long id)
        {
            return userviceRepository.Table().FirstOrDefault(c => c.Id == id);
        }

        IEnumerable<UService> IUServicesService.GetUService()
        {
            return userviceRepository.GetAll();
        }
    }
}
