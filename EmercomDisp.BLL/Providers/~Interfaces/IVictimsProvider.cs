using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public interface IVictimsProvider
    {
        IEnumerable<Victim> GetVictimsForIncident(int incidentId);
    }
}
