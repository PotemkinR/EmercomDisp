using EmercomDisp.BLL.MessageProvider;
using EmercomDisp.Web.Models;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageProvider messageProvider;
        // GET: Home
        public HomeController(IMessageProvider provider)
        {
            messageProvider = provider;
        }
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel { Message = messageProvider.GetMessage() };
            return View(model);
        }
    }
}