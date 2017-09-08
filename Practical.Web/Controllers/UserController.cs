using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Practical.Service;
using Practical.Web.Models;
using Practical.Data;
using Microsoft.AspNetCore.Http;

namespace Practical.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices userService;
        private readonly IUServicesService uservicesService;
         
        

        public UserController(IUserServices userService, IUServicesService uServicesService)
        {
            this.userService = userService;
            this.uservicesService = uServicesService;
        }

        [HttpGet]
        [Route("Users/list")]
        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            userService.GetUsers().ToList().ForEach(u =>
            {
                var service = uservicesService.GetUserServices(u.Id).ToList();
                if (service.Count > 0)
                {
                    service.ForEach(s => {
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

            return View(model);
        }
        [HttpGet]
        public IActionResult Services()
        {
            var services = uservicesService.GetUService().ToList();
            return View(services);
        }

        
        [Route("Users/{UserId:long}/Services")]
        public IActionResult UserServices(long UserId)
        {
            var services = uservicesService.GetUserServices(UserId);
            return View(services);
        }
        [HttpGet]
        [Route("Users/Create")]
        public ActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();

            return PartialView("_AddUser", model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            User userEntity = new User
            {
                FullName = model.Name,
                IsActive= model.Isactive,
            };
            userService.InsertUser(userEntity);
            if (userEntity.Id > 0)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }

        //public ActionResult EditUser(int? id)
        //{
        //    UserViewModel model = new UserViewModel();
        //    if (id.HasValue && id != 0)
        //    {
        //        User userEntity = userService.GetUser(id.Value);
        //        UserProfile userProfileEntity = uservicesService.GetUserProfile(id.Value);
        //        model.FirstName = userProfileEntity.FirstName;
        //        model.LastName = userProfileEntity.LastName;
        //        model.Address = userProfileEntity.Address;
        //        model.Email = userEntity.Email;
        //    }
        //    return PartialView("_EditUser", model);
        //}

        //[HttpPost]
        //public ActionResult EditUser(UserViewModel model)
        //{
        //    User userEntity = userService.GetUser(model.Id);
        //    userEntity.Email = model.Email;
        //    userEntity.ModifiedDate = DateTime.UtcNow;
        //    userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        //    UserProfile userProfileEntity = uservicesService.GetUserProfile(model.Id);
        //    userProfileEntity.FirstName = model.FirstName;
        //    userProfileEntity.LastName = model.LastName;
        //    userProfileEntity.Address = model.Address;
        //    userProfileEntity.ModifiedDate = DateTime.UtcNow;
        //    userProfileEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        //    userEntity.UserProfile = userProfileEntity;
        //    userService.UpdateUser(userEntity);
        //    if (userEntity.Id > 0)
        //    {
        //        return RedirectToAction("index");
        //    }
        //    return View(model);
        //}

        //[HttpGet]
        //public PartialViewResult DeleteUser(int id)
        //{
        //    UserProfile userProfile = uservicesService.GetUserProfile(id);
        //    string name = $"{userProfile.FirstName} {userProfile.LastName}";
        //    return PartialView("_DeleteUser", name);
        //}

        //[HttpPost]
        //public ActionResult DeleteUser(long id, FormCollection form)
        //{
        //    userService.DeleteUser(id);          
        //    return RedirectToAction("Index");
        //}
    }
}
