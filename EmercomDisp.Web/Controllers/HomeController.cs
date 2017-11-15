using EmercomDisp.BLL.ErrorProviders;
using EmercomDisp.BLL.MessageProvider;
using EmercomDisp.Web.Models;
using log4net;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");
        private readonly IMessageProvider _messageProvider;
        private readonly IErrorProvider _errorProvider;
        // GET: Home
        public HomeController(IMessageProvider messageProvider, IErrorProvider errorProvider)
        {
            _messageProvider = messageProvider;
            _errorProvider = errorProvider;
        }
        public ActionResult Index()
        {
            try
            {
                _errorProvider.ThrowError();
            }
            catch(Exception e)
            {
                _log.Error(e.Message);
            }
            HomeViewModel model = new HomeViewModel { Message = _messageProvider.GetMessage() };
            return View(model);
        }
    }
}