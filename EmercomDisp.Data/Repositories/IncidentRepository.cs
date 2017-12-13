using EmercomDisp.Data.IncidentService;
using EmercomDisp.Model.Models;
using log4net;
using System;
using System.ServiceModel;

namespace EmercomDisp.Data.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

        public Incident GetIncidentById(int id)
        {
            var incident = new Incident();
            using (var client = new IncidentServiceClient())
            {
                try
                {
                    client.Open();

                    var incidentDto = client.GetIncidentById(id);

                    if (incidentDto != null)
                    {
                        incident.Description = incidentDto.Description;
                        incident.Cause = incidentDto.Cause;
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return incident;
        }
    }
}
