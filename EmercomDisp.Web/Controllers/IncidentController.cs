using EmercomDisp.BLL.Providers;
using EmercomDisp.Web.Models.Incidents;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IIncidentProvider _incidentProvider;

        public IncidentController(IIncidentProvider incidentProvider)
        {
            _incidentProvider = incidentProvider ?? throw new ArgumentNullException("Incident Provider");
        }

        [ChildActionOnly]
        public PartialViewResult IncidentDetails(int id)
        {
            var incident = _incidentProvider.GetIncidentById(id);
            var model = new IncidentDetailsModel()
            {
                Incident = incident
            };

            return PartialView(model);
        }
    }
}