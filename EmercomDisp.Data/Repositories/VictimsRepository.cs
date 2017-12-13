using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public class VictimsRepository : IVictimsRepository
    {
        public IEnumerable<Victim> GetVictimsForIncident(int incidentId)
        {
            throw new NotImplementedException();
        }
    }
}
