using EmercomDisp.BLL;
using EmercomDisp.Model.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace EmercomDisp.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.Configure();
        }

        public void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var auth = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (auth != null)
            {
                var ticket = FormsAuthentication.Decrypt(auth.Value);
                var model = JsonConvert.DeserializeObject<User>(ticket.UserData);
                var principal = new UserPrincipal(ticket.Name)
                {
                    UserName = model.Name,
                    Roles = model.Roles
                };
                HttpContext.Current.User = principal;
            }
        }
    }
}
