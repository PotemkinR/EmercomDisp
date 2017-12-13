using EmercomDisp.Data.Repositories;
using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public class VictimsProvider : IVictimsProvider
    {
        public readonly IVictimsRepository _victimsRepository;

        public VictimsProvider(IVictimsRepository victimsRepository)
        {
            _victimsRepository = victimsRepository ?? throw new ArgumentNullException("Victims Repository");
        }
        public IEnumerable<Victim> GetVictimsForIncident(int incidentId)
        {
            return _victimsRepository.GetVictimsForIncident(incidentId);
        }
    }
}
