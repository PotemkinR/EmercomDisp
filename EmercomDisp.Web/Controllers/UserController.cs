using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Users;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserProvider _userProvider;

        public UserController(IUserProvider userProvider)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException("User Provider");
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            var model = new UserModel
            {
                Roles = _userProvider.GetRoles()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel user)
        {
            if (_userProvider.GetUserByName(user.Name).Name == user.Name)
            {
                ModelState.AddModelError("Name", "User already exixts");
            }

            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    Roles = GetRolesForUser(user)
                };
                _userProvider.CreateUser(newUser);
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(string name)
        {
            if (name == null)
            {
                return HttpNotFound();
            }

            var user = _userProvider.GetUserByName(name);
            var model = new UserModel()
            {
                Name = user.Name,
                Email = user.Email,
                Roles = user.Roles
            };

            if (user.Name != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    Roles = GetRolesForUser(user)
                };
                
                _userProvider.UpdateUser(updatedUser);
            }

            var model = new UserModel()
            {
                Name = user.Name,
                Email = user.Email,
                Roles = user.Roles
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult UserList()
        {
            var model = new UserListModel
            {
                Users = _userProvider.GetUsers()
            };
            return View(model);
        }

        //переделать?
        private IEnumerable<string> GetRolesForUser(UserModel user)
        {   
            var roles = new List<string>();

            if (Request.Form["admin"] != null)
            {
                roles.Add("Admin");
                roles.Add("Editor");
            }
            if (Request.Form["editor"] != null)
            {
                roles.Add("Editor");
            }
            roles.Add("User");

            return roles;
        }
    }
}