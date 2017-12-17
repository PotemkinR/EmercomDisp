using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public interface IVictimsRepository
    {
        Victim GetVictimById(int id);
        IEnumerable<Victim> GetVictimsByIncidentId(int id);
        void AddVictim(Victim victim, int callId);
        void UpdateVictim(Victim victim);
        void DeleteVictim(int id);
    }
}
