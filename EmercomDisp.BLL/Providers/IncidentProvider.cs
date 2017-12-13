using EmercomDisp.Data.Repositories;
using EmercomDisp.Model.Models;
using System;

namespace EmercomDisp.BLL.Providers
{
    public class IncidentProvider : IIncidentProvider
    {
        private readonly IIncidentRepository _incidentRepoository;

        public IncidentProvider(IIncidentRepository incidentRepository)
        {
            _incidentRepoository = incidentRepository ?? throw new ArgumentNullException("Incident Repository");
        }
        public Incident GetIncidentById(int id)
        {
            return _incidentRepoository.GetIncidentById(id);
        }
    }
}
