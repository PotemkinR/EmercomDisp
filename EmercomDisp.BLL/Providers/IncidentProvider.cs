using EmercomDisp.Data.Clients;
using EmercomDisp.Model.Models;
using System;

namespace EmercomDisp.BLL.Providers
{
    public class IncidentProvider : IIncidentProvider
    {
        private readonly IIncidentClient _incidentClient;

        public IncidentProvider(IIncidentClient incidentClient)
        {
            _incidentClient = incidentClient ?? throw new ArgumentNullException("Incident Client");
        }
        public Incident GetIncidentById(int id)
        {
            return _incidentClient.GetIncidentById(id);
        }
    }
}
