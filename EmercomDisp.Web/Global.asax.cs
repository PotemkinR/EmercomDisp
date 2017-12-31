using EmercomDisp.BLL;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Controllers;
using log4net;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace EmercomDisp.Web
{
    public class MvcApplication : HttpApplication
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

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

        private void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();
            httpContext.Response.TrySkipIisCustomErrors = true;

            _log.Error(exception.Message);

            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = "InternalServerError";
            routeData.Values["exception"] = exception;
            using (var controller = new ErrorController())
            {
                ((IController)controller).Execute(
                new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
        }
    }
}
