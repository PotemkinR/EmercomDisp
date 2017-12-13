using EmercomDisp.BLL.Providers;
using EmercomDisp.Web.Models.CallResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class CallResponseController : Controller
    {
        private readonly ICallResponseProvider _callResponseProvider;

        public CallResponseController(ICallResponseProvider callResponseProvider)
        {
            _callResponseProvider = callResponseProvider ?? throw new ArgumentNullException("Call Response Provider");
        }

        public PartialViewResult CallResponseList(int id)
        {
            var model = new CallResponseListModel()
            {
                CallResponses = _callResponseProvider.GetCallResponsesForCall(id)
            };
            return PartialView(model);
        }
    }
}