using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public interface IVictimsProvider
    {
        Victim GetVictimById(int id);
        IEnumerable<Victim> GetVictimsByIncidentId(int id);
        void AddVictim(Victim victim, int callId);
        void UpdateVictim(Victim victim);
        void DeleteVictim(int id);
    }
}
