using EmercomDisp.BLL.Enums;
using EmercomDisp.BLL.Services;
using EmercomDisp.Web.Models.Login;
using log4net;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService ?? throw new ArgumentNullException("Login Service");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var result = _loginService.Login(userName, password);

            if (result == LoginResult.NoError)
            {
                _log.Info(HttpContext.User.Identity.Name + DateTime.Now.ToString());
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginModel();

            if (result == LoginResult.EmptyCredentials)
            {
                model.Message = "Check user name and password";
            }
            if (result == LoginResult.InvalidCredentials)
            {
                model.Message = "The user is not valid";
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            _loginService.Logout();
            return RedirectToAction("Login", "Login");
        }
    }
}