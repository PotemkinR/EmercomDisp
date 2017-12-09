using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Users;
using System;
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
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel user)
        {
            //if (_userProvider.GetUserByName(user.Name) != null)
            //{
            //    ModelState.AddModelError("Name", "User already exixts");
            //}

            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password
                };
                _userProvider.CreateUser(newUser);
            }
            return View();
        }
    }
}