using EmercomDisp.BLL.Enums;
using EmercomDisp.BLL.Providers;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;

namespace EmercomDisp.BLL.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserProvider _userProvider;
        private readonly IUserService _userService;

        public LoginService(IUserProvider userProvider,
            IUserService userService)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException("User Provider");
            _userService = userService ?? throw new ArgumentNullException("User Service");
        }

        public LoginResult Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return LoginResult.EmptyCredentials;
            }

            if (_userService.IsValidUser(userName, password))
            {
                var user = _userProvider.GetUserByName(userName);
                var userData = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(2, userName, DateTime.Now, DateTime.Now.AddHours(1), false, userData);
                var encTicket = FormsAuthentication.Encrypt(ticket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                HttpContext.Current.Response.Cookies.Add(authCookie);
                return LoginResult.NoError;
            }

            return LoginResult.InvalidCredentials;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
