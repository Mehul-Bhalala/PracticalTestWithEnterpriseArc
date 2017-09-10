using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practical.Service;
using Practical.Web.Models;
using Practical.Data;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practical.Web.API
{
    [EnableCors("CorsPolicy")]
    [Route("Users")]
    public class UserServiceController : Controller
    {
        private readonly IUserServices userService;
        private readonly IUServicesService uservicesService;

        public UserServiceController(IUserServices userService, IUServicesService uServicesService)
        {
            this.userService = userService;
            this.uservicesService = uServicesService;
        }

        // GET: api/values
        //[HttpGet]
        //public IEnumerable<UserViewModel> userList()
        //{
        //    List<UserViewModel> model = new List<UserViewModel>();
        //    userService.GetUsers().ToList().ForEach(u =>
        //    {
        //        var service = uservicesService.GetUserServices(u.Id).ToList();
        //        if (service.Count > 0)
        //        {
        //            service.ForEach(s =>
        //            {
        //                UserViewModel user = new UserViewModel
        //                {
        //                    Id = u.Id,
        //                    Name = u.FullName,
        //                    Service = s.Name,
        //                    CreatedDate = u.CreateDate,
        //                    Isactive = u.IsActive
        //                };
        //                model.Add(user);
        //            });
        //        }
        //        else
        //        {
        //            UserViewModel user = new UserViewModel
        //            {
        //                Id = u.Id,
        //                Name = u.FullName,
        //                Service = string.Empty,
        //                CreatedDate = u.CreateDate,
        //                Isactive = u.IsActive
        //            };
        //            model.Add(user);
        //        }

        //    });
        //    return model;
        //}

        // GET: api/values
        [HttpGet(Name ="GetUsers")]
        [Route("list")]
        public IEnumerable<UserViewModel> Get()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            userService.GetUsers().ToList().ForEach(u =>
            {
                var service = uservicesService.GetUserServices(u.Id).ToList();
                if (service.Count > 0)
                {
                    service.ForEach(s =>
                    {
                        UserViewModel user = new UserViewModel
                        {
                            Id = u.Id,
                            Name = u.FullName,
                            Service = s.Name,
                            CreatedDate = u.CreateDate,
                            Isactive = u.IsActive
                        };
                        model.Add(user);
                    });
                }
                else
                {
                    UserViewModel user = new UserViewModel
                    {
                        Id = u.Id,
                        Name = u.FullName,
                        Service = string.Empty,
                        CreatedDate = u.CreateDate,
                        Isactive = u.IsActive
                    };
                    model.Add(user);
                }

            });
            return model;
        }

        // GET api/values/5
        [HttpGet("{UserId}")]
        [Route("{UserId:long}/Services")]
        // public IEnumerable<UService> Get(int UserId)
        public IActionResult Get(int UserId)
        {
            var services = uservicesService.GetUserServices(UserId);
            if (services==null)
            {
                return NotFound();
            }
            return new ObjectResult(services);
            //return uservicesService.GetUserServices(UserId); ;
        }

        // POST api/values
        [HttpPost]
        [Route("create")]
        public IActionResult Post([FromBody]User userEntity)
        {
            TryValidateModel(userEntity);
            if(this.ModelState.IsValid)
            {
                userService.InsertUser(userEntity);
            }
            else
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetUsers", new { controller = "UserService"});
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
