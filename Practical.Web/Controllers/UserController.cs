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
         
        private readonly IUserServicesList userServicesList;

        public UserController(IUserServices userService, IUServicesService uServicesService, IUserServicesList userServicesList)
        {
            this.userService = userService;
            this.uservicesService = uServicesService;
            this.userServicesList = userServicesList;
        }

        [HttpGet]
        [Route("Users/list")]
        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            userService.GetUsers().ToList().ForEach(u =>
            {
                userServicesList.GetUServiceListById(u.Id).ToList().ForEach(s => {

                    UserViewModel user = new UserViewModel
                    {
                        Id = u.Id,
                        Name = u.FullName,
                        Service = s.Name,
                        CreatedDate = u.CreateDate,
                        Isactive=u.IsActive
                    };
                    model.Add(user);
                });


                
            });

            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();

            return PartialView("_AddUser", model);
        }

        //[HttpPost]
        //public ActionResult AddUser(UserViewModel model)
        //{
        //    User userEntity = new User
        //    {
        //        UserName = model.UserName,
        //        Email = model.Email,
        //        Password = model.Password,
        //        AddedDate = DateTime.UtcNow,
        //        ModifiedDate = DateTime.UtcNow,
        //        IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
        //        UserProfile = new UserProfile
        //        {
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Address = model.Address,
        //            AddedDate = DateTime.UtcNow,
        //            ModifiedDate = DateTime.UtcNow,
        //            IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
        //        }
        //    };
        //    userService.InsertUser(userEntity);
        //    if (userEntity.Id > 0)
        //    {
        //        return RedirectToAction("index");
        //    }
        //    return View(model);
        //}

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
