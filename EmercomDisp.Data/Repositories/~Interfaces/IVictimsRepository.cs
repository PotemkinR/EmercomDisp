using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public interface IVictimsRepository
    {
        IEnumerable<Victim> GetVictimsForIncident(int incidentId);
    }
}
